using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ps.CleanWebApi.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ps.CleanWebApi.Infrastructure.Repository.Concrete;

public class AppRepository(DbContext database, ILogger<AppRepository> logger) : RepositoryBase<AppRepository>(database, logger), IRepository
{
    #region GetManyItems

    #region Sync
    /// <summary>
    /// <see cref="IStandardGetData.GetManyItems{T, TKey}(bool)"/>
    /// </summary>
    public IQueryable<T> GetManyItems<T, TKey>(bool isActiveOnly = true) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.GetList");
        ThrowBasicErrorsIfRequired();
        var result = Database.Set<T>().Where(x => isActiveOnly ? x.IsActive == true : true);
        AppLog.LogDebug("Returning from the method StandardRepository.GetList");
        return result;
    }
    /// <summary>
    /// Retrieves a list of items from the database that match the given criteria.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <param name="predicate"></param>
    /// <returns>IQueryable of T</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public IQueryable<T> GetManyItems<T, TKey>(Expression<Func<T, bool>> predicate, bool isActiveOnly = true) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.GetList with predicate parameter");
        ThrowBasicErrorsIfRequired(predicate);
        var result = Database.Set<T>().Where(predicate).Where(x => isActiveOnly ? x.IsActive == true : true);
        AppLog.LogDebug("Returning from the method StandardRepository.GetList with predicate parameter");
        return result;
    }

    /// <summary>
    /// Retrieves a list of items from the database whose primary keys are present in the given list of IDs.
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <param name="ids">List of primary key values</param>
    /// <returns>IQueryable of T</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public IQueryable<T> GetManyItems<T, TKey>(bool isActiveOnly = true, params TKey[] ids) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.GetList with ids array");
        ThrowBasicErrorsIfRequired(ids);
        var result = Database.Set<T>().Where(x => ids.Contains(x.Id) && (isActiveOnly ? x.IsActive == true : true));
        AppLog.LogDebug("Returning from the method StandardRepository.GetList with ids array");
        return result;
    }
    #endregion

    #region Async

    /// <summary>
    /// (Async Method) Retrieves a list of items from the database. Returns all records in the table if isActiveOnly is false; otherwise, returns only active records in the table.
    /// </summary>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <returns>Task of IQueryable of T</returns>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<IQueryable<T>> GetManyItemsAsync<T, TKey>(bool isActiveOnly = true) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.GetListAsync");
        var result = GetManyItems<T, TKey>(isActiveOnly);
        AppLog.LogDebug("Returning from the method StandardRepository.GetListAsync");
        return await Task.FromResult(result); ;
    }
    /// <summary>
    /// Retrieves a list of items from the database that match the given criteria. (Async Method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <param name="predicate">search criteria for whare clause</param>
    /// <returns>Task of IQueryable of T</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<IQueryable<T>> GetManyItemsAsync<T, TKey>(Expression<Func<T, bool>> predicate, bool isActiveOnly = true) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.GetListAsync with predicate parameter");
        var result = GetManyItems<T, TKey>(predicate, isActiveOnly);
        AppLog.LogDebug("Returning from the method StandardRepository.GetListAsync with predicate parameter");
        return await Task.FromResult(result);
    }

    /// <summary>
    /// Retrieves a list of items from the database whose primary keys are present in the given list of IDs (Async Method).
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="isActiveOnly">true if only active records needed otherwise false, default true. </param>
    /// <param name="ids">List of primary key values</param>
    /// <returns>IQueryable of T</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<IQueryable<T>> GetManyItemsAsync<T, TKey>(bool isActiveOnly = true, params TKey[] ids) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.GetListAsync with array of ids");
        var result = GetManyItems<T, TKey>(isActiveOnly, ids);
        AppLog.LogDebug("Returning from the method StandardRepository.GetListAsync with array of ids");
        return await Task.FromResult(result);
    }
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
    public T GetAnItem<T, TKey>(TKey id) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug($"Entered into the method StandardRepository.GetAnItem with an id of type {typeof(TKey).Name}");
        var result = GetAnItemAsync<T, TKey>(id).Result;
        AppLog.LogDebug($"Returning from the method StandardRepository.GetAnItem with an id of type {typeof(TKey).Name}");
        return result;
    }

    /// <summary>
    /// Fetches a single object that matches the given composite keys.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="compositeKey"> combination of  composite key values</param>
    /// <returns>Single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public T GetAnItem<T, TKey>(params object[] compositeKey) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug($"Entered into the method StandardRepository.GetAnItem with composite keys. primary key type : {typeof(TKey).Name}");
        var result = GetAnItemAsync<T, TKey>(compositeKey).Result;
        AppLog.LogDebug($"Returning from the method StandardRepository.GetAnItem with composite keys. primary key type : {typeof(TKey).Name}");
        return result;
    }

    /// <summary>
    /// Fetches a single object that matches the given criteria.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate"></param>
    /// <returns>Single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public T GetAnItem<T, TKey>(Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug($"Entered into the method StandardRepository.GetAnItemAsync with predicate parameter. primary key type : {typeof(TKey).Name}");
        var result = GetAnItemAsync<T, TKey>(predicate).Result;
        AppLog.LogDebug($"Returning from the method StandardRepository.GetAnItemAsync with predicate parameter. primary key type : {typeof(TKey).Name}");
        return result;
    }
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
    public async Task<T> GetAnItemAsync<T, TKey>(TKey id) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug($"Entered into the method StandardRepository.GetAnItemAsync with an id of type : {typeof(TKey).Name}");
