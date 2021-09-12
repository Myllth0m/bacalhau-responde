using System;
using System.Collections.Generic;

namespace BacalhauResponde.Models
{
    public class Pergunta : EntidadeBase
    {
        protected Pergunta() { }
        public Pergunta(
            long id,
            string usuarioId,
            string titulo,
            string descricao,
            string foto)
        {
            Id = id;
            UsuarioId = usuarioId;
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            DataDeCriacao = DateTime.Now.ToLongDateString();
            DataDeAtualizacao = DateTime.Now.ToLongDateString();
        }

        public string UsuarioId { get; private set; }
        public string Descricao { get; private set; }
        public string Foto { get; private set; }
        public string Titulo { get; private set; }

        public virtual Usuario Usuario { get; private set; }
        public virtual ICollection<Resposta> Respostas { get; private set; }

        public void AtualizarDados(
            string titulo,
            string descricao,
            string foto)
        {
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            DataDeAtualizacao = DateTime.Now.ToLongDateString();
        }
    }
}
