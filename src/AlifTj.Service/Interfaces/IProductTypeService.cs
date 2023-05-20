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
        public Task<bool> CreateAsync(ProductCreateDto productCreateDto);
        public Task<bool> UpdateAsync(long id, ProductCreateDto productCreateDto);
        public Task<bool> DeleteAsync(long id);

    }
}
