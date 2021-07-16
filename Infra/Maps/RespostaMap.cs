using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Maps
{
    public class RespostaMap : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.ToTable("RESPOSTAS", "BACALHAU");
            
            builder.HasKey(r => r.Id);
            
            builder.Property(r => r.Id).IsRequired().HasColumnName("ID");
            builder.Property(r => r.PerguntaId).IsRequired().HasColumnName("PERGUNTA_ID");
            builder.Property(r => r.Descricao).IsRequired().HasColumnName("DESCRICAO");
            builder.Property(r => r.Foto).HasColumnName("FOTO");
            builder.Property(r => r.DataDeCriacao).HasColumnName("DATA_DE_CRIACAO");
            builder.Property(r => r.DataDeAtualizacao).HasColumnName("DATA_DE_ATUALIZACAO");

            builder.HasOne(r => r.Pergunta).WithMany(p => p.Respostas);
        }
    }
}
