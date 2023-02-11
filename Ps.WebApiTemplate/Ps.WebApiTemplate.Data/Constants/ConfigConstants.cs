using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ps.WebApiTemplate.Data.Constants
{
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
