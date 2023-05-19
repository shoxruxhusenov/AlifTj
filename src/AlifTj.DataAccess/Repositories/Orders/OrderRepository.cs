using AlifTj.DataAccess.DbContexts;
using AlifTj.DataAccess.Interfaces.Orders;
using AlifTj.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.DataAccess.Repositories.Orders
{
    public class OrderRepository: GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }
    }
}
