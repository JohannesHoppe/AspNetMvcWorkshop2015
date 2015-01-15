using System.Diagnostics;
using System.Web;
using System.Web.Mvc;

namespace AcTraining.Controllers
{
    /// <summary>
    /// Filter to display the execution time of both the action and result
    /// </summary>
    public class RequestTimingFilter : FilterAttribute, IActionFilter, IResultFilter
    {
        private static Stopwatch GetTimer(ControllerContext context, string name)
        {
            var key = string.Format("__timer__{0}", name);
            if (context.HttpContext.Items.Contains(key))
            {
                return (Stopwatch)context.HttpContext.Items[key];
            }

            var result = new Stopwatch();
            context.HttpContext.Items[key] = result;
            return result;
        }

        /// <summary>
        ///   Called before an action method executes.
        /// </summary>
        /// <param name = "filterContext">The filter context.</param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            GetTimer(filterContext, "action").Start();
        }

        /// <summary>
        ///   Called after the action method executes.
        /// </summary>
        /// <param name = "filterContext">The filter context.</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            GetTimer(filterContext, "action").Stop();

            filterContext.Controller.ViewBag.CurrentUserName = HttpContext.Current.User.Identity.Name;
        }

        /// <summary>
        ///   Called before an action result executes.
        /// </summary>
        /// <param name = "filterContext">The filter context.</param>
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {          
            GetTimer(filterContext, "render").Start();
        }

        /// <summary>
        /// Called after an action result executes.
        /// </summary>
        /// <param name = "filterContext">The filter context.</param>
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var renderTimer = GetTimer(filterContext, "render");
            renderTimer.Stop();

            var actionTimer = GetTimer(filterContext, "action");
            var response = filterContext.HttpContext.Response;

            if (response.ContentType == "text/html")
            {
                response.Write(
                    string.Format(
                    "<hr><h4>ActionFilter</h4>Action '{0} :: {1}'<br /> Execute: {2}ms, Render: {3}ms.",
                    filterContext.RouteData.Values["controller"],
                    filterContext.RouteData.Values["action"],
                    actionTimer.ElapsedMilliseconds,
                    renderTimer.ElapsedMilliseconds));
            }
        }
    }
}