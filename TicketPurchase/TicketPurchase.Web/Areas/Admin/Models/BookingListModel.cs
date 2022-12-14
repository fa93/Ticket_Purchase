using TicketPurchase.Booking.Services;
using TicketPurchase.Web.Models;

namespace TicketPurchase.Web.Areas.Admin.Models
{
    public class BookingListModel
    {
        private readonly IBookingService _bookingService;
        public BookingListModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public object GetPagedBookings(DataTablesAjaxRequestModel model)
        {
            var data = _bookingService.GetBookings(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[]
                { "CustomerName", "CustomerAddress", "SeatNumber", "TicketPrice", "BusNumber", "OnboardingTime"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.CustomerName,
                                record.CustomerAddress,
                                record.SeatNumber,
                                record.TicketPrice.ToString(),
                                record.BusNumber,
                                record.OnboardingTime.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void DeleteTicket(int id)
        {
            _bookingService.DeleteTicket(id);
        }
    }
}
