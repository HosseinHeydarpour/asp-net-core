using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

using System.IO;


var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    Args = args,
    WebRootPath = "myroot",

});


var app = builder.Build();


app.UseStaticFiles(); // works with the web root path (myroot)


// contexnt root path: --> example c:/apsnetcore/...

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
       Path.Combine(builder.Environment.ContentRootPath , "mywebroot")
    )
}); // works with "mywebroot"

app.UseRouting();




app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello"); 
    });
});



app.Run();
