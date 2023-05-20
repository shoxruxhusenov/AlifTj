using AlifTj.Domain.Entities.Users;
using AlifTj.Service.Common.Attributes;
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
        [StringLength(40, MinimumLength = 5, ErrorMessage = "The Title should be minimum 5 and maximum 50 characters.")]
        public string UserName { get; set; } = String.Empty;

        [Required, PhoneNumber]
        public string PhoneNumber { get; set; } = String.Empty;

        public static implicit operator User(UserCreateDto userCreateDto)
        {
            return new User()
            {
                UserName= userCreateDto.UserName,
                PhoneNumber= userCreateDto.PhoneNumber,
            };
        }
    }
}
