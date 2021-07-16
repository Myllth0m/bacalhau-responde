namespace Domain.Entities
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
        }

        public long PerguntaId { get; private set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
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
