using Ps.CleanWebApi.Infrastructure.Repository.Abstractions;

namespace Ps.CleanWebApi.Infrastructure.Repository;

public interface IRepository : IGetData, ICreateData, IUpdateData, IInactivateData, IDeleteData
{

}
