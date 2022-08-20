using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class JHTwitterSampleApp : Form
    {
        static List<TwitterDataModel> result = new List<TwitterDataModel>();
        static string _twitterBearerToken = ConfigurationManager.AppSettings["TwitterBearerToken"];
        static string url = "https://api.twitter.com/2/tweets/sample/stream";
        Thread _backgroundThread = new Thread(new ThreadStart(StartPollingTwitter));

        public JHTwitterSampleApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            StartPollingTwitter();

            foreach (TwitterDataModel item in result)
            {
                lblMessage.Text += item.data.text + "\n";
            }
           

            Console.WriteLine($"The result of Method3 is: {result}");
        }


        public static void StartPollingTwitter()
        {
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
                    if (count > 10)
                    {
                        break;
                    }
                }
            }
        }

    }
}
