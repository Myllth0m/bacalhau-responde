using System.ComponentModel.DataAnnotations;

namespace BacalhauResponde.Models.ViewModels
{
    public class CriarRespostaViewModel
    {
        public long Id { get; set; }

        public long PerguntaId { get; set; }

        [Required(ErrorMessage = "Informe a descrição da resposta")]
        public string Descricao { get; set; }
    }
}
