using Microsoft.Extensions.Primitives;
using MyFirstApp.CustomMiddleware;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// enable routing
app.UseRouting();

// creating end-points
app.UseEndpoints(endpoints =>
{
    // add your end points - all methods which start with Map
    
});


app.Run();
