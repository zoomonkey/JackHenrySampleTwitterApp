using JHTwitterSampleApp.Models;
using System.Collections.Generic;

namespace JHTwitterSampleApp.BusinessLogic
{
    public interface ICombineAllHashTagsLists
    {
        List<Hashtag> CombineAllHashTagsIntoOneList();
    }
}