namespace Domain.Entities
{
    public class Resposta : Base
    {
        //Construtores
        protected Resposta() { }
        public Resposta(
            int id,
            string descricao,
            string foto,
            int perguntaId)
        {
            Id = id;
            Descricao = descricao;
            Foto = foto;
            PerguntaId = perguntaId;
        }

        //Propriedades
        public int PerguntaId { get; private set; }
        public virtual Pergunta Pergunta { get; private set; }

        //Métodos
        public void AtualizarDados(
            string descricao,
            string foto)
        {
            Descricao = descricao;
            Foto = foto;
        }
    }
}
