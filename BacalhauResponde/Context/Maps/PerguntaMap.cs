using BacalhauResponde.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BacalhauResponde.Context.Maps
{
    public class PerguntaMap : IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {
            builder.ToTable("Perguntas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Titulo).IsRequired().HasColumnName("Titulo").HasColumnType("varchar(200)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnName("Descricao").HasColumnType("varchar(1500)");
            builder.Property(x => x.Foto).HasColumnName("Foto");

            builder.HasMany(x => x.Respostas).WithOne(x => x.Pergunta);
        }
    }
}
