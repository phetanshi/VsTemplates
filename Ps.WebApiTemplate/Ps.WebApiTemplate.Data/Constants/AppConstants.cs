using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ps.WebApiTemplate.Data.Constants
{
    public static class AppConstants
    {
        public const string AuthenticationType = "JwtServerAuth";
        public const int ExpiryTimeInMinutes = 60;
        public const string SUCCESS = "Success!";
        public const string TOKEN_EXPIRED = "Authentication token expired!";
        public const string TOKEN_NOT_EXPIRED = "Authentication token is still alive!";
    }
}
