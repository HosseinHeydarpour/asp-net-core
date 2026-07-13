using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);


//builder.Configuration

var app = builder.Build();

app.Run(async (HttpContext context) =>
{

    if(context.Request.Method=="GET" && context.Request.Path == "/")
    {
        int firstNumber = 0;
        int secondNumber = 0;   
        string? operation = null;
        long? result = null;

        StreamReader reader = new StreamReader(context.Request.Body);

        string body = await reader.ReadToEndAsync();

        Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
        
        if (queryDict.ContainsKey("firstNumber"))
        {
            if(!string.IsNullOrEmpty(queryDict["firstNumber"]))
            {
                firstNumber = int.Parse(queryDict["firstNumber"]);
            }

       

        } else
        {
            if(context.Response.StatusCode==200) context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid parameter: firstNumber missing\n");
            return;
        }

        if (queryDict.ContainsKey("secondNumber"))
        {
            if (!string.IsNullOrEmpty(queryDict["secondNumber"]))
            {
                secondNumber = int.Parse(queryDict["secondNumber"]);
            }

        

        }
        else
        {
            if (context.Response.StatusCode == 200) context.Response.StatusCode = 400;

            await context.Response.WriteAsync("Invalid parameter: seconNumber missing\n");
            return;
        }

        if (queryDict.ContainsKey("operation"))
        {
            operation = queryDict["operation"];
          

            switch (operation)
            {
                case "multiply":
                    result = firstNumber * secondNumber;
                    await context.Response.WriteAsync(Convert.ToString("Result is: "+result));
                    break;
                case "plus": 
                    result = firstNumber + secondNumber;
                    await context.Response.WriteAsync(Convert.ToString("Result is: " + result));
                    break;
                case "minus": 
                    result = firstNumber - secondNumber;
                    await context.Response.WriteAsync(Convert.ToString("Result is: " + result));
                    break;
                case "divide":
                    result = firstNumber / secondNumber;
                    await context.Response.WriteAsync(Convert.ToString("Result is: " + result));
                    break;
                default:
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid Operator");
                    break;
            }
        }






    } else
    {
        context.Response.StatusCode = 405; // Method Not Allowed
        await context.Response.WriteAsync("Invalid Path or invalid Method! Use POST on '/'");
    }
     
    
 
});





app.Run();
