using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassHub.Models
{
    public class CommentsDbHandler
    {
        private dbEntities db = new dbEntities();

        public List<Comment> getComments(int activityId) {
            return db.Comments.Where(x => x.act == activityId).ToList();
        }
    }
}