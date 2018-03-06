using System.Web.Mvc;

namespace Lib.Mvc.ActionFilter.ActionFilters
{
    /// <summary>
    /// 限制僅能用於AJAX要求
    /// </summary>
    public class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);

            if(filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
}