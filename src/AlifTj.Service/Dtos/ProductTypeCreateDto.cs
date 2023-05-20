using AlifTj.Domain.Entities.ProductTypes;
using AlifTj.Service.Common.Helpers;
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
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Заголовок должен состоять минимум из 5 и максимум из 40 символов.")]
        
        public string TypeName { get; set; } = String.Empty;

        public static implicit operator ProductType(ProductTypeCreateDto dto)
        {
            return new ProductType
            {
                TypeName = dto.TypeName,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                UpdatedAt = TimeHelper.GetCurrentServerTime()
            };
        }
    }
}
