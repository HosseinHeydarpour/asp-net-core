

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

Dictionary<int, string> countries = new Dictionary<int, string>()
{
    {1, "United States" },
    {2, "Canada" },
    {3, "United Kindom" },
    {4, "India" },
    {5, "Japan" },

};

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("countries", async context =>
    {
        foreach (var country in countries)
        {
            await context.Response.WriteAsync($"{country.Key}, {country.Value}\n");
        } 
    });

    endpoints.MapGet("countries/{countryID:int:range(1,100)}", async context =>
    {
        int countryID = Convert.ToInt32(context.Request.RouteValues["countryID"]);
       
            if (countries.ContainsKey(countryID))
            {
                await context.Response.WriteAsync($"{countries[countryID]}");
            } else
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync($"Oops... No Country");
            }
        
    });


    endpoints.MapGet("countries/{countryID:int:min(101)}", async context =>
    {
      

        context.Response.StatusCode = 400;

        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
    });


});



app.Run( async context =>
{ 
    context.Response.StatusCode = 404;
  
    await context.Response.WriteAsync($"Oops... No response | route you requested: {context.Request.Path}");
});


app.Run();