#pragma warning disable CS8604 // Possible null reference argument.
        ThrowBasicErrorsIfRequired(id);
#pragma warning restore CS8604 // Possible null reference argument.

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.

        var result = await Database.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        AppLog.LogDebug($"Returning from the method StandardRepository.GetAnItemAsync with an id of type : {typeof(TKey).Name}");
        return result;

#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.


    }

    /// <summary>
    /// Fetches a single object that matches the given composite keys. (Async Method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="compositeKey"> combination of  composite key values</param>
    /// <returns>single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<T> GetAnItemAsync<T, TKey>(params object[] compositeKey) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug($"Entered into the method StandardRepository.GetAnItemAsync with composite keys. primary key type : {typeof(TKey).Name}");
        ThrowBasicErrorsIfRequired(compositeKey);

#pragma warning disable CS8603 // Possible null reference return.
        var result = await Database.Set<T>().FindAsync(compositeKey);
        AppLog.LogDebug($"Returning from the method StandardRepository.GetAnItemAsync with composite keys. primary key type : {typeof(TKey).Name}");
        return result;
#pragma warning restore CS8603 // Possible null reference return.
    }

    /// <summary>
    /// Fetches a single object that matches the given criteria. (Async method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate"></param>
    /// <returns>single object of given type</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<T> GetAnItemAsync<T, TKey>(Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug($"Entered into the method StandardRepository.GetAnItemAsync with predicate parameter. primary key type : {typeof(TKey).Name}");
        ThrowBasicErrorsIfRequired(predicate);
#pragma warning disable CS8603 // Possible null reference return.
        var result = await Database.Set<T>().FirstOrDefaultAsync(predicate);
        AppLog.LogDebug($"Returning from the method StandardRepository.GetAnItemAsync with predicate parameter. primary key type : {typeof(TKey).Name}");
        return result;
