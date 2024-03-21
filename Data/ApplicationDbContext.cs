using Microsoft.EntityFrameworkCore;
using mssqlWithDocker.Models;

namespace mssqlWithDocker.Data;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
