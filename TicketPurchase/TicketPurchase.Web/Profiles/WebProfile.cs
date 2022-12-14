using AutoMapper;
using TicketPurchase.Booking.BusinessObjects;
using TicketPurchase.Web.Areas.Admin.Models;

namespace TicketPurchase.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<TicketBookingModel, TicketBooking>()
                .ReverseMap();

            CreateMap<TicketEditModel, TicketBooking>()
                .ReverseMap();
        }
    }
}
