using AlifTj.DataAccess.Interfaces;
using AlifTj.Domain.Entities.Orders;
using AlifTj.Domain.Entities.Product;
using AlifTj.Service.Common.Helpers;
using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(OrderCreateDto orderCreateDto)
        {
            var product = _unitOfWork.Products.GetAll().FirstOrDefault(x => x.Name == orderCreateDto.NameProduct)
                ?? throw new ArgumentException("Товар не найден");

            var user = _unitOfWork.Users.GetAll().FirstOrDefault(x => x.PhoneNumber == orderCreateDto.PhoneNumbers)
                ?? throw new ArgumentException("Пользователь не найден.");

            if (product.Price != orderCreateDto.Price)
                throw new ArgumentException("Цена продукта и цена DTO не совпадают.");

            if (orderCreateDto.Month < 3 || orderCreateDto.Month > 24 || orderCreateDto.Month % 3 != 0)
                throw new ArgumentException("Ввод месяца должен быть между 3 месяцами и 6-9-12-18-24 месяцами");

            var price = product.Price;

            if (product.Name==orderCreateDto.NameProduct && product.Percent == 3)
            {
                switch (orderCreateDto.Month)
                {
                    case long month when month >= 3 && month <= 9:
                        price *= 1.03;
                        break;
                    case long month when month > 9 && month <= 18:
                        price *= 1.06;
                        break;
                    case long month when month > 18 && month <= 24:
                        price *= 1.09;
                        break;
                    default:
                        break;
                }
            }
            else if(product.Name == orderCreateDto.NameProduct && product.Percent == 4)
            {
                switch (orderCreateDto.Month)
                {
                    case long month when month >= 3 && month <= 12:
                        price *= 1.04;
                        break;
                    case long month when month > 12 && month <= 18:
                        price *= 1.08;
                        break;
                    case long month when month > 18 && month <= 24:
                        price *= 1.12;
                        break;
                    default:
                        break;
                }
            }
            else if (product.Name == orderCreateDto.NameProduct && product.Percent == 5)
            {
                switch (orderCreateDto.Month)
                {
                    case long month when month >= 3 && month <= 18:
                        price *= 1.05;
                        break;
                    case long month when month > 18 && month <= 24:
                        price *= 1.10;
                        break;
                    default:
                        break;
                }
            }
            else
                throw new ArgumentException("Произошла ошибка. Выберите что-нибудь другое.");




            _unitOfWork.Orders.Add(new Order
            {
                ProductId = product.Id,
                UserId = user.Id,
                PriceProduct = price,
                MonthKredit = orderCreateDto.Month,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                UpdatedAt = TimeHelper.GetCurrentServerTime()
            });

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public Task<bool> DeleteAsync(long id) => throw new NotImplementedException();
        public Task<IEnumerable<OrderViewModel>> GetAllAsync() => throw new NotImplementedException();
        public Task<OrderViewModel> GetByIdAsync(long id) => throw new NotImplementedException();
        public Task<IEnumerable<OrderViewModel>> GetByPhoneAsync(string PhoneNumber) => throw new NotImplementedException();
        public Task<bool> UpdateAsync(long id, OrderCreateDto createDto) => throw new NotImplementedException();
    }
}
