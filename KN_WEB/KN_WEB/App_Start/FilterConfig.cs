using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KN_WEB
{
    public class FilterConfig : ActionFilterAttribute
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// Permite revisar si aùn no se ha vencido la información del usuario para permitirle navegar en el sistema, caso contrario lo devuelve a la pagina de login para que pueda accesar nuevamente.
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (HttpContext.Current.Session["userInfo"]==null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "Controller", "Login" },
                        { "Action", "Index" }
                    });
            }

            base.OnActionExecuted(filterContext);
        }

    }
}
