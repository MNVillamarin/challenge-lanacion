using Application.Exceptions;
using Application.Wrappers;
using LaNacion.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace LaNacion.Contact.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var idError = Guid.NewGuid();
                var response = httpContext.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                switch (ex)
                {
                    case ApiException e:
                        _logger.LogWarning(ex, ex.Message);
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        _logger.LogWarning(ex, ex.Message);
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        _logger.LogError(ex, $"Id Error: {idError.ToString().ToUpper()} - " + ex.Message);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Message = $"Internal Server Error. Contact Support. Id Error: {idError.ToString().ToUpper()}";
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
