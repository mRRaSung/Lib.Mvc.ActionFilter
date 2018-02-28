using System.Web.Mvc;

namespace Lib.Mvc.ActionFilter.ActionFilters
{
    /// <summary>
    /// (Test)抽出ViewBag.Message；
    /// 可用於預設某些值
    /// </summary>
    public class MessageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.Controller.ViewBag.Message = "我來自MessageAttribute";
            filterContext.Controller.ViewData["test"] = "TeSt";
            filterContext.Controller.TempData["temp"] = "tEmP";
        }
    }
}