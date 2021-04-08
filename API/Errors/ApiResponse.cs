using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetStatusCodeDefaultMessage(statusCode);
        }

        public int StatusCode { get; }
        public string Message { get; }
        private string GetStatusCodeDefaultMessage(int statusCode)
        {
            return StatusCode switch
            {
                400 => "Bad Request, you have made.",
                401 => "Authorized, you are not.",
                404 => "Resource found, it was not.",
                500 => "Internal server error has occurred",
                _ => null
            };
        }
    }

}