using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Globalization;
// using System.Diagnostics.CodeAnalysis;
using FileService;
using FileService.Interfaces;
using System.Threading.Tasks;

namespace pizza.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IFileService<string> _file;
        // private string path=@"C:\Users\user\Documents\לימודים-אביגיל\webapi\webapi-lesson6\webapi6\pizza\Actionlog.txt";
        public RequestMiddleware(RequestDelegate next,IFileService<string> file)
        {
            _next = next;
            _file= file;
        }

        public Task Invoke(HttpContext httpContext)
        {
            _file.Write(@"webapi6\pizza\Actionlog.txt","the time is: "+DateTime.UtcNow.ToString());
            _file.Write(@"webapi6\pizza\Actionlog.txt","the Httpmethod is: "+ httpContext.Request.Method.ToString());
            _file.Write(@"webapi6\pizza\Actionlog.txt","the body is: "+httpContext.Request.Body.ToString());
            _file.Write(@"webapi6\pizza\Actionlog.txt","the header is: "+ httpContext.Request.Headers.ToString());
            var task=_next(httpContext);
            _file.Write(@"webapi6\pizza\Actionlog.txt","the time is: "+DateTime.UtcNow.ToString());
            _file.Write(@"webapi6\pizza\Actionlog.txt","the statuscode: "+httpContext.Response.StatusCode.ToString());

            return task;

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder Userc(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMiddleware>();
        }
    }
}
