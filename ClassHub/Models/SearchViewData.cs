using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassHub.Models
{
    public class SearchViewData
    {
        public string userName { get; set; }
        public string className { get; set; }
        public string classDesc { get; set; }
        public string classCreator { get; set; }
        public bool joined { get; set; }
    }
}