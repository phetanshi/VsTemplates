using Ps.CleanWebApi.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ps.CleanWebApi.Infrastructure.Repository.Abstractions;

/// <summary>
/// Provides repository methods to update data in a database table.
/// To use this interface, the database mode should inherit from the DatabaseBaseEntity class
/// These methods will take care of assigning values for UpdatedBy, UpdatedDateTime properties
/// </summary>
public interface IUpdateData
{
    #region Update

    #region Sync
    /// <summary>
    /// This method updates a record with the latest data being sent to it and automatically sets 'updated by' and 'updated date' to the current UTC date-time in the database. 
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="entity">An object with updated values, where the primary key value should be present.</param>
    /// <param name="loginUserId">Login user Id</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    int Update<T, TKey>(T entity, string loginUserId) where T : DatabaseBaseEntity<TKey>;
    /// <summary>
    /// This method updates a list of records with the latest data being sent to it and automatically sets 'updated by' and 'updated date' to the current UTC date-time in the database.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="entities">A list of objects with updated values, where the primary key value is present in each object.</param>
    /// <param name="loginUserId">Login user Id</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    int Update<T, TKey>(List<T> entities, string loginUserId) where T : DatabaseBaseEntity<TKey>;

    #endregion

    #region Async
    /// <summary>
    /// (Async Method) This method updates a record with the latest data being sent to it and automatically sets 'updated by' and 'updated date' to the current UTC date-time in the database. 
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="entity">An object with updated values, where the primary key value should be present.</param>
    /// <param name="loginUserId">Login user Id</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<int> UpdateAsync<T, TKey>(T entity, string loginUserId) where T : DatabaseBaseEntity<TKey>;

    /// <summary>
    /// (Async Method) This method updates a list of records with the latest data being sent to it and automatically sets 'updated by' and 'updated date' to the current UTC date-time in the database.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="entities">A list of objects with updated values, where the primary key value is present in each object.</param>
    /// <param name="loginUserId">Login user Id</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    Task<int> UpdateAsync<T, TKey>(List<T> entities, string loginUserId) where T : DatabaseBaseEntity<TKey>;
    #endregion

    #endregion
}
