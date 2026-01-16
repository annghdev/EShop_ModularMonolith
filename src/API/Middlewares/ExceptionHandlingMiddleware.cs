using Contracts;
using FluentValidation;
using Kernel.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var role = context.User.IsInRole("coach");
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception for {Path}", context.Request.Path);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problem = new ProblemDetails
        {
            Instance = context.TraceIdentifier,
            Type = "about:blank"
        };

        var response = new ApiResponse();

        switch (exception)
        {
            case ValidationException validationException:
                problem.Status = StatusCodes.Status400BadRequest;
                problem.Title = "Dữ liệu không hợp lệ";
                problem.Detail = "Vui lòng kiểm tra lại dữ liệu gửi lên.";
                problem.Extensions["errors"] = validationException.Errors
                    .GroupBy(error => error.PropertyName)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Select(error => error.ErrorMessage).ToArray());
                break;

            case UnauthorizedAccessException unauthorizedAccessException:
                problem.Status = StatusCodes.Status401Unauthorized;
                problem.Title = "Xác thực thất bại";
                problem.Detail = "Dữ liệu người dùng có thể không hợp lệ";
                break;

            case NotFoundException notFoundException:
                problem.Status = notFoundException.StatusCode;
                problem.Title = "Không tìm thấy";
                problem.Detail = notFoundException.Message;
                break;

            case DuplicateException duplicateException:
                problem.Status = duplicateException.StatusCode;
                problem.Title = "Lỗi trùng lặp";
                problem.Detail = duplicateException.Message;
                break;

            case DomainException businessException:
                problem.Status = businessException.StatusCode;
                problem.Title = "Yêu cầu không hợp lệ";
                problem.Detail = businessException.Message;
                break;

            default:
                problem.Status = StatusCodes.Status500InternalServerError;
                problem.Title = "Lỗi hệ thống";
                problem.Detail = "Đã xảy ra lỗi không mong muốn, vui lòng thử lại sau.";
                break;
        }

        problem.Extensions["traceId"] = context.TraceIdentifier;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = problem.Status ?? StatusCodes.Status500InternalServerError;

        await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
    }
}

