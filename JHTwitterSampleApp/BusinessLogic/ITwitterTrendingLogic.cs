﻿using JHTwitterSampleApp.Models;
using System.Collections.Generic;

namespace JHTwitterSampleApp.BusinessLogic
{
    public interface ITwitterTrendingLogic
    {
        List<KeyValuePair<int, string>> GetTrendingHashTags();
    }
}