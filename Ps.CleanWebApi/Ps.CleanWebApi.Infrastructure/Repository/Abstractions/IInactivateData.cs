using Ps.CleanWebApi.Infrastructure.Entities;
using System.Linq.Expressions;

namespace Ps.CleanWebApi.Infrastructure.Repository.Abstractions;

/// <summary>
/// Provides repository methods to inactivate records in a database table. It updates IsActive column to false.
/// To use this interface, the database mode should inherit from the DatabaseBaseEntity class
/// These methods will take care of assigning values for UpdatedBy, UpdatedDateTime, IsActive properties
/// </summary>
public interface IInactivateData
{
    #region Inactivate

    #region Sync
    /// <summary>
    /// This method will soft delete (inactivate) all records in the provided table.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    int Inactivate<T, TKey>(string loginUserId) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Soft delete (inactivate) all records in the given table whose primary key values match the provided ID.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="Id">Primary key value of the record</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    int Inactivate<T, TKey>(TKey Id, string loginUserId) where T : DatabaseBaseEntity<TKey>;
    /// <summary>
    /// Soft delete (inactivate) all records in the given table whose IDs are contained in the provided list of IDs.
    /// </summary>
    /// <typeparam name="T">Table Name</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="Ids">List of primary key values</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    int Inactivate<T, TKey>(List<TKey> Ids, string loginUserId) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// Soft delete (Inactivate) all records in the given table that match the provided criteria.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="predicate">selection criteria</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    int Inactivate<T, TKey>(string loginUserId, Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #region Async
    /// <summary>
    /// (Async method) Soft delete (Inactivate) all records in the provided table.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<int> InactivateAsync<T, TKey>(string loginUserId) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// (Async method) Soft delete (Inactivate) all records in the given table whose primary key values match the provided ID.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="Id">Primary key value</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<int> InactivateAsync<T, TKey>(TKey Id, string loginUserId) where T : DatabaseBaseEntity<TKey>;
    /// <summary>
    /// (Async method) Soft delete (Inactivate) all records in the given table whose IDs are contained in the provided list of IDs.
    /// </summary>
    /// <typeparam name="T">Table Name</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="Ids">List of primary key values</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<int> InactivateAsync<T, TKey>(List<TKey> Ids, string loginUserId) where T : DatabaseBaseEntity<TKey>;
    /// <summary>
    /// (Async method) Soft delete (Inactivate) all records in the given table that match the provided criteria.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="predicate">selection criteria</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<int> InactivateAsync<T, TKey>(string loginUserId, Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #endregion
}
