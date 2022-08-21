using System;
using System.Collections.Generic;

namespace JHTwitterSampleApp
{
    public interface ITwitterPollingLogic
    {
        void GetTwitterDataLive(IProgress<List<TwitterDataModel>> progressDynamic, IProgress<TwitterReportModel> twitterReportModel, int sampleSizeForTrendingReport);
    }
}