using System;

namespace BacalhauResponde.Models
{
    public class Resposta : EntidadeBase
    {
        protected Resposta() { }
        public Resposta(
            long id,
            string descricao,
            string foto,
            long perguntaId)
        {
            Id = id;
            PerguntaId = perguntaId;
            Descricao = descricao;
            Foto = foto;
            DataDeCriacao = DateTime.Now.ToLongDateString();
            DataDeAtualizacao = DateTime.Now.ToLongDateString();
        }

        public string UsuarioId { get; private set; }
        public long PerguntaId { get; private set; }
        public string Descricao { get; private set; }
        public string Foto { get; private set; }
        public Usuario Usuario { get; private set; }
        public virtual Pergunta Pergunta { get; private set; }

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
