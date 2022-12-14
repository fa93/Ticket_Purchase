using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Booking.BusinessObjects;
using TicketEntity = TicketPurchase.Booking.Entities.TicketBooking;
namespace TicketPurchase.Booking
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<TicketEntity, TicketBooking>()
               .ReverseMap();
        }
       
    }
}
