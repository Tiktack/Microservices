using System;

namespace Tiktack.WebGraphQL.DataLayer.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}