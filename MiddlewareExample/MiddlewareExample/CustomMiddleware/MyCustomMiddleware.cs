
namespace MiddlewareExample.CustomMiddleware
{
    //this is custom middleware class, which implements IMiddleware interface
    public class MyCustomMiddleware : IMiddleware
    {
           // from the IMiddleware interface, we implemented interface below(ctrl+.)
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom Middleware 2 Starts->\n");
            await next(context);
            await context.Response.WriteAsync("Custom Middleware 2 Ends\n");
        }
    }

    public static class CustomMiddlewareExtension
    {
        // this method must be static method, then it only be designated as an extension method
        //injecting the method to the IApplicationBuilder type using "this"
        // and  "app" is the variable by which we can access this extension method
        // variable name can be different
        //"UseMyCustomMiddleware" method is injected to the "app" object.
        public static IApplicationBuilder UseMyCustomMiddleware( this IApplicationBuilder app)
        {
           // var app = app.UseMiddleware<MyCustomMiddleware>();
           //return app;

            return app.UseMiddleware<MyCustomMiddleware>(); //short-hand 
            //above statement works still same as working in Custom Middleware class i.e adding the  custom middleware to application request pipeline.
            
        }
    }
}
