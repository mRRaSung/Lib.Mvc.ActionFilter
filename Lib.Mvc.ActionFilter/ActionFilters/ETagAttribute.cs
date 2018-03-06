using System.Web.Mvc;

namespace Lib.Mvc.ActionFilter.ActionFilters
{
    public class ETagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Filter = new ETagFilter(filterContext);
        }
    }
}