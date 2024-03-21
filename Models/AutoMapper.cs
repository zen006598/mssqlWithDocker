using AutoMapper;
using mssqlWithDocker.Controllers.DTOs.Parameter;
using mssqlWithDocker.Controllers.DTOs.ViewModel;
using mssqlWithDocker.Repository.DTOs.Condition;
using mssqlWithDocker.Repository.DTOs.DataModel;
using mssqlWithDocker.Service.DTOs.Info;
using mssqlWithDocker.Service.DTOs.ResultModel;

namespace mssqlWithDocker.Models;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Product, ProductDataModel>();
        CreateMap<ProductCondition, Product>();
        CreateMap<ProductParameter, ProductInfo>();
        CreateMap<ProductInfo, ProductCondition>();
        CreateMap<ProductDataModel, ProductResultModel>();
        CreateMap<ProductResultModel, ProductViewModel>();
        CreateMap<ProductSearchInfo, ProductSearchCondition>();
        CreateMap<ProductSearchParameter, ProductSearchInfo>();
    }
}