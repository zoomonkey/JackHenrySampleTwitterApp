using JHTwitterSampleApp.Models;
using System;
using System.Collections.Generic;

namespace JHTwitterSampleApp.BusinessLogic
{
    public interface ITwitterPollingLogic
    {
        public int _sampleSizeForTrendingReport { get; set; }
        public string _url { get; set; }
        public string _twitterBearerToken { get; set; }
        public List<TwitterDataModel> _twitterDataDynamic { get; set; }
        public TwitterReportModel _twitterReportModel { get; set; }
        public void GetTwitterDataLive(IProgress<List<TwitterDataModel>> progressDynamic, IProgress<TwitterReportModel> twitterReportModel, int sampleSizeForTrendingReport);
    }
}