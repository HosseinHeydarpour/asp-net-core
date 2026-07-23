using Microsoft.Extensions.Primitives;
using MyFirstApp.CustomMiddleware;
using System.IO;


var builder = WebApplication.CreateBuilder(args);



var app = builder.Build();


app.Run();
