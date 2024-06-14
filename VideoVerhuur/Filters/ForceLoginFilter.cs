using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VideoVerhuur.Models;

namespace VideoVerhuur.Filters;

public class ForceLoginFilter : ActionFilterAttribute
{
    public string RedirectAction { get; set; }
    public string RedirectController { get; set; }

    public ForceLoginFilter(string redirectAction, string redirectController)
    {
        RedirectAction = redirectAction;
        RedirectController = redirectController;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string? ingelogd = context.HttpContext.Session.GetString("ingelogd");

        if (ingelogd == null)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = RedirectAction, controller = RedirectController}));
        }
    }
}
