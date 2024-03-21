using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mssqlWithDocker.Controllers.DTOs.Parameter;
using mssqlWithDocker.Controllers.DTOs.ViewModel;
using mssqlWithDocker.Service.DTOs.Info;
using mssqlWithDocker.Service.DTOs.ResultModel;
using mssqlWithDocker.Service.Interface;

namespace mssqlWithDocker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(
        IProductService productService,
        IMapper mapper
    )
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    [Produces("application/json")]
    public IEnumerable<ProductViewModel> GetList([FromQuery] ProductSearchParameter parameter)
    {
        var info = _mapper.Map<ProductSearchParameter, ProductSearchInfo>(parameter);

        var products = _productService.GetList(info);

        var result = _mapper.Map<
            IEnumerable<ProductResultModel>,
            IEnumerable<ProductViewModel>>(products);
        return result;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProductViewModel), 200)]
    [Route("{id}")]
    public async Task<ProductViewModel> Get([FromRoute] int id)
    {
        var product = await _productService.GetAsync(id);
        return _mapper.Map<ProductResultModel, ProductViewModel>(product);
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] ProductParameter parameter)
    {
        var info = _mapper.Map<ProductParameter, ProductInfo>(parameter);
        var isSuccess = await _productService.Insert(info);
        if (isSuccess) return Ok();
        return BadRequest();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] int id,
        [FromBody] ProductParameter parameter)
    {
        var targetCard = await _productService.GetAsync(id);
        if (targetCard is null) return NotFound();
        var info = _mapper.Map<ProductParameter, ProductInfo>(parameter);
        var isSuccess = _productService.Update(id, info);
        if (isSuccess) return Ok();
        return BadRequest();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(
        [FromRoute] int id)
    {
        var isSuccess = _productService.Delete(id);
        if (isSuccess) return Ok();
        return BadRequest();
    }
}
