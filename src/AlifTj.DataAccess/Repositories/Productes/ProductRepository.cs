using AlifTj.DataAccess.DbContexts;
using AlifTj.DataAccess.Interfaces.Productes;
using AlifTj.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.DataAccess.Repositories.Productes
{
    public class ProductRepository: GenericRepository<Products>, IProductRepositoriy
    {
        public ProductRepository(AppDbContext context):base(context) { }
    }
}
