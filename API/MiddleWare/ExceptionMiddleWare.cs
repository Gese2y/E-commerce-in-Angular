using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;
        private readonly RequestDelegate _next;
        public ExceptionMiddleWare(
        RequestDelegate next, 
        ILogger<ExceptionMiddleWare> logger,
        IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context){
           try
           {
await _next(context);
           }
           catch(Exception ex)
           {
_logger.LogError(ex, ex.Message);
context.Response.ContentType = "application/json";
context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

var response = _env.IsDevelopment()
? new ApiException((int)HttpStatusCode.InternalServerError,
ex.Message, ex.StackTrace.ToString())
: new ApiException((int)HttpStatusCode.InternalServerError);

var options = new JsonSerializerOptions{PropertyNamingPolicy = 
JsonNamingPolicy.CamelCase};

var json = JsonSerializer.Serialize(response,options);
await context.Response.WriteAsync(json);
           } 
        }
    }
}