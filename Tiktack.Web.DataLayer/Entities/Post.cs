using System;
using System.Collections.Generic;

namespace Tiktack.Web.DataLayer.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
