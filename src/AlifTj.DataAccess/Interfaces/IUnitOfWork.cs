using AlifTj.DataAccess.Interfaces.Orders;
using AlifTj.DataAccess.Interfaces.Productes;
using AlifTj.DataAccess.Interfaces.ProductTypes;
using AlifTj.DataAccess.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public IOrderRepository Orders { get; }

        public IProductRepositoriy Products { get; }

        public IProductTypeRepository ProductTypes { get; }

        public IUserRepository Users { get; }

        public Task<int> SaveChangesAsync();
    }
}
