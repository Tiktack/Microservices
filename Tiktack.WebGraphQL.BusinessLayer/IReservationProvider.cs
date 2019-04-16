using System.Collections.Generic;
using Tiktack.WebGraphQL.DataLayer.Entities;

namespace Tiktack.WebGraphQL.BusinessLayer
{
    public interface IReservationProvider
    {
        IList<Room> GetRooms();
        IList<Reservation> GetReservations();
        IList<Guest> GetGuests();
        Reservation GetReservation(int id);
        Room GetRoom(int id);
        Guest GetGuest(int id);
    }
}