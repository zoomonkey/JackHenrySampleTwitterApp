using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class JHTwitterSampleApp : Form
    {
        static List<TwitterDataModel> _twitterDataDynamic = new List<TwitterDataModel>();
        static TwitterReportModel _twitterReportModel = new TwitterReportModel();
        static string _twitterBearerToken = ConfigurationManager.AppSettings["TwitterBearerToken"];
        static int _retVal = 0;
        static string url = "https://api.twitter.com/2/tweets/sample/stream";

        public JHTwitterSampleApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private async void btnStartPollingTwitter_Click(object sender, EventArgs e)
        {
            btnStartPollingTwitter.Enabled = false;
            var twitterDataDynamic = new Progress<List<TwitterDataModel>>(value =>
            {
                lblMessage.Text = value.Count.ToString();
            });

            var twitterReportModel = new Progress<TwitterReportModel>(value =>
            {
                lblTrending.Text = value.trending;
            });

            await Task.Run(() => GetTwitterDataLive(twitterDataDynamic, twitterReportModel));
        }
        /// <summary>
        /// This gets live Twitter data and returns a List of Tweets model from Twitter.  The dynamic one is used to report live counts.  The static copy is
        /// used to do queries on.  This is used as a snapshot in time from which to report.
        /// </summary>
        /// <param name="progressDynamic"></param>
        public void GetTwitterDataLive(IProgress<List<TwitterDataModel>> progressDynamic, IProgress<TwitterReportModel> twitterReportModel)
        {
            // this could be put in a DB or more dynamic, hard coded for now
            url += "?tweet.fields=author_id,conversation_id,created_at,entities,lang,";
            url += "possibly_sensitive,text&expansions=author_id,entities.mentions.username";

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
                    TwitterDataModel deserialized = JsonConvert.DeserializeObject<TwitterDataModel>(line);
                    _twitterDataDynamic.Add(deserialized);
                    progressDynamic.Report(_twitterDataDynamic);

                    if (count > 100) // todo: make this variable 'settable'
                    {
                        _twitterReportModel.trending = "blah";
                        twitterReportModel.Report(_twitterReportModel);
                    }
                }
            }
        }

        private void btnStopPollingTwitter_Click(object sender, EventArgs e)
        {
            // TODO: Find a better way to stop polling 
            Application.Exit();
        }
    }
}
