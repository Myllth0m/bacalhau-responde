namespace BacalhauResponde.Models
{
    public abstract class EntidadeBase
    {
        public long Id { get; set; }
        public string DataDeCriacao { get; set; }
        public string DataDeAtualizacao { get; set; }
    }
}
