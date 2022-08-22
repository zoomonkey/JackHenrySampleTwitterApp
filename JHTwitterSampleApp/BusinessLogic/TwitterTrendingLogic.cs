using System.Collections.Generic;

namespace JHTwitterSampleApp.BusinessLogic
{
    public class TwitterTrendingLogic : ITwitterTrendingLogic
    {
        public List<TwitterDataModel> _twitterDataModel { get; set; }
        public TwitterTrendingLogic(List<TwitterDataModel> twitterDataModel)
        {
            _twitterDataModel = twitterDataModel;
        }

        public List<KeyValuePair<int, string>> GetTrendingHashTags()
        {
            try
            {
                var retval = new List<KeyValuePair<int, string>>();

                // todo add real logic
                for (int i = 0; i < 10; i++)
                {
                    if (_twitterDataModel[0].data.entities.hashtags == null)
                    {
                        continue;
                    }

                    string? has = _twitterDataModel[0].data.entities.hashtags[0].tag ?? "Null";
                    retval.Add(new KeyValuePair<int, string>(i, has));
                }

                return retval;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
