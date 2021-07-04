using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Maps
{
    public class PerguntaMap : IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {
            builder.ToTable("PERGUNTAS", "BACALHAU");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.Titulo).IsRequired().HasColumnName("TITULO");
            builder.Property(p => p.Descricao).IsRequired().HasColumnName("DESCRICAO");
            builder.Property(p => p.Foto).HasColumnName("FOTO");

            builder.HasMany(p => p.Respostas).WithOne(r => r.Pergunta);
        }
    }
}
