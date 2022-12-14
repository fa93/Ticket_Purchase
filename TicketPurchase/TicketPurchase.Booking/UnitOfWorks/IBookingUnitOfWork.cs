using TicketPurchase.Booking.Repositories;
using TicketPurchase.Data;

namespace TicketPurchase.Booking.UnitOfWorks
{
    public interface IBookingUnitOfWork : IUnitOfWork
    {
        IBookingRepository Bookings { get; }      
    }
}
