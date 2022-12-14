using AutoMapper;
using TicketPurchase.Booking.BusinessObjects;
using TicketPurchase.Booking.Exceptions;
using TicketPurchase.Booking.UnitOfWorks;
using TicketEntity = TicketPurchase.Booking.Entities.TicketBooking;

namespace TicketPurchase.Booking.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingUnitOfWork _bookingUnitOfWork;
        private readonly IMapper _mapper;
        public BookingService(IMapper mapper, IBookingUnitOfWork bookingUnitOfWork)
        {
            _bookingUnitOfWork = bookingUnitOfWork;
            _mapper = mapper;
        }

        public void AddBooking(TicketBooking ticketBooking)
        {
            var purchasedCount = _bookingUnitOfWork.Bookings
                .GetCount(t => t.BusNumber.Equals(ticketBooking.BusNumber) &&
                t.SeatNumber.Equals(ticketBooking.SeatNumber));

            if (purchasedCount == 0)
            {
                var entity = _mapper.Map<TicketEntity>(ticketBooking); //autoMapper(overload: source BO and dest Type EO)
                _bookingUnitOfWork.Bookings.Add(entity);
                _bookingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("The seat number of this bus number has already booked!");
        }

        public void DeleteTicket(int id)
        {
            _bookingUnitOfWork.Bookings.Remove(id);
            _bookingUnitOfWork.Save();
        }

        public void EditTicket(TicketBooking ticket)
        {
            var purchasedCount = _bookingUnitOfWork.Bookings.GetCount(t => t.BusNumber.Equals(ticket.BusNumber)
            && t.SeatNumber.Equals(ticket.SeatNumber) && t.Id != ticket.Id);

            if (purchasedCount == 0)
            {
                var ticketEntity = _bookingUnitOfWork.Bookings.GetById(ticket.Id);
                ticketEntity = _mapper.Map(ticket, ticketEntity); //autoMapper overload: source BO and dest EO
                _bookingUnitOfWork.Save();
            }
            else
                throw new DuplicateException("Seat has been booked for someone else!");
        }

        public (int total, int totalDisplay, IList<TicketBooking> records)
           GetBookings(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var result = _bookingUnitOfWork.Bookings.GetDynamic(x => x.BusNumber.Contains(searchText),
                orderBy, string.Empty, pageIndex, pageSize, true);

            List<TicketBooking> bookings = new List<TicketBooking>();
            foreach (TicketEntity ticketBooking in result.data)
            {
                bookings.Add(_mapper.Map<TicketBooking>(ticketBooking)); //dest BO and source EO
            }
            return (result.total, result.totalDisplay, bookings);
        }

        public TicketBooking GetTicket(int id)
        {
            var ticketEntity = _bookingUnitOfWork.Bookings.GetById(id);

            var ticket = _mapper.Map<TicketBooking>(ticketEntity); //automapper overload: source Entity and dest Type BO

            return ticket;
        }
    }
}
