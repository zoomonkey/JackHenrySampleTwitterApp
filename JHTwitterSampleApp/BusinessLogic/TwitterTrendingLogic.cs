using JHTwitterSampleApp.Models;
using log4net;
using System.Collections.Generic;
using System.Linq;

namespace JHTwitterSampleApp.BusinessLogic
{
    public class TwitterTrendingLogic : ITwitterTrendingLogic
    {
        private ILog _log;
        private List<TwitterDataModel> _twitterDataModel { get; set; }
        public TwitterTrendingLogic(List<TwitterDataModel> twitterDataModel, ILog logger)
        {
            _twitterDataModel = twitterDataModel;
            _log = logger;
        }
        /// <summary>
        /// Here we get all the hash tags from the given sample, group them together, then take the highest number count of that group giving us a 'trend'
        /// </summary>
        /// <returns>KeyValuePair<int, string></returns>
        public List<KeyValuePair<int, string>> GetTrendingHashTags()
        {
            try
            {
                _log.Info("Call GetTrendingHashTags");

                ICombineAllHashTagsLists combine = new CombineAllHashTagsLists(_twitterDataModel, _log);

                List<Hashtag> combinedHashTags = combine.CombineAllHashTagsIntoOneList();
                var query = from m in combinedHashTags
                            group m.tag by m.tag into g
                            select new { Name = g.Key, KeyCols = g.ToList() };

                query = query.OrderByDescending(k => k.KeyCols.Count);

                var retval = new List<KeyValuePair<int, string>>();

                // todo add dynamic number of trending hashtags, do 10 for now
                for (int i = 0; i < 10; i++)
                {
                    if (string.IsNullOrEmpty(combinedHashTags[i].tag))
                    {
                        i--;
                        continue;
                    }
                    retval.Add(new KeyValuePair<int, string>(i, combinedHashTags[i].tag));
                }

                return retval;
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message);
                throw;
            }
        }

    }
}
