using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiktack.WebGraphQL.DataLayer.Entities
{
    public class Reservation
    {
        public int Id { get; set; }


        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        public int GuestId { get; set; }
        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }

        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}