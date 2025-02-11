using System.Text;
using Microsoft.AspNetCore.Identity;
using RoutingExample.CustromConstraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(option =>
{
    option.ConstraintMap.Add("months", typeof (MonthCustomConstraint));
});

var app = builder.Build();

            // using GetEndpoint

//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//    if (endPoint != null)
//    {
        
//        await context.Response.WriteAsync($"Map Endpoint: {endPoint.DisplayName}");
//    }
//    await next(context);
//});


                    // enables routing
app.UseRouting();

// creating end points
//-----------------------------------------------------------------------
//          // only for Map()

//app.UseEndpoints(endpoints => {
//    //add endpoints
//    endpoints.Map("map1",async (context) => {
//        await context.Response.WriteAsync("In Map1");
//    });

//    endpoints.Map("/map2", async (context) => {
//        await context.Response.WriteAsync("In Map2");
//    });

//});
//----------------------------------------------------------------------
//                //for MapGET() and MapPost()
//app.UseEndpoints(endpoints =>
//{
//                       //add  your endpoints

//    endpoints.MapGet("map1", async (context) =>
//    {
//        Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//        if (endPoint != null)
//        {
//            await context.Response.WriteAsync($"Map Endpoint: {endPoint.DisplayName} \n");
//        }

//        await context.Response.WriteAsync($"In Map1, path is { context.Request.Path} ");
//    });

//    endpoints.MapPost("/map2", async (context) =>
//    {
//        Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//        if (endPoint != null)
//        {
//            await context.Response.WriteAsync($"Map Endpoint: {endPoint.DisplayName} \n");
//        }
//        await context.Response.WriteAsync("In Map2");
//    });

//});

//-----------------------------------------------------------------


                        //  using Route Parameters
app.UseEndpoints(endpoint =>
{
endpoint.Map("files/{filename}.{extension}", async context =>
{
    string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
    //context.Request.RouteValues["filename"], this is of System.Object type, therefore to be converted into valid datatype

    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
    await context.Response.WriteAsync($"in files: {filename} . {extension}");
});

endpoint.Map("employee/profile/{empname}", async context =>
{
    string? empname = Convert.ToString(context.Request.RouteValues["empname"]);
    await context.Response.WriteAsync($"In profile : {empname}");
});

                    // using default value 
                    // eg, for prodcut/details/
endpoint.Map("product/details/{id=1}", async context =>
{
    int id = Convert.ToInt32(context.Request.RouteValues["id"]);
    await context.Response.WriteAsync($"Product id is : {id}");
});


                    // using OPTIONAL PARAMETER,using ? 
                    // eg, for class/rollno?/ 

endpoint.Map("class/rollno/{roll?}", async context =>
{
    if (context.Request.RouteValues.ContainsKey("roll"))  //checking for null value
    {
        int rollNo = Convert.ToInt32(context.Request.RouteValues["roll"]);
        await context.Response.WriteAsync($"Student roll no is : {rollNo}");
    }
    else
    {
        await context.Response.WriteAsync("Student id is not supplied");
    }
});
                    // using ROUTE CONSTRAINTS 
endpoint.Map("student-attendance-report/{reportdate:datetime}", async context =>
{
    DateTime reportDateTime = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
    await context.Response.WriteAsync($"Date of Attendance is : {reportDateTime.ToShortDateString()}");
    // ToShortDateString() , this will convert the date into short date string i.e. without time.
});
                            //using GUID
endpoint.Map("city/{cityid:guid}",async context =>
{
    Guid cityId= Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
    //here ! is for that the value cant be null i.e. for empty string
    await context.Response.WriteAsync($"City ID is : {cityId}");
});

    //  more than one constraints
    endpoint.Map("customer/bill/{billno:int:minlength(2):min(10):?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("billno"))
        {
            int billNo = Convert.ToInt32(context.Request.RouteValues["billno"]);
            await context.Response.WriteAsync($"Bill no is : {billNo}");
        }
        else
        {
            await context.Response.WriteAsync("Bill no is not supplied");
        }
    });
                //      using regex expression, also using custom constraint "months"

    endpoint.Map("sales-report/{year:int:length(4):min(1999)}/{month:months}", async context=> {
        int? year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        if (month == "apr" || month == "jul" || month == "oct" || month == "dec")
        {
            await context.Response.WriteAsync($"Sales report of year-{year} and month-{month} using custom constraint");
        }
        else 
        {
            await context.Response.WriteAsync($" {month} month is not allowed for sales report");
        }
    });

    //  Endpoit Selection order (precedence, which endpoint will be executed)

    endpoint.Map("sales-report/2024/jan", async context =>
    {
        await context.Response.WriteAsync("Sales report  exclusively for jan 2024");
    });


});
           
app.Run(async context =>
{
    await context.Response.WriteAsync($"No Route is matched at {context.Request.Path}");

});


app.Run();
