using AlifTj.Domain.Entities.Orders;
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
        public Task<(bool,string)> CreateAsync(OrderCreateDto orderCreateDto);
        public Task<bool> DeleteAsync(long id);
        public Task<string> SendMessageInfoAsync(Order order);

    }
}
