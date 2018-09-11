using System.Web;
using System.Web.Mvc;

namespace IASData.IranianHouse.SocialWorking
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
