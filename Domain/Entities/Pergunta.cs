using System.Collections.Generic;

namespace Domain.Entities
{
    public class Pergunta : Base
    {
        //Construtores
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

        //Propriedades
        public string Titulo { get; private set; }
        public virtual ICollection<Resposta> Respostas { get; private set; }

        //Métodos
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
