using System.Collections.Generic;

namespace Domain.Entities
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
            Respostas = new List<Resposta>();
        }

        public string Descricao { get; set; }
        public string Foto { get; set; }
        public string Titulo { get; private set; }
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
