using Azure;
using Domain.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Serilog;
namespace API.Filters
{
    public class ExceptionFilter:ExceptionFilterAttribute
    {
        
        public override void OnException(ExceptionContext context)
        {
            
             Log.Error(context.Exception, MagicString.UnhandleError);

            var result = new ObjectResult(new { error = MagicString.BadRequest })
            {
                StatusCode = 500
            };
            context.Result = result;
        }
    }
}
