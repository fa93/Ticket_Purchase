using Autofac;
using FirstDemo.Web.Models;
using TicketPurchase.Web.Areas.Admin.Models;

namespace TicketPurchase.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IndexModel>().AsSelf();
            builder.RegisterType<TicketBookingModel>().AsSelf();
            builder.RegisterType<BookingListModel>().AsSelf();
            builder.RegisterType<TicketEditModel>().AsSelf();
            base.Load(builder);
        }
    }
}
