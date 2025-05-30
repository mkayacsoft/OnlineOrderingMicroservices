using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data;

public class AppDbContext:DbContext
{
    public DbSet<Order> Orders { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
}