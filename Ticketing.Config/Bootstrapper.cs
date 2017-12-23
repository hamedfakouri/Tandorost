using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.CastleWindsor;
using Framework.Core;
using Framework.Core.Security;
using Ticketing.Application;
using Ticketing.Domain.Services.TicketServices;
using Ticketing.Persistence.EF;
using Ticketing.Persistence.EF.Repository;
using Framework.DataAccess.EF;
using Ticketing.Application.Contract.Groups;
using Ticketing.Domain.Services.TicketCartableService;

namespace Ticketing.Config
{
    public static class Bootstrapper
    {
        public static IWindsorContainer WireUp()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<ISecurity>().ImplementedBy<GroupService>()
                .LifestylePerWebRequest());
                           

            container.Register(Component.For<SecurityInterceptor>().LifestylePerWebRequest());

            container.Register(Component.For<TransactionInterceptor>()
                .LifestyleBoundToNearest<IApplicationService>());

            container.Register(Component.For<IValidateTicketAssinedEqualToTrue>()
                .ImplementedBy<ValidateTicketAssinedEqualToTrue>().LifestylePerWebRequest());

            container.Register(Component.For<IUserDepartment>()
                .ImplementedBy<UserDepartment>().LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<TicketService>()
                .BasedOn<IApplicationService>()
                .LifestylePerWebRequest()
                .WithService.FromInterface()
                .Configure(x => x.Interceptors<TransactionInterceptor, SecurityInterceptor>()));

            container.Register(Classes.FromAssemblyContaining<TicketRepository>()
                .BasedOn<IRepository>()
                .LifestylePerWebRequest()
                .WithService.FromInterface());

            container.Register(Component.For<TicketingDbContext>()
                .Forward<DbContext>()
                .LifestylePerWebRequest());

            container.Register(Component.For<DbConnection>().LifestylePerWebRequest()
                .UsingFactoryMethod(x =>
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    var connection = new SqlConnection(connectionString);
                    connection.Open();
                    return connection;
                }).OnDestroy(x => x.Close()));

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>()
                .LifestylePerWebRequest());

            return container;
        }
    }
}
