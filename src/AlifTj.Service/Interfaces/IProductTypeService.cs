using AlifTj.Service.Dtos;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Interfaces
{
    public interface IProductTypeService
    {
        public Task<IEnumerable<ProductTypeViewModel>> GetAllAsync();
        public Task<ProductTypeViewModel> GetByIdAsync(long Id);
        public Task<bool> CreateAsync(ProductTypeCreateDto productCreateDto);
        public Task<bool> UpdateAsync(long id, ProductTypeCreateDto productCreateDto);
        public Task<bool> DeleteAsync(long id);
    }
}
