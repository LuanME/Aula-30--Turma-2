using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Aula_30_dia_15_07.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Instituicao> instituicoes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instituicao>()
                .ToTable("instituicoes")
                .HasKey(t => t.id);

            modelBuilder.Entity<Aluno>()
                .ToTable("alunos")
                .HasKey(t => t.id);

            modelBuilder.Entity<Instituicao>()
                .HasMany(t => t.alunos);

        }
        public DbSet<Aula_30_dia_15_07.Models.Aluno>? Aluno { get; set; }
       

    }
}
