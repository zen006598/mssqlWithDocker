namespace mssqlWithDocker.Repository.DTOs.Condition;

public class ProductSearchCondition
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int Price { get; set; }
}
