using JHTwitterSampleApp.Models;
using System.Collections.Generic;

namespace JHTwitterSampleApp.BusinessLogic
{
    public interface ITwitterTrendingLogic
    {
        List<TwitterDataModel> _twitterDataModel { get; set; }
        List<Hashtag> CombineAllHashTagsIntoOneList();
        List<KeyValuePair<int, string>> GetTrendingHashTags();
    }
}