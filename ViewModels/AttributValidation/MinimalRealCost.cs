//using System.ComponentModel.DataAnnotations;

//namespace ViewModels
//{
//    public class MinimalRealCost : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            int qty = ((TradeMaterial)validationContext.ObjectInstance).Quantity;
//            decimal cost = ((TradeMaterial)validationContext.ObjectInstance).Material.Value;
//            decimal fee = ((TradeMaterial)validationContext.ObjectInstance).Fee;
//            string ts = ((TradeMaterial)validationContext.ObjectInstance).State.Nom;

//            if (((decimal)value >= (qty*cost + fee)) && ts != "Achat")
//            {
//                return ValidationResult.Success;
//            }
//            else
//            {
//                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
//            }
//        }
//    }
//}
