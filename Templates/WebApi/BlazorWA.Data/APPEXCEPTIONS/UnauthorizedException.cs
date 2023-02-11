using $safeprojectname$.Constants;
using System.Runtime.Serialization;

namespace $safeprojectname$.AppExceptions
{
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base(ErrorMessages.UNAUTHORIZED) { }
        public UnauthorizedException(string message) : base(message) { }
        public UnauthorizedException(string message, Exception inner) : base(message, inner) { }
        protected UnauthorizedException( SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
