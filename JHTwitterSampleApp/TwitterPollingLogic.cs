using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace JHTwitterSampleApp
{
    public class TwitterPollingLogic : ITwitterPollingLogic
    {
        static string _url = string.Empty;
        static string _twitterBearerToken = string.Empty;
        static int _sampleSizeForTrendingReport = 0;

        /// <summary>
        /// Dependencies, url / security token 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="twitterBearerToken"></param>
        public TwitterPollingLogic(string url, string twitterBearerToken, int sampleSizeForTrendingReport)
        {
            _url = url;
            _twitterBearerToken = twitterBearerToken;
            _sampleSizeForTrendingReport = sampleSizeForTrendingReport;
        }

        static List<TwitterDataModel> _twitterDataDynamic = new List<TwitterDataModel>();
        static TwitterReportModel _twitterReportModel = new TwitterReportModel();

        /// <summary>
        /// This gets live Twitter data and returns a List of Tweets model from Twitter.  The dynamic one is used to report live counts.  The static copy is
        /// used to do queries on.  This is used as a snapshot in time from which to report.
        /// </summary>
        public void GetTwitterDataLive(IProgress<List<TwitterDataModel>> progressDynamic, IProgress<TwitterReportModel> twitterReportModel, int sampleSizeForTrendingReport)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(_url);
            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = "Bearer " + _twitterBearerToken;

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                string line;
                // Read line by line  
                while ((line = sr.ReadLine()) != null)
                {
                    TwitterDataModel deserialized = JsonConvert.DeserializeObject<TwitterDataModel>(line);
                    _twitterDataDynamic.Add(deserialized);
                    progressDynamic.Report(_twitterDataDynamic);

                    if (_twitterDataDynamic.Count > _sampleSizeForTrendingReport) // todo: make this variable 'settable'
                    {
                        _twitterReportModel.trending = "blah";
                        twitterReportModel.Report(_twitterReportModel);
                    }
                }
            }
        }
    }
}
