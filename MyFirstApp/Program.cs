var builder = WebApplication.CreateBuilder(args);


//builder.Configuration

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
