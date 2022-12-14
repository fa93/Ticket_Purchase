using Autofac;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TicketPurchase.Booking.BusinessObjects;
using TicketPurchase.Booking.Services;

namespace TicketPurchase.Web.Areas.Admin.Models
{
    public class TicketBookingModel
    {
        private IBookingService _bookingService;
        private ILifetimeScope _scope;
        private IMapper _mapper;

        [StringLength(100, ErrorMessage = "Customer Name should be less than 100 chars")]
        [Required(ErrorMessage = "Name is required")]
        public string? CustomerName { get; set; }

        [StringLength(200, ErrorMessage = "Customer should be less than 100 chars")]
        [Required(ErrorMessage = "Address is required")]
        public string? CustomerAddress { get; set; }

        [Required(ErrorMessage = "Seat Number is required")]
        public string? SeatNumber { get; set; }

        [Required(ErrorMessage = "Ticket Price is required")]
        public int TicketPrice { get; set; }

        [Required(ErrorMessage = "Bus Number is required")]
        public string? BusNumber { get; set; }

        [Required(ErrorMessage = "Onboarding Time is required")]
        public DateTime OnboardingTime { get; set; }

        public TicketBookingModel()
        {

        }
        public TicketBookingModel(IMapper mapper, IBookingService bookingService)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _bookingService = _scope.Resolve<IBookingService>();
            _mapper = _scope.Resolve<IMapper>();
        }
        internal void PurchaseTicket()
        {
            var ticket = _mapper.Map<TicketBooking>(this);
            _bookingService.AddBooking(ticket);
        }
    }
}
