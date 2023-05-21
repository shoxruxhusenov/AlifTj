﻿using AlifTj.DataAccess.Interfaces;
using AlifTj.DataAccess.Repositories.Productes;
using AlifTj.DataAccess.Repositories;
using AlifTj.Domain.Entities.Product;
using AlifTj.Domain.Entities.Users;
using AlifTj.Service.Common.Exceptions;
using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AlifTj.DataAccess.Interfaces.Productes;
using Microsoft.EntityFrameworkCore;
using AlifTj.Service.Common.Helpers;

namespace AlifTj.Service.Services;

public class ProductService : IProductService
{

    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<bool> CreateAsync(ProductCreateDto productDto)
    {
        var uni = _unitOfWork.ProductTypes.GetAll().FirstOrDefault(x => x.TypeName == productDto.TypeName)!.Id;

       
        if (productDto.Percent >= 3 && productDto.Percent <= 5) 
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Percent = productDto.Percent,
                ProductTypeId = uni,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                UpdatedAt = TimeHelper.GetCurrentServerTime()
            };

            var res1 = product;
            _unitOfWork.Products.Add(res1);

            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }
        throw new ArgumentException("Можно ввести только 3% 4% 5% иначе не возможно войти");
    }
    

    public Task<bool> DeleteAsync(long id) => throw new NotImplementedException();
    public Task<IEnumerable<ProductViewModel>> GetAllAsync() => throw new NotImplementedException();
    public Task<ProductViewModel> GetByIdAsync(long id) => throw new NotImplementedException();
    public Task<bool> UpdateAsync(long id, ProductCreateDto productCreateDto) => throw new NotImplementedException();
}
