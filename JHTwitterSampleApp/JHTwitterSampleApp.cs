using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class JHTwitterSampleApp : Form
    {
        static List<TwitterDataModel> result = new List<TwitterDataModel>();
        static string _twitterBearerToken = ConfigurationManager.AppSettings["TwitterBearerToken"];
        static string url = "https://api.twitter.com/2/tweets/sample/stream";

        static int mycount = 0;

        public JHTwitterSampleApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (TwitterDataModel item in result)
            {
                lblMessage.Text += item.data.text + "\n";
            }

            lblMessage.Text = "";

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var progress = new Progress<List<TwitterDataModel>>(value =>
            {
                lblMessage.Text = value.Count.ToString();
            });

            await Task.Run(() => Method1(progress));


            lblMessage.Text = progress.ToString();
        }

        public void Method1(IProgress<List<TwitterDataModel>> progress)
        {
            url += "?tweet.fields=author_id,conversation_id,created_at,entities,lang,";
            url += "possibly_sensitive,text&expansions=author_id,entities.mentions.username";

            // everything
            //url += "?tweet.fields=attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,non_public_metrics,";
            //url += "organic_metrics,possibly_sensitive,promoted_metrics,public_metrics,referenced_tweets,reply_settings,source,text,withheld&expansions=attachments.media_keys,attachments.poll_ids,author_id,entities.mentions.username,geo.place_id,in_reply_to_user_id,";
            //url += "referenced_tweets.id,referenced_tweets.id.author_id";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = "Bearer " + _twitterBearerToken;

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                string line;
                int count = 0;
                // Read line by line  
                while ((line = sr.ReadLine()) != null)
                {
                    count++;

                    TwitterDataModel myDeserializedClass = JsonConvert.DeserializeObject<TwitterDataModel>(line);
                    result.Add(myDeserializedClass);

                    mycount = result.Count;
                    progress.Report(result);
                   
                    //if (count > 10)
                    //{
                    //    break;
                    //}
                }
            }
        }
    }
}
