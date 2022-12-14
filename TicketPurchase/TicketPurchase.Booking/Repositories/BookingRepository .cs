using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Booking.Dbcontexts;
using TicketPurchase.Booking.Entities;
using TicketPurchase.Data;

namespace TicketPurchase.Booking.Repositories
{
    public class BookingRepository : Repository<TicketBooking, int>, IBookingRepository
    {
        public BookingRepository(IBookingDbContext context)
            : base((DbContext)context)
        {
        }
    }
}
