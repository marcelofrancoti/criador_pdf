using System.Web.Http;
using OP.PortalOncoprod.Application.AutoMapper;

namespace OP.PortalOncoprod.Services.REST.ClienteAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
