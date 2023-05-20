using AlifTj.Domain.Common;
using AlifTj.Domain.Entities.Users;
using AlifTj.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace AlifTj.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public long ProductId { get; set; }
        public virtual Product.Product Product { get; set; } = default!;

        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;

        public double PriceProduct { get; set; }

        public long MonthKredit { get;set; }
    }
}
