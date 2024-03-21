using System.ComponentModel.DataAnnotations;

namespace mssqlWithDocker.Models;

public class Product
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(300)]
    public string? Description { get; set; }
    [Required, Range(0, 99999)]
    public int Price { get; set; }
}