#pragma warning restore CS8603 // Possible null reference return.
    }
    #endregion

    #endregion

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
    public T Create<T, TKey>(T entity, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Create with single entity overload method");
        var result = CreateAsync<T, TKey>(entity, loginUserId).Result;
        AppLog.LogDebug("Returning from the method StandardRepository.Create with single entity overload method");
        return result;
    }

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
    public List<T> Create<T, TKey>(List<T> entityList, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Create with list of entities overload method");
        var result = CreateAsync<T, TKey>(entityList, loginUserId).Result;
        AppLog.LogDebug("Returning from the method StandardRepository.Create with list of entities overload method");
        return result;
    }
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
    public async Task<T> CreateAsync<T, TKey>(T entity, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.CreateAsync with single entity overload method");
        ThrowBasicErrorsIfRequired(loginUserId, entity);

        entity.CreatedBy = loginUserId;
        entity.DateCreated = DateTime.UtcNow;
        entity.IsActive = true;

        await Database.Set<T>().AddAsync(entity);
        await Database.SaveChangesAsync();
        AppLog.LogDebug("Returning from the method StandardRepository.CreateAsync with single entity overload method");
        return entity;
    }

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
    public async Task<List<T>> CreateAsync<T, TKey>(List<T> entityList, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.CreateAsync with list of entities overload method");
        ThrowBasicErrorsIfRequired(loginUserId, entityList);
        foreach (var item in entityList)
        {
            await CreateAsync<T, TKey>(item, loginUserId);
        }
        AppLog.LogDebug("Returning from the method StandardRepository.CreateAsync with list of entities overload method");
        return entityList;
    }
    #endregion

    #endregion

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
    public int Update<T, TKey>(T entity, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Update with single entity overload method");
        var count = UpdateAsync<T, TKey>(entity, loginUserId).Result;
        AppLog.LogInformation($"Number of rows affected by StandardRepository.Update with single entity overload method : {count}");
        AppLog.LogDebug("Returning from the StandardRepository.Update with single entity overload method");
        return count;
    }
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
    public int Update<T, TKey>(List<T> entities, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Update with list of entities overload method");
        var count = UpdateAsync<T, TKey>(entities, loginUserId).Result;
        AppLog.LogInformation($"Number of rows affected by StandardRepository.Update with list of entities overload method : {count}");
        AppLog.LogDebug("Returning from the StandardRepository.Update with list of entities overload method");
        return count;
    }

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
    public async Task<int> UpdateAsync<T, TKey>(T entity, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.UpdateAsync with single entity overload method");
        AppLog.LogDebug($"loginUserId is {(string.IsNullOrWhiteSpace(loginUserId) ? "null or empty" : loginUserId)}");

        ThrowBasicErrorsIfRequired(loginUserId, entity);

        entity.UpdatedBy = loginUserId;
        entity.DateUpdated = DateTime.UtcNow;
        Database.Entry(entity).State = EntityState.Modified;
        int count = await Database.SaveChangesAsync();

        AppLog.LogInformation($"Number of rows affected by StandardRepository.UpdateAsync with single entity overload method : {count}");
        AppLog.LogDebug("Returning from the StandardRepository.UpdateAsync with single entity overload method");
        return count;
    }

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
    public async Task<int> UpdateAsync<T, TKey>(List<T> entities, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.UpdateAsync with list of entities overload method");
        int count = 0;
        ThrowBasicErrorsIfRequired(loginUserId, entities);
        foreach (var entity in entities)
        {
            count += await UpdateAsync<T, TKey>(entity, loginUserId);
        }
        AppLog.LogInformation($"Number of rows affected by StandardRepository.UpdateAsync with list of entities overload method : {count}");
        AppLog.LogDebug("Returning from the StandardRepository.UpdateAsync with list of entities overload method");
        return count;
    }
    #endregion

    #endregion

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
    public int Inactivate<T, TKey>(string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Inactivate");
        var count = InactivateAsync<T, TKey>(loginUserId).Result;
        AppLog.LogInformation($"Inactivated records count : {count} from the method StandardRepository.Inactivate");
        AppLog.LogDebug("Returning from the method StandardRepository.Inactivate");
        return count;
    }

    /// <summary>
    /// Soft delete (inactivate) all records in the given table whose primary key values match the provided ID.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="Id">Primary key value of the record</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public int Inactivate<T, TKey>(TKey Id, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Inactivate with only id parameter");
        var count = InactivateAsync<T, TKey>(Id, loginUserId).Result;
        AppLog.LogInformation($"Inactivated records count : {count} from the method StandardRepository.Inactivate with only id parameter");
        AppLog.LogDebug("Returning from the method StandardRepository.Inactivate with only id parameter");
        return count;
    }
    /// <summary>
    /// Soft delete (inactivate) all records in the given table whose IDs are contained in the provided list of IDs.
    /// </summary>
    /// <typeparam name="T">Table Name</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="Ids">List of primary key values</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public int Inactivate<T, TKey>(List<TKey> Ids, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Inactivate with list of ids");
        var count = InactivateAsync<T, TKey>(Ids, loginUserId).Result;
        AppLog.LogInformation($"Inactivated records count : {count} from the method StandardRepository.Inactivate with list of ids");
        AppLog.LogDebug("Returning from the method StandardRepository.Inactivate with list of ids");
        return count;
    }

    /// <summary>
    /// Soft delete (Inactivate) all records in the given table that match the provided criteria.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="predicate">selection criteria</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public int Inactivate<T, TKey>(string loginUserId, Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Inactivate with predicate");
        var count = InactivateAsync<T, TKey>(loginUserId, predicate).Result;
        AppLog.LogInformation($"Inactivated records count : {count} from the method StandardRepository.Inactivate with predicate");
        AppLog.LogDebug("Returning from the method StandardRepository.Inactivate with predicate");
        return count;
    }
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
    public async Task<int> InactivateAsync<T, TKey>(string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.InactivateAsync");
        int count = 0;
        foreach (var record in Database.Set<T>())
        {
            count += await InactivateAsync<T, TKey>(record.Id, loginUserId);
        }
        AppLog.LogInformation($"Inactivated records count : {count} from the method StandardRepository.InactivateAsync");
        AppLog.LogDebug("Returning from the method StandardRepository.InactivateAsync");
        return count;
    }

    /// <summary>
    /// (Async method) Soft delete (Inactivate) all records in the given table whose primary key values match the provided ID.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="Id">Primary key value</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<int> InactivateAsync<T, TKey>(TKey Id, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.InactivateAsync with only id parameter");
        T? record = await Database.Set<T>().FindAsync(Id);
        int count = 0;
        if (record is not null)
        {
            record.IsActive = false;
            record.DateUpdated = DateTime.UtcNow;
            record.UpdatedBy = loginUserId;
            count = await Database.SaveChangesAsync();
        }
        AppLog.LogInformation($"Inactivated records count : {count} from the method StandardRepository.InactivateAsync with only id parameter");
        AppLog.LogDebug("Returning from the method StandardRepository.InactivateAsync with only id parameter");
        return count;
    }
    /// <summary>
    /// (Async method) Soft delete (Inactivate) all records in the given table whose IDs are contained in the provided list of IDs.
    /// </summary>
    /// <typeparam name="T">Table Name</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="Ids">List of primary key values</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<int> InactivateAsync<T, TKey>(List<TKey> Ids, string loginUserId) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.InactivateAsync with list of ids parameter");
        int count = 0;

        foreach (var id in Ids)
        {
            count += await InactivateAsync<T, TKey>(id, loginUserId);
        }

        AppLog.LogInformation($"Inactivated records count : {count} from the method StandardRepository.InactivateAsync with list of ids parameter");
        AppLog.LogDebug("Returning from the method StandardRepository.InactivateAsync with list of ids parameter");
        return count;
    }
    /// <summary>
    /// (Async method) Soft delete (Inactivate) all records in the given table that match the provided criteria.
    /// </summary>
    /// <typeparam name="T">Table</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    /// <param name="predicate">selection criteria</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<int> InactivateAsync<T, TKey>(string loginUserId, Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.InactivateAsync with predicate");
        int count = 0;
        foreach (var record in Database.Set<T>().Where(predicate))
        {
            count += await InactivateAsync<T, TKey>(record.Id, loginUserId);
        }
        AppLog.LogInformation($"Inactivated records count : {count} from the method StandardRepository.InactivateAsync with predicate");
        AppLog.LogDebug("Returning from the method StandardRepository.InactivateAsync with predicate");
        return count;
    }
    #endregion

    #endregion

    #region Delete

    #region Sync
    /// <summary>
    /// This method deletes a record from the database table.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="id">Uniquely identified key value (primary key)</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public int Delete<T, TKey>(TKey id) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Delete with only id");
        var count = DeleteAsync<T, TKey>(id).Result;

        AppLog.LogInformation($"Deleted records count : {count} from the method StandardRepository.Delete with only id");
        AppLog.LogDebug("Returning from the method StandardRepository.Delete with only id");
        return count;
    }
    /// <summary>
    /// This method deletes a list of records whose primary keys match the given IDs
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="ids">primary key values array</param>
    /// <returns>Number of rows affected</returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public int Delete<T, TKey>(params TKey[] ids) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Delete with array of ids");
        var count = DeleteAsync<T, TKey>(ids).Result;

        AppLog.LogInformation($"Deleted records count : {count} from the method StandardRepository.Delete with array of ids");
        AppLog.LogDebug("Returning from the method StandardRepository.Delete with array of ids");
        return count;
    }
    /// <summary>
    /// This method deletes all records that match the given criteria.
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public int Delete<T, TKey>(Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.Delete with predicate");
        var count = DeleteAsync<T, TKey>(predicate).Result;

        AppLog.LogInformation($"Deleted records count : {count} from the method StandardRepository.Delete with predicate");
        AppLog.LogDebug("Returning from the method StandardRepository.Delete with predicate");
        return count;
    }

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
    public async Task<int> DeleteAsync<T, TKey>(TKey id) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.DeleteAsync with only id");
        int count = 0;

        T? set = await Database.Set<T>().FindAsync(id);
        if (set != null)
        {
            Database.Set<T>().Remove(set);
            Database.SaveChanges();
        }

        AppLog.LogInformation($"Deleted records count : {count} from the method StandardRepository.Delete with only id");
        AppLog.LogDebug("Returning from the method StandardRepository.DeleteAsync with only id");
        return count;
    }

    /// <summary>
    /// This method deletes a list of records whose primary keys match the given IDs (Async Method)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="ids">primary key values array</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<int> DeleteAsync<T, TKey>(params TKey[] ids) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.DeleteAsync with array of ids");
        int count = 0;

        foreach (TKey id in ids)
        {
            count += await DeleteAsync<T, TKey>(id);
        }

        AppLog.LogInformation($"Deleted records count : {count} from the method StandardRepository.Delete with array of ids");
        AppLog.LogDebug("Returning from the method StandardRepository.DeleteAsync with array of ids");
        return count;
    }

    /// <summary>
    /// This method deletes all records that match the given criteria. (Async)
    /// </summary>
    /// <typeparam name="T">Any class type</typeparam>
    /// <typeparam name="TKey">The data type of the table's primary key.</typeparam>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">An ArgumentNullException will be thrown when the argument is null.</exception>
    /// <exception cref="RepositoryException">A repository-specific exception will be thrown if the database object is not initialized or is null.</exception>
    public async Task<int> DeleteAsync<T, TKey>(Expression<Func<T, bool>> predicate) where T : DatabaseBaseEntity<TKey>
    {
        AppLog.LogDebug("Entered into the method StandardRepository.DeleteAsync with predicate");
        int count = 0;

        var records = Database.Set<T>().Where(predicate);
        foreach (var record in records)
        {
            count += await DeleteAsync<T, TKey>(record.Id);
        }
        AppLog.LogInformation($"Deleted records count : {count} from the method StandardRepository.Delete with predicate");
        AppLog.LogDebug("Returning from the method StandardRepository.DeleteAsync with predicate");
        return count;
    }
    #endregion

    #endregion

}
