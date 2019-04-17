using System.ComponentModel.DataAnnotations;
using System.Linq;
using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.AttributValidation
{
    public class Unique : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IRepositoriesUoW repo = new RepositoriesUoW();

            var contains = repo.GetContext().Communs.Any(x => x.Nom.Contains(value.ToString()));

            if (contains)
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
