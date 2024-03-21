using AutoMapper;
using Microsoft.EntityFrameworkCore;
using mssqlWithDocker.Data;
using mssqlWithDocker.Models;
using mssqlWithDocker.Repository.DTOs.Condition;
using mssqlWithDocker.Repository.DTOs.DataModel;
using mssqlWithDocker.Repository.Interface;

namespace mssqlWithDocker.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(
        IMapper mapper,
        ApplicationDbContext dbContext,
        ILogger<ProductRepository> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public bool Delete(int id)
    {
        try
        {
            var productToDelete = _dbContext.Products.Find(id);
            if (productToDelete is null) return false;
            _dbContext.Remove(productToDelete);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"{ex.Message}, {ex.InnerException}");
            return false;
        }
    }

    public async Task<ProductDataModel> Get(int id)
    {
        Product product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        return _mapper.Map<ProductDataModel>(product);
    }

    public IEnumerable<ProductDataModel> GetList(ProductSearchCondition condition)
    {
        var query = _dbContext.Products.AsQueryable();

        if (!string.IsNullOrEmpty(condition.Name))
        {
            query = query.Where(p => p.Name.Contains(condition.Name));
        }

        var result = _mapper.Map<IEnumerable<ProductDataModel>>(query.ToList());

        return result;
    }

    public async Task<bool> Insert(ProductCondition condition)
    {
        try
        {
            Product productToAdd = _mapper.Map<Product>(condition);
            await _dbContext.Products.AddAsync(productToAdd);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"{ex.Message}, {ex.InnerException}");
            return false;
        }
    }

    public bool Update(int id, ProductCondition condition)
    {
        try
        {
            var productToUpdate = _dbContext.Products.Find(id);
            if (productToUpdate is null) return false;
            _mapper.Map(condition, productToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"{ex.Message}, {ex.InnerException}");
            return false;
        }
    }
}
