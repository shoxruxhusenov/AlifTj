using AlifTj.DataAccess.DbContexts;
using AlifTj.DataAccess.Repositories;
using AlifTj.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Dtos
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }=string.Empty;

        [Required]
        public double Price { get; set; }

        [Required]
        public long Percent { get; set; }

        [Required]
        public string TypeName { get; set; } = string.Empty;

        public static implicit operator Products(ProductCreateDto product)
        {
            UnitOfWork work = new UnitOfWork(new AppDbContext());

            return new Products()
            {
                Name = product.Name,
                Price = product.Price,
                Percent = product.Percent,
                TypeId = work.ProductTypes.GetAll().FirstOrDefault(x => x.TypeName == product.TypeName)!.Id,
            };
        }

    }
}
