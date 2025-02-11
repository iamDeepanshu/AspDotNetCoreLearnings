using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

                            // for HTTP Response HEADER

//app.Run(async (HttpContext context) =>
//{
//            
//    context.Response.StatusCode = 400;
//    context.Response.Headers["MyKey"] = "My Value";

//    // we use here html bcz we have used html tag in resp body
//    context.Response.Headers["Content-Type"] = "text/html";

//                              // for HTTP Response BODY

//    await context.Response.WriteAsync("<h1>Hello Deepanshu</h1>");
//    await context.Response.WriteAsync("<h2>Hello Deepanshu</h2>");
//});
//-------------------------------------------------------------------------------------

                            // for HTTP Request 

app.Run(async (HttpContext context) =>
{
    /** Request object contains the all the information about the request (like start line, request headers, request body).
    also Request.Path , property gives request URL, present after Method name in the start line.
    */

    //string path = context.Request.Path;

    //string method = context.Request.Method;// to read the method

    // if (path == "/path1") { }     //condition exmaple

   // context.Response.Headers["Content-Type"] = "text/html";
    
                    //  QUERY STRING

    //if(context.Request.Method == "GET")
    //{
    //    if(context.Request.Query.ContainsKey("id"))
    //    {
    //        string id = context.Request.Query["id"];
    //        await context.Response.WriteAsync($"<p>{id}</p>");
    //    }
    //}
                         //HTTP Request Header

    //if (context.Request.Headers.ContainsKey("User-Agent"))
    //{
    //    string userAgent = context.Request.Headers["User-Agent"];
    //    await context.Response.WriteAsync($"<p>{userAgent}</p>");
    //}

    //populating the value of  "path"  variable using, $
    //await context.Response.WriteAsync($"<p>{path}</p>");

    //await context.Response.WriteAsync($"<p>{method}</p>");


    //                 // checking POSTMAN
    //if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    //{
    //    string auth = context.Request.Headers["AuthorizationKey"];
    //    await context.Response.WriteAsync($"<p>{auth}</p>");
    //}

                       //  Post request using Postman and old long method
      StreamReader reader = new StreamReader(context.Request.Body);
      string body = await reader.ReadToEndAsync(); //to fully load the request body

     Dictionary<String, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if (queryDict.ContainsKey("firstName"))
    {
        string firstname = queryDict["firstName"][0];
        await context.Response.WriteAsync(firstname);
    }


});

app.Run();
