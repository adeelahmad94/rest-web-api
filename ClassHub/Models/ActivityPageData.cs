using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassHub.Models
{
    public class ActivityPageData
    {
        public Activity activity { get; set; }
        public List<CommentView> comments { get; set; }
    }
}