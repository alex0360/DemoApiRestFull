using Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, Serilog.ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                var response = context.Response;

                response.ContentType = "application/json";

                var responseModel = new Response<string> { Success = false, Message = exception?.Message };

                switch(exception)
                {
                    case Application.Exceptions.ApiException e:

                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        _logger.Warning(exception, e.Message);

                    break;

                    case Application.Exceptions.ValidationException e:

                        response.StatusCode = (int)HttpStatusCode.NotAcceptable;

                        responseModel.Errors = e.Errors;

                         _logger.Warning(exception, e.Errors.ToString());

                    break;

                    case KeyNotFoundException e:

                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        _logger.Warning(exception, e.Message);

                    break;

                    default:

                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        _logger.Error(exception, messageTemplate: exception.Message);

                    break;
                }

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}