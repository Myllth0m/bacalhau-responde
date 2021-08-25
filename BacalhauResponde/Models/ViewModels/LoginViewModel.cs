using System.ComponentModel.DataAnnotations;

namespace BacalhauResponde.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Senha inválida")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
