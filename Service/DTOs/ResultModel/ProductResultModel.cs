namespace mssqlWithDocker.Service.DTOs.ResultModel;

public class ProductResultModel
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string? Description { get; set; }
  public int Price { get; set; }
}
