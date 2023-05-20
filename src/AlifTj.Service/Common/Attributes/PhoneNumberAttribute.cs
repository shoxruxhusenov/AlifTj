using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlifTj.Service.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) return new ValidationResult("Phone Number can not be null!");

            if (value is not string phoneNumber)
            {
                return new ValidationResult("Phone Number must be a number");
            }

            var phoneNumberString = phoneNumber.ToString();
            Regex regex = new Regex(@"\+\d{3}\d{9}");

            return regex.Match(phoneNumberString).Success? ValidationResult.Success
                : new ValidationResult("Пожалуйста, введите действующий телефонный номер. Номер телефона должен содержать только цифры и знак «+».");
        }
    }
}
