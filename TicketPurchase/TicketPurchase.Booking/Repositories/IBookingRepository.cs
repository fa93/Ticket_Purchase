using TicketPurchase.Booking.Entities;
using TicketPurchase.Data;

namespace TicketPurchase.Booking.Repositories
{
    public interface IBookingRepository : IRepository<TicketBooking, int>
    {
    }
}
