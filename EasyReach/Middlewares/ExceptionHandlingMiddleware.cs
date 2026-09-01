using EasyReach_Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace EasyReach.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An exception occurred: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new ApiResponse();

            switch (exception)
            {
                // 🚀 ১. বিজনেসরুল / ভ্যালিডেশন এরর (Email already registered, Passwords do not match ইত্যাদি)
                case InvalidOperationException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest; // 400
                    response.Message = ex.Message;
                    break;

                // 🚀 ২. আন-অথেনটিকেটেড এরর
                case UnauthorizedAccessException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized; // 401
                    response.Message = string.IsNullOrWhiteSpace(ex.Message) ? "Unauthorized access." : ex.Message;
                    break;

                case UserNotFoundException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized; // 401
                    response.Message = ex.Message;
                    break;

                case ProductNotFoundException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest; // 400
                    response.Message = ex.Message;
                    break;

                // 🚀 ৩. সিস্টেমের অনাকাঙ্ক্ষিত কোনো ক্র্যাশ/বাগ হলে তবেই ৫০০ হবে
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500
                    response.Message = "An unexpected error occurred. Please try again later or contact support.";
                    break;
            }

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }

    public class ApiResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}

