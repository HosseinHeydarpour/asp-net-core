var builder = WebApplication.CreateBuilder(args);


//builder.Configuration

var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    string method = context.Request.Method;

    context.Response.Headers["Content-Type"] = "text/html";



    
        if (context.Request.Headers.ContainsKey("User-Agent")) {
            string userAgent = context.Request.Headers["User-Agent"];
            await context.Response.WriteAsync($"<p style='color: blue; font-size:32px;'>{userAgent}</p> ");
        }
    
    
 
});





app.Run();
