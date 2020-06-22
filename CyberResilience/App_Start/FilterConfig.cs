using System.Web;
using System.Web.Mvc;
using CyberResilience.Attributes;

namespace CyberResilience
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleException());
            filters.Add(new LocalizationAttribute());
        }
    }
}
