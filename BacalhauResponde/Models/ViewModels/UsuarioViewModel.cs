using System.ComponentModel.DataAnnotations;

namespace BacalhauResponde.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe seu nome")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe seu e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MinLength(6, ErrorMessage = "Senha inválida")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme sua senha")]
        [Compare(nameof(Senha), ErrorMessage = "As senhas não são iguais")]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }
    }
}
