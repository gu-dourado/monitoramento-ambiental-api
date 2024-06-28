using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<RepresentanteModel> Representantes { get; set; }
        public virtual DbSet<AlertaModel> Alertas { get; set; }
        public virtual DbSet<LocalizacaoModel> Localizacoes { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepresentanteModel>(entity =>
            {
                entity.ToTable("Representantes");
                entity.HasKey(e => e.RepresentanteId);
                entity.Property(e => e.Nome).IsRequired();
                entity.HasIndex(e => e.Cpf).IsUnique();
            });

            modelBuilder.Entity<AlertaModel>(entity =>
            {
                entity.ToTable("Alertas");
                entity.HasKey(e => e.AlertaId);
                entity.Property(e => e.Local).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.TipoDesastre).IsRequired();
                entity.Property(e => e.DataHora).HasColumnType("date");
                entity.Property(e => e.Gravidade).HasMaxLength(500);
            });

            modelBuilder.Entity<LocalizacaoModel>(entity =>
            {
                entity.ToTable("Localizacoes");
                entity.HasKey(p => p.LocalizacaoId);
                entity.Property(e => e.Latitude).IsRequired();
                entity.Property(e => e.Longitude).IsRequired();
                
            });
        }
    }
}
