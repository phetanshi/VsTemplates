using Ps.CleanWebApi.Infrastructure.Entities;

namespace Ps.CleanWebApi.Infrastructure.Repository.Abstractions;

/// <summary>
/// Provides repository methods to insert records in database.
/// To use this interface, the database model should inherit from the DatabaseBaseEntity class
/// These methods will take care of assigning values for CreatedBy, CreatedDateTime, IsActive properties
/// </summary>
public interface ICreateData
{
    #region Create

    #region Sync
    /// <summary>
    /// Inserts a new record into the specified table.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="entity">The object that needs to be inserted into the database</param>
    /// <param name="loginUserId">Login user Id</param>
    /// <returns>The method returns the saved entity with automatically generated data, if any</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    T Create<T, TKey>(T entity, string loginUserId) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Inserts a list of new records into the specified table.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="entityList">The list of objects that need to be inserted into the database.</param>
    /// <param name="loginUserId">Login user Id</param>
    /// <returns>The method returns the saved entities with automatically generated data, if any</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    List<T> Create<T, TKey>(List<T> entityList, string loginUserId) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #region Async
    /// <summary>
    /// Inserts a new record into the specified table.(Async Method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="entity">The object that needs to be inserted into the database</param>
    /// <param name="loginUserId">Login user Id</param>
    /// <returns>object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<T> CreateAsync<T, TKey>(T entity, string loginUserId) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Inserts a list of new records into the specified table. (Async Method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="entityList">The list of objects that need to be inserted into the database.</param>
    /// <param name="loginUserId">Login user Id</param>
    /// <returns>The method returns the saved entities with automatically generated data, if any</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<List<T>> CreateAsync<T, TKey>(List<T> entityList, string loginUserId) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #endregion
}
