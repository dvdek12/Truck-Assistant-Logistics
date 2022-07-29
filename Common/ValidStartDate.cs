using System;
using System.ComponentModel.DataAnnotations;
using TruckAssistant.Models;

namespace TruckAssistant.Common
{
    public class ValidStartDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var trip = (Trip)validationContext.ObjectInstance;
            DateTime StartDate = Convert.ToDateTime(value);
            
            
            if(StartDate < DateTime.Now)
            {
                return new ValidationResult($"Start date cannot be smaller than actual time: {DateTime.Now}");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
