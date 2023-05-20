using AlifTj.Service.Dtos;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductViewModel>> GetAllAsync();
        public Task<ProductViewModel> GetByIdAsync(long id);
        public Task<bool> CreateAsync(ProductCreateDto productCreateDto);
        public Task<bool> UpdateAsync(long id, ProductCreateDto productCreateDto);
        public Task<bool> DeleteAsync(long id);
    }
}
