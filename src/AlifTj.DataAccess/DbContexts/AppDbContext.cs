using AlifTj.DataAccess.Configurations;
using AlifTj.Domain.Entities.Orders;
using AlifTj.Domain.Entities.Product;
using AlifTj.Domain.Entities.ProductTypes;
using AlifTj.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AlifTj.DataAccess.DbContexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) 
        : base(dbContextOptions)
    {
    }
    public virtual DbSet<User> Users { get; set; } = default!;
    public virtual DbSet<Order> Orders { get; set; }= default!; 
    public virtual DbSet<ProductType> ProductTypes { get; set; } = default!;
    public virtual DbSet<Products> Products { get; set; }=default!;

}
