using System.Linq;
using BacalhauResponde.Context.Maps;
using BacalhauResponde.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BacalhauResponde.Context
{
    public class BacalhauRespondeContexto : IdentityDbContext
    {
        private readonly IConfiguration configuracao;
        public BacalhauRespondeContexto(IConfiguration configuracao) => this.configuracao = configuracao;

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
                   .ToTable("Usuarios")
                   .HasIndex(x => x.UserName)
                   .IsUnique(false);

            builder.ApplyConfiguration(new PerguntaMap());
            builder.ApplyConfiguration(new RespostaMap());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuracao.GetConnectionString("BacalhauRespondeContext"));
        }
    }
}
