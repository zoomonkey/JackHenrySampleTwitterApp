using JHTwitterSampleApp.Models;

namespace JHTwitterSampleApp.DAL
{
    public interface ITwitterDAO
    {
        bool SaveTwitterReportModel(TwitterDataModel tdm);
    }
}