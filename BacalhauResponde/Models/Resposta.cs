using System;

namespace BacalhauResponde.Models
{
    public class Resposta : EntidadeBase
    {
        protected Resposta() { }
        public Resposta(
            long id,
            long perguntaId,
            string usuarioId,
            string descricao,
            string foto)
        {
            Id = id;
            PerguntaId = perguntaId;
            Descricao = descricao;
            UsuarioId = usuarioId;
            Foto = foto;
            DataDeCriacao = DateTime.Now.ToLongDateString();
            DataDeAtualizacao = DateTime.Now.ToLongDateString();
        }

        public long PerguntaId { get; private set; }
        public string UsuarioId { get; private set; }
        public string Descricao { get; private set; }
        public string Foto { get; private set; }

        public virtual Pergunta Pergunta { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        public void AtualizarDados(
            string descricao,
            string foto)
        {
            Descricao = descricao;
            Foto = foto;
            DataDeAtualizacao = DateTime.Now.ToLongDateString();
        }
    }
}
