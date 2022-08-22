using JHTwitterSampleApp.Models;
using log4net;
using System.Collections.Generic;
using System.Linq;

namespace JHTwitterSampleApp.BusinessLogic
{
    public class TwitterTrendingLogic : ITwitterTrendingLogic
    {
        public ILog _log;
        public List<TwitterDataModel> _twitterDataModel { get; set; }
        public TwitterTrendingLogic(List<TwitterDataModel> twitterDataModel, ILog logger)
        {
            _twitterDataModel = twitterDataModel;
            _log = logger;
        }
        public List<KeyValuePair<int, string>> GetTrendingHashTags()
        {
            try
            {
                _log.Info("Call GetTrendingHashTags");
                List<Hashtag> combinedHashTags = CombineAllHashTagsIntoOneList();

                //var groupedCustomerList = _twitterDataModel
                //.GroupBy(u => u.data.entities.hashtags)
                //.Select(grp => grp.ToList())
                //.ToList();


                var retval = new List<KeyValuePair<int, string>>();

                // todo add real logic
                for (int i = 0; i < 10; i++)
                {
                    if (combinedHashTags[i] == null)
                    {
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
        /// <summary>
        /// Take a TwitterDataModel and return all of its hashtags combined into 1 list
        /// </summary>
        /// <returns></returns>
        private List<Hashtag> CombineAllHashTagsIntoOneList()
        {
            try
            {
                _log.Info("Call CombineAllHashTagsIntoOneList");
                // isolate the Entites list
                var ents = new List<Entities>();
                ents.AddRange(from TwitterDataModel e in _twitterDataModel
                              where e != null && e.data != null && e.data.entities != null && e.data.entities.hashtags != null
                              select e.data.entities);

                // get all the hashtags List of List 
                var hashtags = new List<List<Hashtag>>();
                hashtags.AddRange((from Entities e in ents
                                   select e.hashtags));

                // combine all the hashtags into 1 big list for simplicity sake
                return (from list in hashtags
                        from item in list
                        select item).ToList();
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message);
                throw;
            }
        }
    }
}
