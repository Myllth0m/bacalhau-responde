using System.ComponentModel.DataAnnotations;

namespace BacalhauResponde.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Display(Name = "Seu nome completo")]
        [Required(ErrorMessage = "Informe seu nome")]
        public string Nome { get; set; }

        [Display(Name = "Seu e-mail")]
        [Required(ErrorMessage = "Informe seu e-mail")]
        public string Email { get; set; }

        [Display(Name = "Sua formação/ocupação")]
        [Required(ErrorMessage = "Informe sua formação/ocupação")]
        public string Ocupacao { get; set; }
        
        [Display(Name = "Sua senha (no mínimo 6 digitos)")]
        [Required(ErrorMessage = "Informe sua senha")]
        [MinLength(6, ErrorMessage = "Senha inválida")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme sua senha")]
        [Required(ErrorMessage = "Informe novamente sua senha")]
        [Compare(nameof(Senha), ErrorMessage = "As senhas não são iguais")]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }
    }
}
