using AlifTj.Domain.Entities.Users;
using AlifTj.Service.Common.Attributes;
using AlifTj.Service.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Dtos
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Заголовок должен состоять минимум из 5 и максимум из 40 символов.")]
        public string UserName { get; set; } = String.Empty;


        [Required(ErrorMessage = "Phone Number is required")]
        [PhoneNumber(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; } = String.Empty;



        public static implicit operator User(UserCreateDto userCreateDto)
        {
            return new User()
            {
                UserName= userCreateDto.UserName,
                PhoneNumber= userCreateDto.PhoneNumber,
                CreatedAt=TimeHelper.GetCurrentServerTime(),
                UpdatedAt=TimeHelper.GetCurrentServerTime()
            };
        }
    }
}
