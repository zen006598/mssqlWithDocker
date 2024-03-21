using System.ComponentModel.DataAnnotations;

namespace mssqlWithDocker.Controllers.DTOs.Parameter;

public class ProductParameter
{
    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(300)]
    public string? Description { get; set; }
    [Required, Range(0, 99999)]
    public int Price { get; set; }
}
