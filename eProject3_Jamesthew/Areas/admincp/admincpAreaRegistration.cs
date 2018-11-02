using System.Web.Mvc;

namespace eProject3_Jamesthew.Areas.admincp
{
    public class admincpAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admincp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admincp_default",
                "admincp/{controller}/{action}/{id}",
                new { action = "Index", controller = "Admin", id = UrlParameter.Optional }
            );
        }
    }
}