using Ps.CleanWebApi.Infrastructure.Entities;
using System.Linq.Expressions;

namespace Ps.CleanWebApi.Infrastructure.Repository.Abstractions;

/// <summary>
/// Provides repository methods to fetch data from database.
/// To use this interface, the database mode should inherit from the DatabaseBaseEntity class
/// </summary>
public interface IGetData
{
    #region GetManyItems

    #region Sync
    /// <summary>
    /// Retrieves a list of items from the database. Returns all records in the table if isActiveOnly is false; otherwise, returns only active records in the table.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true.</param>
    /// <returns>IQueryable of T - </returns>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    IQueryable<T> GetManyItems<T, TKey>(bool isActiveOnly = true) where T : DatabaseBaseEntity<TKey>;
    /// <summary>
    /// Retrieves a list of items from the database that match the given criteria.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate">search criteria for whare clause</param>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <returns>IQueryable of T</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    IQueryable<T> GetManyItems<T, TKey>(Expression<Func<T, bool>> predicate, bool isActiveOnly = true) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Retrieves a list of items from the database whose primary keys are present in the given list of IDs.
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="ids">List of primary key values</param>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <returns>IQueryable of T</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    IQueryable<T> GetManyItems<T, TKey>(bool isActiveOnly = true, params TKey[] ids) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #region Async

    /// <summary>
    /// (Async Method) Retrieves a list of items from the database. Returns all records in the table if isActiveOnly is false; otherwise, returns only active records in the table.
    /// </summary>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <returns>Task of IQueryable of T</returns>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<IQueryable<T>> GetManyItemsAsync<T, TKey>(bool isActiveOnly = true) where T : DatabaseBaseEntity<TKey>;
    /// <summary>
    /// Retrieves a list of items from the database that match the given criteria. (Async Method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate">search criteria for whare clause</param>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <returns>Task of IQueryable of T</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<IQueryable<T>> GetManyItemsAsync<T, TKey>(Expression<Func<T, bool>> predicate, bool isActiveOnly = true) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Retrieves a list of items from the database whose primary keys are present in the given list of IDs (Async Method).
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="ids">List of primary key values</param>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <returns>IQueryable of T</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<IQueryable<T>> GetManyItemsAsync<T, TKey>(bool isActiveOnly = true, params TKey[] ids) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #endregion

    #region GetAnItem

    #region Sync
    /// <summary>
    /// Fetches a single object that matches the given ID (primary key).
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="id">Primary key value of a table</param>
    /// <returns>Single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    T GetAnItem<T, TKey>(TKey id) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Fetches a single object that matches the given composite keys.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="compositeKey"> combination of  composite key values</param>
    /// <returns>Single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    T GetAnItem<T, TKey>(params object[] compositeKey) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Fetches a single object that matches the given criteria.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate">search criteria for whare clause</param>
    /// <returns>Single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    T GetAnItem<T, TKey>(Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #region Async
    /// <summary>
    /// Fetches a single object that matches the given ID (primary key) (Async method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="id">Primary key of a table</param>
    /// <returns>single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<T> GetAnItemAsync<T, TKey>(TKey id) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Fetches a single object that matches the given composite keys. (Async Method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="compositeKey"> combination of  composite key values</param>
    /// <returns>single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<T> GetAnItemAsync<T, TKey>(params object[] compositeKey) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Fetches a single object that matches the given criteria. (Async method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate">search criteria for whare clause</param>
    /// <returns>single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<T> GetAnItemAsync<T, TKey>(Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #endregion
}