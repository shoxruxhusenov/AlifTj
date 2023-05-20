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

        [Required, MonthCheck]
        public long Month { get; set; }

        //public static implicit operator Order(OrderCreateDto orderCreateDto)
        //{
        //    UnitOfWork unitOf= new UnitOfWork(new AppDbContext());
        //    return new Order()
        //    {
        //        ProductId = unitOf.Products.GetAll().FirstOrDefault(x => x.Name == orderCreateDto.NameProduct)!.Id,
        //        UserId = unitOf.Users.GetAll().FirstOrDefault(x => x.UserName == orderCreateDto.PhoneNumbers)!.Id,
        //        MonthKredit = orderCreateDto.Month,
        //    };
        //}
    }
}
