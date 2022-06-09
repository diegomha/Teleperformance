using System.Web.Mvc;

namespace Teleperformance.Areas.AdminArea
{
    public class AdminAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminArea_default",
                "AdminArea/{controller}/{action}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "AdminArea_GetUsers",
                "AdminArea/{controller}/{action}",
                new { controller = "UserAdmin", action = "GetUsers" }
            );


            context.MapRoute(
                "AdminArea_GetUserById",
                "AdminArea/{controller}/{action}/Id",
                new { controller = "UserAdmin", action = "GetUserById" }
            );

            context.MapRoute(
                "AdminArea_Logoff",
                "AdminArea/{controller}/{action}",
                new { controller = "UserAdmin", action = "Logoff" }
            );
        }
    }
}