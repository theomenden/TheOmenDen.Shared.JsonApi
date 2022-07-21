using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TheOmenDen.Shared.JsonApi.Filters;

public class ValidateModelStateActionFilter : IActionFilter
{
    private static readonly Dictionary<String, Action<ActionExecutedContext>> _methodMapping = new(StringComparer.OrdinalIgnoreCase)
    {
        {"DELETE", (fc) =>
        {
            var result = new NotFoundResult();

            fc.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

            fc.Result = result;
        }},
        {
            "GET", fc =>
            {
                var result = new BadRequestResult();

                fc.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                fc.Result = result;
            }
        },
        {
            "POST", fc =>
            {
                var result = new NotFoundResult();

                fc.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                fc.Result = result;
            }
        },
        {
            "PATCH", fc =>
            {
                var result = new ForbidResult();

                fc.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;

                fc.Result = result;
            }
        },
        {
            "PUT", fc =>
            {
                var result = new ForbidResult();

                fc.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;

                fc.Result = result;
            }
        },
    };

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
        if (filterContext.ModelState.IsValid)
        {
            return;
        }

        if (_methodMapping.TryGetValue(filterContext.HttpContext.Request.Method, out var filterContextAction))
        {
            filterContextAction(filterContext);
            return;
        }

        var serializerSettings = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        var content = JsonSerializer.Serialize(filterContext.ModelState, serializerSettings);

        var result = new ContentResult
        {
            Content = content,
            ContentType = MediaTypeNames.Application.Json
        };

        filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        filterContext.Result = result;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}
