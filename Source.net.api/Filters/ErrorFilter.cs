using Source.net.infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace Source.net.api.Filters
{
    public class ErrorFilter: ExceptionFilterAttribute
    {
        public string errorKey = "Errors";
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException)
            {
                context.ModelState.AddModelError(errorKey, context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.ModelState.AddModelError(errorKey, "Interal Server Error");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var list = context.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, y => y.Value.Errors.Select(z => z.ErrorMessage));

            context.Result = new JsonResult(list);
        }
    }
}
