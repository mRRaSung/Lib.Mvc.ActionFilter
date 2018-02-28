using System.Web.Mvc;

namespace Lib.Mvc.ActionFilter.ActionFilters
{
    public class MessageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.Controller.ViewBag.Message = "我來自MessageAttribute";
        }
    }
}