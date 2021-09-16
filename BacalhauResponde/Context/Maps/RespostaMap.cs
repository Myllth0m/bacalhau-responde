using BacalhauResponde.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BacalhauResponde.Context.Maps
{
    public class RespostaMap : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.ToTable("Respostas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.PerguntaId).IsRequired().HasColumnName("PerguntaId");
            builder.Property(x => x.Descricao).IsRequired().HasColumnName("Descricao").HasColumnType("varchar(1500)");
            builder.Property(x => x.Foto).HasColumnName("Foto");

            builder.HasOne(x => x.Pergunta).WithMany(x => x.Respostas);
        }
    }
}
