namespace mssqlWithDocker.Repository.DTOs.DataModel;

public class ProductDataModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int Price { get; set; }
}
