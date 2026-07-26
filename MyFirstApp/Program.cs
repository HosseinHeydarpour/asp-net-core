using Microsoft.Extensions.Primitives;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// enable routing
app.UseRouting();

// creating end-points
app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{fileName}.{fileExtension}", async context =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["fileName"]);
        string? fileExtension = Convert.ToString(context.Request.RouteValues["fileExtension"]);
        await context.Response.WriteAsync($"In Files | requested file name: '{fileName}' | requested file extension: '{fileExtension}'");
    });


    endpoints.Map("employee/profile/{employeeName?}", async (context) =>
    {

        if(context.Request.RouteValues.ContainsKey("employeeName"))
        {
            string employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
            await context.Response.WriteAsync($"In Employee profile | requested employee name: '{employeeName}'");
        } else
        {
            await context.Response.WriteAsync($"Please provide the employee name...");
        }

   

    
    });

    // Eg: products/details/1
    endpoints.Map("products/details/{prodId:int?}", async (context) =>
    {
      

        if(context.Request.RouteValues.ContainsKey("prodId"))
        {
            int productId = Convert.ToInt32(context.Request.RouteValues["prodId"]);
          
            await context.Response.WriteAsync($"Details of product with id: {productId}");
        } else
        {
            await context.Response.WriteAsync($"No Id is provided, please provide an ID");
        }

        

    });

    // Eg: daily-digest-report/{reportDate}
    endpoints.Map("daily-digest-report/{reportDate:datetime}",async (context) =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportDate"]);

        await context.Response.WriteAsync($"In daily-digest-report - {reportDate.ToShortDateString()}");

    });

    //Eg: cities/cityId
    endpoints.Map("/cities/{cityId:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityId"])!);

        await context.Response.WriteAsync($"City information - {cityId}");
    });

   
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request recieved at {context.Request.Path}");
});

app.Run();
