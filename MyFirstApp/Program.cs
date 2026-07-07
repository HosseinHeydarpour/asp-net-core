var builder = WebApplication.CreateBuilder(args);


//builder.Configuration

var app = builder.Build();

app.Run(async (HttpContext context) =>
{



    



    string path = context.Request.Path;
    string method = context.Request.Method;

    context.Response.Headers["Content-Type"] = "text/html";

    if (method == "GET") 
    {
        await context.Response.WriteAsync($"<p style='color: red; font-size:32px;'>{method}</p> ");
    }


    if(path == "/path1")
    {
        await context.Response.WriteAsync($"<h1 style='color: red; font-size:32px;'>PATH 1 ENABLED</h1> ");
        //await context.Response.WriteAsync($"<p style='color: green; font-size:32px;'>{method}</p> ");

    } else
    {
        await context.Response.WriteAsync($"<p style='color: red; font-size:32px;'>{path}</p> ");
        //await context.Response.WriteAsync($"<p style='color: green; font-size:32px;'>{method}</p> ");
    }

    



});





app.Run();
