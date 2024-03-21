using mssqlWithDocker.Service.DTOs.Info;
using mssqlWithDocker.Service.DTOs.ResultModel;

namespace mssqlWithDocker.Service.Interface;

public interface IProductService
{
    IEnumerable<ProductResultModel> GetList(ProductSearchInfo info);
    Task<ProductResultModel> GetAsync(int id);
    Task<bool> Insert(ProductInfo info);
    bool Update(int id, ProductInfo info);
    bool Delete(int id);
}
