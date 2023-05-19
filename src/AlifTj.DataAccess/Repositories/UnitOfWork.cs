using AlifTj.DataAccess.DbContexts;
using AlifTj.DataAccess.Interfaces;
using AlifTj.DataAccess.Interfaces.Orders;
using AlifTj.DataAccess.Interfaces.Productes;
using AlifTj.DataAccess.Interfaces.ProductTypes;
using AlifTj.DataAccess.Interfaces.Users;
using AlifTj.DataAccess.Repositories.Orders;
using AlifTj.DataAccess.Repositories.Productes;
using AlifTj.DataAccess.Repositories.ProductTypes;
using AlifTj.DataAccess.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContexts;

        public IOrderRepository Orders { get; }

        public IProductRepositoriy Products { get; }

        public IProductTypeRepository ProductTypes { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(AppDbContext dbContext)
        {
            this.appDbContexts = dbContext;
            Orders = new OrderRepository(dbContext);
            Products = new ProductRepository(dbContext);
            ProductTypes = new ProductTypeRepository(dbContext);
            Users = new UserRepository(dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await appDbContexts.SaveChangesAsync();
        }

       
    }
}
