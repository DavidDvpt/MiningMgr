using System.ComponentModel.DataAnnotations;
using WpfApp.Model;

namespace WpfApp.AttributValidation
{
    class MaxEnhancer : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((Setup)validationContext.ObjectInstance).DepthEnhancerQty 
                + ((Setup)validationContext.ObjectInstance).RangeEnhancerQty
                + ((Setup)validationContext.ObjectInstance).SkillEnhancerQty >10 )
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
