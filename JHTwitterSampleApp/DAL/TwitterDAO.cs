using System;
using System.Data;

namespace JHTwitterSampleApp
{
    public class TwitterDAO : ITwitterDAO
    {
        public bool SaveTwitterReportModel(TwitterDataModel tdm)
        {
            // TODO: write insert into DB.
            // something like, INSERT INTO Jht (trending, created_date) VALUES (tdm.trending, GETDATE())
            throw new NotImplementedException();
        }
    }
}
