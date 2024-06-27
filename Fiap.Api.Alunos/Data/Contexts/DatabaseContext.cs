using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<RepresentanteModel> Representantes { get; set; }
        public virtual DbSet<AlertaModel> Alertas { get; set; }
        public virtual DbSet<LocalizacaoModel> Localizacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepresentanteModel>(entity =>
            {
                entity.ToTable("Representantes");
                entity.HasKey(e => e.RepresentanteId);
                entity.Property(e => e.NomeRepresentante).IsRequired();
                entity.HasIndex(e => e.Cpf).IsUnique(); 
            });

            modelBuilder.Entity<AlertaModel>(entity =>
            {
                // Define o nome da tabela para 'Alertas'
                entity.ToTable("Alertas"); 
                entity.HasKey(e => e.AlertaId);
                entity.Property(e => e.Localizacao).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.TipoDesastre).IsRequired();
                entity.Property(e => e.DataHora).HasColumnType("date");
                entity.Property(e => e.Gravidade).HasMaxLength(500);

                // Configuração da relação com RepresentanteModel
                // Define a relação de um para um com RepresentanteModel
                entity.HasOne(e => e.Representante)
                    // Indica que um Representante pode ter muitos Alertas
                    .WithMany()
                    // Define a chave estrangeira
                    .HasForeignKey(e => e.RepresentanteId)
                    // Torna a chave estrangeira obrigatória
                    .IsRequired(); 
            });

            // Configuração para LocalizacaoModel
            modelBuilder.Entity<LocalizacaoModel>(entity =>
            {
                entity.ToTable("Localizacoes");
                entity.HasKey(p => p.LocalizacaoId);
                entity.Property(e => e.Latitude).IsRequired();
                entity.Property(e => e.Longitude).IsRequired();
                entity.Property(e => e.Nome).IsRequired();

                // Relacionamento com AlertaModel
                entity.HasOne(p => p.Alerta)
                      .WithMany()
                      .HasForeignKey(p => p.AlertaId);

            });

        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}
