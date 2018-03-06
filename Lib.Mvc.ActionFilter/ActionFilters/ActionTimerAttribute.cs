using System.Diagnostics;
using System.Web.Mvc;

namespace Lib.Mvc.ActionFilter.ActionFilters
{
    /// <summary>
    /// 計時器(be careful each controller create instance once only)
    /// </summary>
    public class ActionTimerAttribute : ActionFilterAttribute
    {
        private Stopwatch timer;

        public ActionTimerAttribute()
        {
            timer = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer.Reset();
            timer.Start();

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            timer.Stop();
            filterContext.Controller.ViewData["ActionTime"] = timer.ElapsedMilliseconds;
        }
    }
}