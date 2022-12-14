using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Booking.Entities;

namespace TicketPurchase.Booking.Dbcontexts
{
    public interface IBookingDbContext
    {
        DbSet<TicketBooking> Bookings { get; set; }
    }
}
