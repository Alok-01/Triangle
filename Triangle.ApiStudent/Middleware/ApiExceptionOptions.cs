using Microsoft.AspNetCore.Http;
using System;

namespace Triangle.ApiStudent.Middleware
{
    public class ApiExceptionOptions
    {
        public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }
    }
}
