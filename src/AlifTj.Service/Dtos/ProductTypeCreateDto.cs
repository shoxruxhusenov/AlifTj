using AlifTj.Domain.Entities.ProductTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Dtos
{
    public class ProductTypeCreateDto
    {
        [Required]
        public string TypeName { get; set; } = String.Empty;

        public static implicit operator ProductType(ProductTypeCreateDto dto)
        {
            return new ProductType
            {
                TypeName = dto.TypeName,
            };
        }
    }
}
