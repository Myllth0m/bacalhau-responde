using System.Linq;
using System.Security.Claims;
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

        private string UserId => gerenciadorDeAcesso.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relacionamento in builder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
                relacionamento.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var propriedade in builder.Model.GetEntityTypes().SelectMany(x => x.GetProperties()).Where(x => x.ClrType == typeof(string)))
                propriedade.SetColumnType("varchar(200)");

            builder.HasDefaultSchema("BacalhauResponde");

            builder.Entity<Usuario>()
                   .ToTable("Usuarios");

            builder.Entity<Pergunta>()
                   .HasQueryFilter(x => x.UsuarioId == UserId)
                   .ToTable("Perguntas");

            builder.Entity<Resposta>()
                   .HasQueryFilter(x => x.UsuarioId == UserId)
                   .ToTable("Respostas");

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuracao.GetConnectionString("BacalhauRespondeContext"));
        }
    }
}
