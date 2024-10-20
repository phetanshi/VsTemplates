using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ps.CleanWebApi.Infrastructure.Repository.Exceptions;

namespace Ps.CleanWebApi.Infrastructure.Repository.Concrete;

/// <summary>
/// Base class for repository classes
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class RepositoryBase<T>(DbContext database, ILogger<T> logger)
{
    protected DbContext Database { get; } = database;
    protected ILogger<T> AppLog { get; } = logger;

    protected void ThrowBasicErrorsIfRequired()
    {
        AppLog.LogDebug("Entered into the method RepositoryBase.ThrowBasicErrorsIfRequired with only parameter object overload method");
        if (Database == null)
            throw new RepositoryException(RepositoryConstants.CONTEXT_OBJECT_NULL);

        AppLog.LogDebug("Returning from the method RepositoryBase.ThrowBasicErrorsIfRequired with only parameter object overload method");
    }

    protected void ThrowBasicErrorsIfRequired(object parameter)
    {
        AppLog.LogDebug("Entered into the method RepositoryBase.ThrowBasicErrorsIfRequired with only parameter object overload method");
        if (Database == null)
            throw new RepositoryException(RepositoryConstants.CONTEXT_OBJECT_NULL);

        if (parameter is null)
            throw new ArgumentNullException(string.Format(RepositoryConstants.ARGUMENT_NULL, nameof(parameter)));

        AppLog.LogDebug("Returning from the method RepositoryBase.ThrowBasicErrorsIfRequired with only parameter object overload method");
    }
    protected void ThrowBasicErrorsIfRequired(string loginUserId, object parameter = null)
    {
        AppLog.LogDebug("Entered into the method RepositoryBase.ThrowBasicErrorsIfRequired with login user id and parameter object overload method");
        ThrowBasicErrorsIfRequired(parameter);

        if (string.IsNullOrWhiteSpace(loginUserId))
            throw new ArgumentNullException(string.Format(RepositoryConstants.ARGUMENT_NULL, nameof(loginUserId)));

        AppLog.LogDebug("Returning from the method RepositoryBase.ThrowBasicErrorsIfRequired with login user id and parameter object overload method");
    }
}
