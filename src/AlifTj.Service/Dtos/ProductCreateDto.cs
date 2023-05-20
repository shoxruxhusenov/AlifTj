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

    }
}
