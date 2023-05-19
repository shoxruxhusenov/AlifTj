using AlifTj.DataAccess.DbContexts;
using AlifTj.DataAccess.Interfaces.ProductTypes;
using AlifTj.Domain.Entities.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.DataAccess.Repositories.ProductTypes
{
    public class ProductTypeRepository: GenericRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(AppDbContext context): base(context) { }
    }
}
