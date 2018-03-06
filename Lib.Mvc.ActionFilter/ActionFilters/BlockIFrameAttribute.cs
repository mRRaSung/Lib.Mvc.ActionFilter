using System.Web.Mvc;

namespace Lib.Mvc.ActionFilter.ActionFilters
{
    /// <summary>
    /// 禁止被IFrame(Except ChildAction)
    /// </summary>
    public class BlockIFrameAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            if(!filterContext.IsChildAction)
            {
                filterContext
                    .HttpContext
                    .Response
                    .AppendHeader("X-Frame-Options", "SAMEORIGIN");
            }
        }
    }
}