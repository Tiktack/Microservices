using System;

namespace Tiktack.Web.DataLayer.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public string Author { get; set; }
        public int? ReplyTo { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
