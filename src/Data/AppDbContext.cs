using System.Text.RegularExpressions;
using atdd_v2_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace atdd_v2_dotnet.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseUnderscoreNamingConvention();

        modelBuilder.Entity<OrderLine>()
            .HasOne(orderLine => orderLine.Order)
            .WithMany(order => order.Lines)
            .HasForeignKey(orderLine => orderLine.OrderId);
    }
}

public static class ModelBuilderExtensions
{
    public static ModelBuilder UseUnderscoreNamingConvention(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(NamingConvention(entity.GetTableName()));
            foreach (var property in entity.GetProperties())
                property.SetColumnName(NamingConvention(property.GetColumnName()));
        }

        return modelBuilder;
    }

    private static string NamingConvention(string name)
    {
        return Regex.Replace(name, @"(\p{Ll})(\p{Lu})", "$1_$2").ToLower();
    }
}