using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Services;

public class ProductService : IProductService
{
    public Task<bool> CreateAsync(ProductCreateDto productCreateDto) => throw new NotImplementedException();
    public Task<bool> DeleteAsync(long id) => throw new NotImplementedException();
    public Task<IEnumerable<ProductViewModel>> GetAllAsync() => throw new NotImplementedException();
    public Task<ProductViewModel> GetByIdAsync(long id) => throw new NotImplementedException();
    public Task<bool> UpdateAsync(long id, ProductCreateDto productCreateDto) => throw new NotImplementedException();
}
