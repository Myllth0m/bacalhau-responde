using BacalhauResponde.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BacalhauResponde.Context
{
    public class BacalhauRespondeContexto : IdentityDbContext
    {
        private readonly IConfiguration configuracao;
        private readonly IHttpContextAccessor gerenciadorDeAcesso;
        public BacalhauRespondeContexto(
            IConfiguration configuracao,
            IHttpContextAccessor gerenciadorDeAcesso)
        {
            this.configuracao = configuracao;
            this.gerenciadorDeAcesso = gerenciadorDeAcesso;
        }

        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pergunta>().ToTable("Perguntas");
            builder.Entity<Resposta>().ToTable("Respostas");

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuracao.GetConnectionString("BacalhauRespondeContext"));
        }
    }
}
