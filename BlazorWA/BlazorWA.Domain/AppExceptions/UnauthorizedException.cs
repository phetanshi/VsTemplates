using BlazorWA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWA.Domain.AppExceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base(AppConstants.ErrorMessages.UNAUTHORIZED) { }
        public UnauthorizedException(string message) : base(message) { }
    }
}
