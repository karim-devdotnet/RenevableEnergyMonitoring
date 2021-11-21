using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace REM.Web.Models
{


     public class LoginViewModel
     {
         [Required(ErrorMessage = "{0} est obligatoire.")]
         [Display(Name = "Login")]

         public string Login { get; set; }

        [Required(ErrorMessage = "{0} est obligatoire.")]

        [DataType(DataType.Password)]
         [Display(Name = "Password")]
         public string Password { get; set; }

         [Display(Name = "Enregistrer sur ordinateur?")]
         public bool RememberMe { get; set; }
     }
     
   
}




