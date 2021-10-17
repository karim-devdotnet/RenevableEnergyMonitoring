using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace REM.Web.Models
{
    public class ExternalLoginConfirmationViewModel
     {
         [Required]
         [Display(Name = "Login")]
         public string login { get; set; }
     }

     public class ExternalLoginListViewModel
     {
         public string ReturnUrl { get; set; }
     }

     public class SendCodeViewModel
     {
         public string SelectedProvider { get; set; }
         public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
         public string ReturnUrl { get; set; }
         public bool RememberMe { get; set; }
     }

     public class VerifyCodeViewModel
     {
         [Required]
         public string Provider { get; set; }

         [Required]
         [Display(Name = "Code")]
         public string Code { get; set; }
         public string ReturnUrl { get; set; }

         [Display(Name = "Vous vous souvenez de ce navigateur ?")]
         public bool RememberBrowser { get; set; }

         public bool RememberMe { get; set; }
     }

     public class ForgotViewModel
     {
         [Required]
         [Display(Name = "Login")]
         public string login { get; set; }
     }

     public class LoginViewModel
     {
         [Required]
         [Display(Name = "Login")]

         public string login { get; set; }

         [Required]
         [DataType(DataType.Password)]
         [Display(Name = "Password")]
         public string Password { get; set; }

         [Display(Name = "Enregistrer sur ordinateur?")]
         public bool RememberMe { get; set; }
     }
     /*
     public class RegisterViewModel
     {
         [Required]
         [EmailAddress]
         [Display(Name = "login")]
         public string Email { get; set; }

         [Required]
         [StringLength(100, ErrorMessage = "\"{0}\" doit comporter au moins {2} caractères.", MinimumLength = 6)]
         [DataType(DataType.Password)]
         [Display(Name = "Password")]
         public string Password { get; set; }

         [DataType(DataType.Password)]
         [Display(Name = "Confirmez le mot de passe")]
         [Compare("Password", ErrorMessage = "Le mot de passe ne correspond pas au mot de passe de confirmation.")]
         public string ConfirmPassword { get; set; }
     }

      public class ResetPasswordViewModel
      {
          [Required]
          [EmailAddress]
          [Display(Name = "E-Mail")]
          public string Email { get; set; }

          [Required]
          [StringLength(100, ErrorMessage = "\"{0}\" muss mindestens {2} Zeichen lang sein.", MinimumLength = 6)]
          [DataType(DataType.Password)]
          [Display(Name = "Kennwort")]
          public string Password { get; set; }

          [DataType(DataType.Password)]
          [Display(Name = "Kennwort bestätigen")]
          [Compare("Password", ErrorMessage = "Das Kennwort stimmt nicht mit dem Bestätigungskennwort überein.")]
          public string ConfirmPassword { get; set; }

          public string Code { get; set; }
      }

      public class ForgotPasswordViewModel
      {
          [Required]
          [EmailAddress]
          [Display(Name = "E-Mail")]
          public string Email { get; set; }
    
      }*/
   
}




