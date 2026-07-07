var builder = WebApplication.CreateBuilder(args);


//builder.Configuration

var app = builder.Build();

app.Run(async (HttpContext context) =>
{


    context.Response.Headers["MyKeY"] = "MY value";
    context.Response.Headers["Server"] = "My Server[Dev]";
    context.Response.Headers["Content-Type"] = "text/html";




    await context.Response.WriteAsync("<h1>Hello</h1> ");
    await context.Response.WriteAsync("<h2>World</h2> ");




});





app.Run();
