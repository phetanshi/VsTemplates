using System.Runtime.Serialization;

namespace Ps.CleanWebApi.Infrastructure.Repository.Exceptions;

/// <summary>
/// This exception will be thrown if there are any repository specific error occurred
/// </summary>
[Serializable]
public class RepositoryException : Exception
{
    public RepositoryException() : base(RepositoryConstants.REPOSITORY_ERROR) { }
    public RepositoryException(string message) : base(message) { }
    protected RepositoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
