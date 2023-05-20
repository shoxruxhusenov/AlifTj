using AlifTj.DataAccess.Interfaces;
using AlifTj.DataAccess.Repositories;
using AlifTj.Domain.Entities.ProductTypes;
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

namespace AlifTj.Service.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProductTypeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(ProductTypeCreateDto createDto)
        {
            var entity = await _unitOfWork.ProductTypes.FirstOrDefaultAsync(x => x.TypeName == createDto.TypeName);
            if (entity != null)
                throw new StatusCodeException(HttpStatusCode.Conflict, "это Product Type уже существует");

            var type = (ProductType)createDto;
            _unitOfWork.ProductTypes.Add(type);

            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }   
        public Task<bool> DeleteAsync(long id) => throw new NotImplementedException();
        public Task<IEnumerable<ProductTypeViewModel>> GetAllAsync() => throw new NotImplementedException();
        public Task<ProductTypeViewModel> GetByIdAsync(long Id) => throw new NotImplementedException();
        public Task<bool> UpdateAsync(long id, ProductTypeCreateDto productCreateDto) => throw new NotImplementedException();
    }
}
