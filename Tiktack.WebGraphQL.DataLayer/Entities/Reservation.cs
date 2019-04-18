using System;

namespace Tiktack.WebGraphQL.DataLayer.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public Room Room { get; set; }
        public Guest Guest { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}