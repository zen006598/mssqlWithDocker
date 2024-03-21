using AutoMapper;
using mssqlWithDocker.Repository.DTOs.Condition;
using mssqlWithDocker.Repository.DTOs.DataModel;
using mssqlWithDocker.Repository.Interface;
using mssqlWithDocker.Service.DTOs.Info;
using mssqlWithDocker.Service.DTOs.ResultModel;
using mssqlWithDocker.Service.Interface;

namespace mssqlWithDocker.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public bool Delete(int id)
    {
        return _productRepository.Delete(id);
    }

    public async Task<ProductResultModel> GetAsync(int id)
    {
        var product = await _productRepository.Get(id);
        var result = _mapper.Map<ProductDataModel, ProductResultModel>(product);
        return result;
    }

    public IEnumerable<ProductResultModel> GetList(ProductSearchInfo info)
    {
        var condition = _mapper.Map<ProductSearchInfo, ProductSearchCondition>(info);
        var products = _productRepository.GetList(condition);
        var result = this._mapper.Map<IEnumerable<ProductDataModel>, IEnumerable<ProductResultModel>>(products);
        return result;
    }

    public async Task<bool> Insert(ProductInfo info)
    {
        var condition = _mapper.Map<ProductInfo, ProductCondition>(info);
        return await _productRepository.Insert(condition);
    }

    public bool Update(int id, ProductInfo info)
    {
        var condition = _mapper.Map<ProductInfo, ProductCondition>(info);
        return _productRepository.Update(id, condition);
    }
}
