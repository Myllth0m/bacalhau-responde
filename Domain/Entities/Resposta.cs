namespace Domain.Entities
{
    public class Resposta
    {
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

        public int Id { get; private set; }
        public string Descricao { get; set; }
        public string Foto { get; private set; }
        public int PerguntaId { get; private set; }
        public virtual Pergunta Pergunta { get; private set; }

        public void AtualizarDados(
            string descricao,
            string foto)
        {
            Descricao = descricao;
            Foto = foto;
        }
    }
}
