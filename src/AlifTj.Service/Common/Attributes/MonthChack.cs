using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlifTj.Service.Common.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class MonthCheckAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not null && value is int grade)
        {
            if (grade < 3 || !(new[] { 3, 6, 9, 12, 18, 24 }).Contains(grade))
            {
                return new ValidationResult("Month entry must be between 3 months and 6-9-12-18-24 months");
            }
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("Invalid grade value.");
        }
    }
}
