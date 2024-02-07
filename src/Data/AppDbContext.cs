using atdd_v2_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace atdd_v2_dotnet.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}