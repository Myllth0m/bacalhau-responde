using Domain.Entities;
using Infra.Maps;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PerguntaMap());
            modelBuilder.ApplyConfiguration(new RespostaMap());
        }
    }
}
