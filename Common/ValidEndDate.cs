using System;
using System.ComponentModel.DataAnnotations;
using TruckAssistant.Models;

namespace TruckAssistant.Common
{
    public class ValidEndDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var trip = (Trip)validationContext.ObjectInstance;
            DateTime EndDate = Convert.ToDateTime(value);

            if (EndDate < trip.StartDate)
            {
                return new ValidationResult("End date cannot be smaller than end date.");
            }
            else if (trip.EndDate < DateTime.Now)
            {
                return new ValidationResult($"End date cannot be smaller than actual time: {DateTime.Now}");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
