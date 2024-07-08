using Souccar.Consts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Validation.Date
{
    public class ParseToDate : ValidationAttribute
    {
        private const string DefaultErrorMessage = SouccarAppConstant.InvalidDate;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string dateString)
            {

                DateTime date;
                if (DateTime.TryParse(dateString, out date))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
        }
    }
}