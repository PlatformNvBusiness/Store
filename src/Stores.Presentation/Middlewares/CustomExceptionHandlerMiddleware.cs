using EntityFramework.Exceptions.Common;
using Stores.BusinessLogic.Exceptions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Stores.Presentation.Middlewares;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public CustomExceptionHandlerMiddleware(RequestDelegate requestDelegate)
    {
            _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch(UniqueConstraintException ex)
        {
            await SetResponseAndStatusCode(context, StatusCodes.Status409Conflict, ex.Message);
        }
        catch (NotFoundException ex)
        {
            await SetResponseAndStatusCode(context, StatusCodes.Status404NotFound, ex.Message);
        }
        catch(Exception ex) 
        { 
            await SetResponseAndStatusCode(context, StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    public  Task SetResponseAndStatusCode(HttpContext context, int statuscode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statuscode;

        return context.Response.WriteAsJsonAsync(new { Error = message, StatusCode = statuscode });
    }
}
