namespace MyFirstApp.CustomMiddleware
{

    // This is a way to conver any class to middleware without extendig IMiddleWare interface
    public class MyCustomMiddleware 
    {

        private readonly RequestDelegate _next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }




        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello MIDDLEWARE 2 - Custom \n");
            await _next(context);
            await context.Response.WriteAsync("Hello MIDDLEWARE 2 Back way - Custom \n");

        }

        
    }


    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
