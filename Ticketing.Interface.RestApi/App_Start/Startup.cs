using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Owin;
using Owin;
using Ticketing.Config;
using Ticketing.Interface.RestApi;
using Ticketing.Interface.RestApi.Controllers;
using Ticketing.Interface.RestApi.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(Startup))]

//namespace Ticketing.Interface.RestApi.App_Start
namespace Ticketing.Interface.RestApi

{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config =new HttpConfiguration();
            app.UseCors(CorsOptions.AllowAll);
            ConfigJsonFormat(config);


            WebApiConfig.Register(config);
            var container = Bootstrapper.WireUp();

            ConfigContainer(config);
            ConfigSecurity(app);
            app.UseWebApi(config);

          
        }

        private void ConfigJsonFormat(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter
                .SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        private void ConfigSecurity(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
        private static IWindsorContainer ConfigContainer(HttpConfiguration config)
        {
            var container = Bootstrapper.WireUp();
            container.Register(Classes.FromAssemblyContaining(typeof(TicketController))
                .BasedOn<ApiController>().LifestylePerWebRequest());

            config.Services.Replace(typeof(IHttpControllerActivator),
                new IocControllerActivator(container));
            return container;
        }
    }
}
