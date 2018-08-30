using System.Web.Mvc;

namespace Sosapoverty.Areas.Kuchegardan
{
    public class KuchegardanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Kuchegardan";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapMvcAttributeRoutes();

            context.MapRoute(
                "Kuchegardan_default",
                "Kuchegardan/{controller}/{action}/{id}",
                new { Controller = "ManagePerson", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}