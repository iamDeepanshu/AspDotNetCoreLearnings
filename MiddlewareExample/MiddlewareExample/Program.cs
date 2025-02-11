using Microsoft.AspNetCore.Http;
using MiddlewareExample.CustomMiddleware; //importing custom middleware file/class

var builder = WebApplication.CreateBuilder(args);

//registering the custom middleware class as middleware
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();



//Middleware 1
// we used here, app.Use() ,  to create middleware chain
 app.Use(async(HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("From 1st Middleware->\n ");
    await next(context);    //calling the subsequent middleware

});

//Middleware 2//  app.Use(), to create middleware chain [ datatypes are optional]
//
//app.Use(async ( context, next) =>
//{
//    await context.Response.WriteAsync("Avi..");
//    await next(context);    //calling the subsequent middleware
//});

                        // Middleware 2
// this is by using "custom middleware" i.e. custom middleware class
//app.UseMiddleware<MyCustomMiddleware>();

                       //Middleware 2
////this is by using "custom middleware Extension"
//app.UseMyCustomMiddleware();

                    // Middleware 2 (by prefered and new way-> Custom Convention Middleware class)
    app.UseNameCustomMiddleware();



            //Middleware 3, here app.Run() , is a short circuit or terminating middleware
app.Run(async(HttpContext context) =>
{
    await context.Response.WriteAsync(" From 3rd Middleware.-> \n");
});

app.Run();
