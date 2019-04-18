using System.ComponentModel.DataAnnotations;
using System.Linq;
using WpfApp.Model;
using WpfApp.Repositories;
using WpfApp.Repositories.Interfaces;

namespace WpfApp.AttributValidation
{
    public class Unique : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IRepositoriesUoW repo = new RepositoriesUoW();           
            // Recuperation de l'id de l'item
            int actualId;
            actualId = ((Commun)validationContext.ObjectInstance).Id > 0 ? ((Commun)validationContext.ObjectInstance).Id : 0;

            //Verification que le Nom n'existe pas avec un id different
            // si on verifie pas l'il, la notification Unique se declenche si simmple modif de l'item
            var contains = repo.GetContext().Communs.Any(x => x.Nom == value.ToString() && x.Id != actualId);

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
