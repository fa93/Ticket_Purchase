using Autofac;
using TicketPurchase.Web.Areas.Admin.Models;

namespace TicketPurchase.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IndexModel>().AsSelf();
            base.Load(builder);
        }
    }
}
