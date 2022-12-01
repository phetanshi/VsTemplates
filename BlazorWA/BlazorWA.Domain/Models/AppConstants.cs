using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWA.Domain.Models
{
    public static class AppConstants
    {
        public static class ErrorMessages
        {
            public const string UNHANDLED_EXCEPTION = "Something went wrong at. Please contact site admin";
            public const string HTTP_CONTEXT_NOT_FOUND = "Http Context is null";
            public const string UNAUTHORIZED = "Unauthorized access to the api";
        }
        public static class Constants
        {
            public const string AuthenticationType = "JwtServerAuth";
            public const int ExpiryTimeInMinutes = 60;
        }
        public static class ConfigConstants
        {
            public static string JwtSecurityKey
            {
                get
                {
                    return "Authentication:JWTSettings:SecretKey";
                }
            }
        }
    }
}
