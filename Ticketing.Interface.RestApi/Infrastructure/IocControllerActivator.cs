using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace Ticketing.Interface.RestApi.Infrastructure
{
    public class IocControllerActivator:IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public IocControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage message, HttpControllerDescriptor controllerDescriptor
            ,Type controllerType)
        {
            return (IHttpController)_container.Resolve(controllerType);
        }
    }
}
