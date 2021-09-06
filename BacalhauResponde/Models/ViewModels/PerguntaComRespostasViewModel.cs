using System.Collections.Generic;

namespace BacalhauResponde.Models.ViewModels
{
    public class PerguntaComRespostasViewModel
    {
        public string UsuarioDaPergunta { get; set; }
        
        public string OcupacaoDoUsuario { get; set; }
        
        public string DataDeCricaoDaPergunta { get; set; }
        
        public long PerguntaId { get; set; }
        
        public string Titulo { get; set; }
        
        public string Descricao { get; set; }

        public List<RespostaViewModel> Respostas { get; set; }
    }
}
