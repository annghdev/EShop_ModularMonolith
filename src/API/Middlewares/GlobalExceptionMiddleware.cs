using Contracts;
using FluentValidation;
using Kernel.Domain;
using System.Text.Json;

namespace API.Middlewares;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var role = context.User.IsInRole("coach");
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception for {Path}", context.Request.Path);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new ApiResponse();
        response.IsSuccess = false;

        switch (exception)
        {
            case ValidationException validationException:
                var errors = validationException.Errors
                    .GroupBy(error => error.PropertyName)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Select(error => error.ErrorMessage).ToArray());

                response.Message = "Dữ liệu không hợp lệ";
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.ErrorDetails = JsonSerializer.Serialize(errors);
                break;

            case UnauthorizedAccessException unauthorizedAccessException:
                response.StatusCode = StatusCodes.Status401Unauthorized;
                response.Message = "Xác thực thất bại";
                response.ErrorDetails = "Dữ liệu người dùng có thể không hợp lệ";
                break;

            case NotFoundException notFoundException:
                response.StatusCode = notFoundException.StatusCode;
                response.Message = "Không tìm thấy";
                response.ErrorDetails = notFoundException.Message;
                break;

            case DuplicateException duplicateException:
                response.StatusCode = duplicateException.StatusCode;
                response.Message = "Lỗi trùng lặp";
                response.ErrorDetails = duplicateException.Message;
                break;

            case DomainException businessException:
                response.StatusCode = businessException.StatusCode;
                response.Message = "Yêu cầu không hợp lệ";
                response.ErrorDetails = businessException.Message;
                break;

            default:
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Message = "Lỗi hệ thống";
                response.ErrorDetails = "Đã xảy ra lỗi không mong muốn, vui lòng thử lại sau.";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.StatusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
