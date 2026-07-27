using Microsoft.Extensions.Primitives;
using MyFirstApp.CustomConstraints;
using System.IO;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months",typeof(MonthsCustomConstraint));
});

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


    //endpoints.Map("employee/profile/{employeeName:minlength(3):maxlength(7)?}", async (context) =>
    endpoints.Map("employee/profile/{employeeName:length(3,7):alpha?}", async (context) =>
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
    //endpoints.Map("products/details/{prodId:int:min(1):max(1000)?}", async (context) =>
    endpoints.Map("products/details/{prodId:int:range(1,1000)?}", async (context) =>
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



    // Eg: sales-report/2030/apr : just accept april, july, october, january
    // The official documetaion suggests not using constraints too much instead accept bad requests 
    //endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>
    //{
    //    int year = Convert.ToInt32(context.Request.RouteValues["year"]);
    //    string? month = Convert.ToString(context.Request.RouteValues["month"]);

    //    switch (month)
    //    {
    //        case "apr":
    //           await context.Response.WriteAsync($"Getting April sales report for year: {year} ");
    //           break;
    //        case "jul":
    //            await context.Response.WriteAsync($"Getting July sales report for year: {year} ");
    //            break;
    //        case "oct":
    //            await context.Response.WriteAsync($"Getting October sales report for year: {year} ");
    //            break;
    //        case "jan":
    //            await context.Response.WriteAsync($"Getting January sales report for year: {year} ");
    //            break;

    //    }

    //});

    // This is the recomended way according to the doccuments - do not use constraints to validate!
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]).ToLower();

        if(month== "apr" || month == "jul" || month == "oct" || month == "jan")
        {
            await context.Response.WriteAsync($"Getting {month} sales report for year: {year} ");
        } else
        {
            if (context.Response.StatusCode == 200)
            {
                context.Response.StatusCode = 400;
            }
            await context.Response.WriteAsync($"Bad Request... | Only  april, july, october, january are accepted. ");
        }

    });




});

app.Run(async context =>
{
    await context.Response.WriteAsync($"No Route Matched at {context.Request.Path}");
});

app.Run();
