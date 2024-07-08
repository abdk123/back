using Souccar.Consts;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Validation.List
{
    public class NotEmptyList : ValidationAttribute
    {
        private const string DefaultErrorMessage = SouccarAppConstant.EmptyList;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IList list && list.Count > 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
        }
    }
}