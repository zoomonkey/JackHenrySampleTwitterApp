using JHTwitterSampleApp.Models;
using log4net;
using System.Collections.Generic;
using System.Linq;

namespace JHTwitterSampleApp.BusinessLogic
{
    public class CombineAllHashTagsLists : ICombineAllHashTagsLists
    {
        private ILog _log;
        private List<TwitterDataModel> _twitterDataModel { get; set; }
        public CombineAllHashTagsLists(List<TwitterDataModel> twitterDataModel, ILog logger)
        {
            _twitterDataModel = twitterDataModel;
        }
        /// <summary>
        /// Take a TwitterDataModel and return all of its hashtags combined into 1 list
        /// </summary>
        /// <returns>List<Hashtag></returns>
        public List<Hashtag> CombineAllHashTagsIntoOneList()
        {
            try
            {
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
