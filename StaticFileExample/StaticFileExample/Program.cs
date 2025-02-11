// if we change the name of wwwroot name, then we have configure the default settings in  WebApplication.CreateBuilder(args);  to recognize the folder

// but also we have to create a dummy "wwwroot" folder to run the custom-root folder, if it is not there then we will have an exception
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    // this works only for one custom folder
    WebRootPath = "myroot"   //set the path by giving folder name
});

// if a static files contains in more than one folder then that "UseStaticFile()" middleware executed which will occur at first

var app = builder.Build();

app.UseStaticFiles(); // works with web root path i.e. (myroot)

// for Multiple wwwroot folder
app.UseStaticFiles(new StaticFileOptions(){
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath,"mywebroot"))
    //  using concatination
    // new PhysicalFileProvider(builder.Environment.ContentRootPath+"\\mywebroot")

    //StaticFileOptions(){} --> it is a property
    //  ContentRootPath --> represents the current working directory path
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello");
    });
});

app.Run();
