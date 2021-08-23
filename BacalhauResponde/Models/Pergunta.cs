using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BacalhauResponde.Models
{
    public class Pergunta : EntidadeBase
    {
        protected Pergunta() { }
        public Pergunta(
            long id,
            string titulo,
            string descricao,
            string foto)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
        }

        public string UsuarioId { get; private set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public string Titulo { get; private set; }
        public IdentityUser Usuario { get; private set; }
        public virtual ICollection<Resposta> Respostas { get; private set; }

        public void AtualizarDados(
            string titulo,
            string descricao,
            string foto)
        {
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
        }
    }
}
