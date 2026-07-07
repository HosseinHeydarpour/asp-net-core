var builder = WebApplication.CreateBuilder(args);


//builder.Configuration

var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    //context.Response.StatusCode = 400;

    if(1 == 1)
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("Success ");
        
    } else
    {
        context.Response.StatusCode = 400;
        // response body
        await context.Response.WriteAsync("Bad ");
        await context.Response.WriteAsync("Request!!");

    }




});





app.Run();
