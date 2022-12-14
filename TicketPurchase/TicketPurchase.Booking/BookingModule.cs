using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPurchase.Booking.Dbcontexts;
using TicketPurchase.Booking.Repositories;
using TicketPurchase.Booking.Services;
using TicketPurchase.Booking.UnitOfWorks;

namespace TicketPurchase.Booking
{
    public class BookingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public BookingModule(string connectionString, string assemblyName)
        {
            _connectionString = connectionString;
            _assemblyName = assemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookingDbContext>().AsSelf()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("assemblyName", _assemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<BookingDbContext>().As<IBookingDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("assemblyName", _assemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<BookingUnitOfWork>().As<IBookingUnitOfWork>()
               .InstancePerLifetimeScope();

            builder.RegisterType<BookingRepository>().As<IBookingRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookingService>().As<IBookingService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
