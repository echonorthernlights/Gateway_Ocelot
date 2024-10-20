using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Gateway.Middlewares
{



    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Post && context.Request.Path.Value.Contains("/gateway/auth"))
            {
                context.Request.EnableBuffering();

                // Read the request body
                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;

                // Parse the JSON body
                var payload = JObject.Parse(body);

                // Determine if it's a register or login request
                if (payload.ContainsKey("email"))
                {
                    context.Request.Headers["X-Request-Type"] = "Register";
                    Console.WriteLine("Register request detected.");
                }
                else
                {
                    context.Request.Headers["X-Request-Type"] = "Login";
                    Console.WriteLine("Login request detected.");
                }
            }

            await _next(context);
        }
    }



}






