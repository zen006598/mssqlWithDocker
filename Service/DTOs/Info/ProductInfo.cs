namespace mssqlWithDocker.Service.DTOs.Info;

public class ProductInfo
{
  public string Name { get; set; } = null!;
  public string? Description { get; set; }
  public int Price { get; set; }
}