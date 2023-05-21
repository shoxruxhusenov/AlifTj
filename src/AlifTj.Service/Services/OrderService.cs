using AlifTj.DataAccess.Interfaces;
using AlifTj.Domain.Entities.Orders;
using AlifTj.Domain.Entities.Product;
using AlifTj.Service.Common.Exceptions;
using AlifTj.Service.Common.Helpers;
using AlifTj.Service.Dtos;
using AlifTj.Service.Interfaces;
using AlifTj.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<(bool,string)> CreateAsync(OrderCreateDto orderCreateDto)
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
                throw new ArgumentException("Пожалуйста, проверьте, правильно ли введен процент <Страница продукта> 3% 4% 5% !!!");

            var purpose = new Order()
            {
                ProductId = product.Id,
                UserId = user.Id,
                PriceProduct = price,
                MonthKredit = orderCreateDto.Month,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                UpdatedAt = TimeHelper.GetCurrentServerTime()
            };


            _unitOfWork.Orders.Add(purpose);

            var isSaved = await _unitOfWork.SaveChangesAsync() > 0;
            if (isSaved)
            {
                return (true, await SendMessageInfoAsync(purpose));
                throw new ArgumentException(" not found");
            }
            else
                throw new Exception("Something went wrong");

        }
        public async Task<bool> DeleteAsync(long id)
        {
            var delete = await _unitOfWork.Orders.FindByIdAsync(id);
            if (delete != null)
            {
                _unitOfWork.Users.Delete(id);
                var result = await _unitOfWork.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Order not found");
        }
        public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
        {
            var order = _unitOfWork.Orders.GetAll();
            return order.Select(order => new OrderViewModel()
            {
                Id=order.Id,
                ProductName = order.Product.Name,
                PhoneNumber = order.User.PhoneNumber,
                ProductPrice = order.PriceProduct,
                Month=order.MonthKredit,
            });
        }
        public async Task<string> SendMessageInfoAsync(Order order)
        {
            var client = new HttpClient();
            var phoneNumber = (order.User.PhoneNumber).ToString();
            if (phoneNumber.Contains("+"))
            {
                var numlength = phoneNumber.Count() - 1;
                phoneNumber = phoneNumber.Substring(1,numlength);
            }
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://telesign-telesign-send-sms-verification-code-v1.p.rapidapi.com/sms-verification-code?phoneNumber={phoneNumber}&verifyCode={$"Уважаемый покупатель! Ваша покупка прошла успешно. Спасибо за покупку! \n{order.Product.Name}\n{order.PriceProduct} somoni"}\n{order.MonthKredit} months"),
                Headers =
    {
        { "X-RapidAPI-Key", "8dd0bc996dmsh028b51eae945f4dp10f046jsn6bce713a4eb4" },
        { "X-RapidAPI-Host", "telesign-telesign-send-sms-verification-code-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
