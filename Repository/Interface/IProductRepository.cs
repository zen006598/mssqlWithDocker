using mssqlWithDocker.Repository.DTOs.Condition;
using mssqlWithDocker.Repository.DTOs.DataModel;

namespace mssqlWithDocker.Repository.Interface;

public interface IProductRepository
{
    IEnumerable<ProductDataModel> GetList(ProductSearchCondition condition);
    Task<ProductDataModel> Get(int id);
    Task<bool> Insert(ProductCondition condition);
    bool Update(int id, ProductCondition condition);
    bool Delete(int id);
}