using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Booking.Dbcontexts;
using TicketPurchase.Booking.Repositories;
using TicketPurchase.Data;

namespace TicketPurchase.Booking.UnitOfWorks
{
    public class BookingUnitOfWork : UnitOfWork, IBookingUnitOfWork
    {
        public IBookingRepository Bookings { get; private set; }
        public BookingUnitOfWork(IBookingDbContext dbContext, IBookingRepository bookingRepository)
            : base((DbContext)dbContext)
        {
            Bookings = bookingRepository;
        }
    }
}
