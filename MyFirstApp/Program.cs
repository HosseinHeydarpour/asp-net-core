using MyFirstApp.Controllers;

var builder = WebApplication.CreateBuilder(args);

// This is not good for big projects
//builder.Services.AddTransient<HomeController>();

// This will automatically detected all classes with Controller suffix and add them
builder.Services.AddControllers(); // Adds all the controller classes as Services

var app = builder.Build();



// =============================

//app.UseRouting();

//app.UseEndpoints(
//   endpoints =>
//   {
//       endpoints.MapControllers();
//   } 
//);

// this will do the jpb of app.UseRouting(); and app.UseEndpoints() 
app.MapControllers();

// =============================

app.Run();
