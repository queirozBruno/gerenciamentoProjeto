using System.Web.Mvc;
using System.Web.Routing;

namespace gerenciamentoProjeto
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Index",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "consultaUsuarioPorEmail",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Integrante", action = "ObterIntegrantePorEmail", id = UrlParameter.Optional }
            );
        }
    }
}
