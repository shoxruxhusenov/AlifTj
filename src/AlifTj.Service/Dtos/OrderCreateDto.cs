using AlifTj.DataAccess.DbContexts;
using AlifTj.DataAccess.Repositories;
using AlifTj.Domain.Entities.Orders;
using AlifTj.Domain.Entities.Product;
using AlifTj.Domain.Entities.Users;
using AlifTj.Service.Common.Attributes;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Dtos
{
    public class OrderCreateDto
    {
        [Required]
        public string NameProduct { get; set; }=string.Empty;

        [Required]
        public string PhoneNumbers { get; set; }= string.Empty;

        [Required]
        public double Price { get;set; }

        [Required(ErrorMessage = "Запись месяца должна быть между 3 месяцами и 6-9-12-18-24 месяцами")]
        public long Month { get; set; }

       
      
    }
}
