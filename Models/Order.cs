using System.ComponentModel.DataAnnotations;

namespace mssqlWithDocker.Models;

public class Order
{
    [Key]
    public Guid Id { get; set; }
    [Required, Range(0, 999999)]
    public int Amount { get; set; }
}
