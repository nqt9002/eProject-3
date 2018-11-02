using System.Web.Mvc;

namespace eProject3_Jamesthew.Areas.customer
{
    public class customerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "customer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "customer_default",
                "customer/{action}/{id}",
                new { action = "Details", controller = "Profile", id = UrlParameter.Optional }
            );
        }
    }
}