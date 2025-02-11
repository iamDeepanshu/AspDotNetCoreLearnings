var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddTransient<HomeController>();  //this one is for specific controller or if there is only specific

// to add all the controller as service, this below statement will automatically detects all the controller i.e class suffix with controller
builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();

            // these are optional statements
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//endpoints.MapControllers(); // enables the routing for each action method
//});

// instead of the above statements, we can use this, because  this will enable UseRouting() and UseEndpoints() internally and automatically
app.MapControllers();






//app.Run(async(HttpContext context) =>
//{
//    await context.Response.WriteAsync($"No action method is route to - {context.Request.Path}");
//});

app.Run();
