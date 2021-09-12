using System.ComponentModel.DataAnnotations;

namespace BacalhauResponde.Models.ViewModels
{
    public class CriarPerguntaViewModel
    {
        public long Id { get; set; }
        
        [Display(Name = "Informe de forma direta qual ponto você quer abordar")]
        [Required(ErrorMessage = "Informe o título da pergunta")]
        public string Titulo { get; set; }

        [Display(Name = "Descreva com claresa qual é a sua dúvida")]
        [Required(ErrorMessage = "Informe a descrição da pergunta")]
        public string Descricao { get; set; }
        
        public string Foto { get; set; }
    }
}
