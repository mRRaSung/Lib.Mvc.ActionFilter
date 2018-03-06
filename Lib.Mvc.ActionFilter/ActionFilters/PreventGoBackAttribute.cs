using System.Web;
using System.Web.Mvc;

namespace Lib.Mvc.ActionFilter.ActionFilters
{
    /// <summary>
    /// 禁止上一頁
    /// 使其直接過期；並設定Header不允許快取
    /// </summary>
    public class PreventGoBackAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            filterContext.HttpContext.Response.Buffer = true;
            filterContext.HttpContext.Response.Expires = -1;
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoServerCaching();
            filterContext.HttpContext.Response.Cache.SetAllowResponseInBrowserHistory(false);
            filterContext.HttpContext.Response.Cache.SetNoStore();
        }
    }
}