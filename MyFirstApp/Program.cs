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
        if (context.Request.Query.ContainsKey("id")) {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p style='color: blue; font-size:32px;'>{id}</p> ");
        }
    }
    await context.Response.WriteAsync($"<p style='color: red; font-size:32px;'>{path}</p> ");
 
});





app.Run();
