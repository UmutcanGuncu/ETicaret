using System.Net;
using System.Text.Json;
using FluentValidation;

namespace ETicaret.API.Extensions;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
   public async Task Invoke(HttpContext context)
   {
      try
      {
         await next(context); // diğer middleware'lere devam et
      }
      catch (ValidationException ex)
      {
         context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
         context.Response.ContentType = "application/json";

         var errors = ex.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
               g => g.Key,
               g => g.Select(e => e.ErrorMessage).ToArray()
            );

         var result = JsonSerializer.Serialize(new
         {
            Message = "Validation error(s) occurred.",
            Errors = errors
         });

         await context.Response.WriteAsync(result);
      }
      catch (Exception ex)
      {
         // Diğer tüm hatalar için genel bir handler
         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
         context.Response.ContentType = "application/json";

         var result = JsonSerializer.Serialize(new
         {
            Message = "Beklenmeyen bir hata oluştu.",
            Detail = ex.Message
         });

         await context.Response.WriteAsync(result);
      }
   
   }
}