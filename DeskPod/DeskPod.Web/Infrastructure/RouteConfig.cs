using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace DeskPod.Web.Infrastructure
{
    public static class RouteConfig
    {
        public static void Register(IRouteBuilder routes)
        {
            routes.MapRoute("podcasts", "podcasts/{url?}", new { controller = "home", action = "podcasts" });

            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
