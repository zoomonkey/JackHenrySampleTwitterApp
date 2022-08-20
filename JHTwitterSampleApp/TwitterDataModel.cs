using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Data
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class TwitterDataModel
    {
        public Data data { get; set; }
    }

}
