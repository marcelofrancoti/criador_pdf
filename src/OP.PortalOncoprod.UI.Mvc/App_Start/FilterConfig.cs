using System.Web.Mvc;
using SimpleInjector;
using SistemaIndexador.Infra.CrossCutting.MvcFilters;

namespace SistemaIndexador.UI.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(container.GetInstance<GlobalFilterTool>());
        }
    }
}
