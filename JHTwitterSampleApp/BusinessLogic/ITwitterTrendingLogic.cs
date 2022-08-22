using System.Collections.Generic;

namespace JHTwitterSampleApp.BusinessLogic
{
    public interface ITwitterTrendingLogic
    {
        public List<TwitterDataModel> _twitterDataModel { get; set; }
        public List<KeyValuePair<int, string>> GetTrendingHashTags();
    }
}