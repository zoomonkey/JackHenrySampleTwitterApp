using JHTwitterSampleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace JHTwitterSampleApp.BusinessLogic
{
    public class TwitterPollingLogic : ITwitterPollingLogic
    {
        public int _sampleSizeForTrendingReport { get; set; }
        public string _url { get; set; }
        public string _twitterBearerToken { get; set; } 
        public List<TwitterDataModel> _twitterDataDynamic { get; set; }
        public TwitterReportModel _twitterReportModel { get; set; }
        /// <summary>
        /// Dependencies, url / security token 
        /// </summary>
        public TwitterPollingLogic(string url, string urlParams, string twitterBearerToken, int sampleSizeForTrendingReport)
        {
            _url = url;
            _twitterBearerToken = twitterBearerToken;
            _sampleSizeForTrendingReport = sampleSizeForTrendingReport;
            _twitterDataDynamic = new List<TwitterDataModel>();
            _twitterReportModel = new TwitterReportModel();
        }
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

                    // at certain points, report on the trend discovered
                    if (_twitterDataDynamic.Count > _sampleSizeForTrendingReport) // todo: make this variable 'settable'
                    {
                        // get the last N records
                        _twitterDataDynamic.Reverse();
                        List<TwitterDataModel> lastSample = _twitterDataDynamic.Take(sampleSizeForTrendingReport).ToList();
                        _twitterDataDynamic.Reverse();

                        // take a sample of the data and get a KeyValuePair of whats trending from this sample
                        ITwitterTrendingLogic twitterTrendingLogic = new TwitterTrendingLogic(lastSample);
                        List<KeyValuePair<int, string>> trends = twitterTrendingLogic.GetTrendingHashTags();

                        _twitterReportModel = new TwitterReportModel();
                        foreach (KeyValuePair<int, string> item in trends)
                        {
                            if (item.Value != null)
                            {
                                _twitterReportModel.trending += " " + item.Value;
                            }
                        }
                        twitterReportModel.Report(_twitterReportModel);
                    }
                }
            }
        }
    }
}
