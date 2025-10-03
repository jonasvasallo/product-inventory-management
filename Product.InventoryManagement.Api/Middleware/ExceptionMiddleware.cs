using Microsoft.AspNetCore.Mvc;
using Product.InventoryManagement.Api.Models;
using Product.InventoryManagement.Application.Exceptions;
using System.Net;

namespace Product.InventoryManagement.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next; // dis represents the next action along the pipeline

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex) { 
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            ErrorResponseDetails problem = null;

            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new ErrorResponseDetails
                    {
                        Title = badRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.Message,
                        Type = nameof(BadRequestException),
                        Errors = badRequestException.ValidationErrors ?? new Dictionary<string, string[]>()
                    };
                    break;
                case NotFoundException notFound:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new ErrorResponseDetails
                    {
                        Title = notFound.Message,
                        Status = (int)statusCode,
                        Detail = notFound.InnerException?.Message,
                        Type = nameof(NotFoundException),
                    };
                    break;
                default:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new ErrorResponseDetails
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Detail = ex.StackTrace,
                        Type = nameof(HttpStatusCode.InternalServerError),
                    };
                    break;
            }
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
