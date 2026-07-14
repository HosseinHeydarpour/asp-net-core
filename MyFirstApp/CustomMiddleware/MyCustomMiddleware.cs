namespace MyFirstApp.CustomMiddleware
{

    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello MIDDLEWARE 2 - Custom \n");
            await next(context);
            await context.Response.WriteAsync("Hello MIDDLEWARE 2 Back way - Custom \n");

        }

        
    }
}
