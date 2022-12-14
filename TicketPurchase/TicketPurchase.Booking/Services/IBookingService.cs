using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Booking.BusinessObjects;

namespace TicketPurchase.Booking.Services
{
    public interface IBookingService 
    {
        void AddBooking(TicketBooking ticketBooking);
        (int total, int totalDisplay, IList<TicketBooking> records) GetBookings(int pageIndex, int pageSize,
            string searchText, string orderBy);
        void EditTicket(TicketBooking ticket);
        TicketBooking GetTicket(int id);
        void DeleteTicket(int id);
    }
}
