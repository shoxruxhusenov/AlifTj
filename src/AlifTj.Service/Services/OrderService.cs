using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Services
{
    public class OrderService : IOrderService
    {
        public Task<bool> CreateAsync(OrderCreateDto orderCreateDto) => throw new NotImplementedException();
        public Task<bool> DeleteAsync(long id) => throw new NotImplementedException();
        public Task<IEnumerable<OrderViewModel>> GetAllAsync() => throw new NotImplementedException();
        public Task<OrderViewModel> GetByIdAsync(long id) => throw new NotImplementedException();
        public Task<IEnumerable<OrderViewModel>> GetByPhoneAsync(string PhoneNumber) => throw new NotImplementedException();
        public Task<bool> UpdateAsync(long id, OrderCreateDto createDto) => throw new NotImplementedException();
    }
}
