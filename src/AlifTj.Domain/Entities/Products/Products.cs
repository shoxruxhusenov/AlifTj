using AlifTj.Domain.Common;
using AlifTj.Domain.Entities.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Domain.Entities.Product
{
    public class Product : Auditable
    {
        public string Name { get; set; }=String.Empty;

        public double Price { get; set; }

        public long Percent { get; set; }
        
        public long ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; } = default!;
    }
}
