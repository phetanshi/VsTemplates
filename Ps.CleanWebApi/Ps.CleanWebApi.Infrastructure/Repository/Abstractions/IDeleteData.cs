using Ps.CleanWebApi.Infrastructure.Entities;
using System.Linq.Expressions;

namespace Ps.CleanWebApi.Infrastructure.Repository.Abstractions;

public interface IDeleteData
{
    #region Delete

    #region Sync
    /// <summary>
    /// This method deletes a record from the database table whose primary key value matches the given ID.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="id">Uniquely identified key value (primary key)</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    int Delete<T, TKey>(TKey id) where T : DatabaseBaseEntity<TKey>;
    /// <summary>
    /// This method deletes a list of records whose primary keys match the given IDs
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="ids">primary key values array</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    int Delete<T, TKey>(params TKey[] ids) where T : DatabaseBaseEntity<TKey>;
    /// <summary>
    /// This method deletes all records that match the given criteria.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    int Delete<T, TKey>(Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>;

    #endregion

    #region Async
    /// <summary>
    /// This method deletes a record from the database table. (Async method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="id">Uniquely identified key value (primary key)</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<int> DeleteAsync<T, TKey>(TKey id) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// This method deletes a list of records whose primary keys match the given IDs (Async Method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="ids">primary key values array</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<int> DeleteAsync<T, TKey>(params TKey[] ids) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// This method deletes all records that match the given criteria. (Async)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<int> DeleteAsync<T, TKey>(Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #endregion
}
