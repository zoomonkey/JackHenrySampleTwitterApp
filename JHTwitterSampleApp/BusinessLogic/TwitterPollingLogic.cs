using JHTwitterSampleApp.Models;
using log4net;
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
        public ILog _log;

        /// <summary>
        /// Dependencies, url / security token 
        /// </summary>
        public TwitterPollingLogic(string url, string urlParams, string twitterBearerToken, int sampleSizeForTrendingReport, ILog logger)
        {
            _url = url;
            _twitterBearerToken = twitterBearerToken;
            _sampleSizeForTrendingReport = sampleSizeForTrendingReport;
            _twitterDataDynamic = new List<TwitterDataModel>();
            _twitterReportModel = new TwitterReportModel();
            _log = logger;
        }
        /// <summary>
        /// This gets live Twitter data and returns a List of Tweets model from Twitter.  The dynamic one is used to report live counts.  The static copy is
        /// used to do queries on.  This is used as a snapshot in time from which to report.
        /// </summary>
        public void GetTwitterDataLive(IProgress<List<TwitterDataModel>> progressDynamic, IProgress<TwitterReportModel> twitterReportModel, int sampleSizeForTrendingReport)
        {
            try
            {
                _log.Info("Call GetTwitterDataLive");
                int recurringCounter = 0;
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

                        recurringCounter++;
                        // at certain points, report on the trend discovered
                        if (recurringCounter == _sampleSizeForTrendingReport)
                        {
                            recurringCounter = ProcessTrendingReporting(twitterReportModel, sampleSizeForTrendingReport);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Handles the sampling of a certain number of tweets to determing what is trending
        /// </summary>
        /// <param name="twitterReportModel"></param>
        /// <param name="sampleSizeForTrendingReport"></param>
        /// <returns></returns>
        private int ProcessTrendingReporting(IProgress<TwitterReportModel> twitterReportModel, int sampleSizeForTrendingReport)
        {
            int recurringCounter = 0;
            // get the last N records for a current sample
            _twitterDataDynamic.Reverse();
            List<TwitterDataModel> lastSample = _twitterDataDynamic.Take(sampleSizeForTrendingReport).ToList();
            _twitterDataDynamic.Reverse();

            // take a sample of the data and get a KeyValuePair of whats trending from this sample
            ITwitterTrendingLogic twitterTrendingLogic = new TwitterTrendingLogic(lastSample, _log);
            List<KeyValuePair<int, string>> trends = twitterTrendingLogic.GetTrendingHashTags();

            _twitterReportModel = new TwitterReportModel();

            int counter = 1;
            foreach (KeyValuePair<int, string> item in trends)
            {
                if (item.Value != null)
                {
                    _twitterReportModel.trending += "#" + counter.ToString() + " " + item.Value + "\n";
                    counter++;
                }
            }
            twitterReportModel.Report(_twitterReportModel);
            return recurringCounter;
        }
    }
}
