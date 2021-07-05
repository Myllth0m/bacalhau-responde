using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pergunta
    {
        protected Pergunta() { }
        public Pergunta(
            int id,
            string titulo,
            string descricao,
            string foto)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Foto { get; private set; }
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
