using AlifTj.Domain.Entities.Users;
using AlifTj.Service.Dtos;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderViewModel>> GetAllAsync();
        public Task<OrderViewModel> GetByIdAsync(long id);
        public Task<IEnumerable<OrderViewModel>> GetByPhoneAsync(string PhoneNumber);
        public Task<bool> CreateAsync(OrderCreateDto orderCreateDto);
        public Task<bool> UpdateAsync(long id, OrderCreateDto createDto);
        public Task<bool> DeleteAsync(long id);
    }
}
