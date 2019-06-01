namespace Examen_UII_Web2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_Sistema : DbContext
    {
        public Model_Sistema()
            : base("name=Model_Sistema")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Criterio> Criterio { get; set; }
        public virtual DbSet<DetalleEvidencia> DetalleEvidencia { get; set; }
        public virtual DbSet<Evidencia> Evidencia { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Semestre> Semestre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.nombre_categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Criterio>()
                .Property(e => e.nombre_criterio)
                .IsUnicode(false);

            modelBuilder.Entity<Criterio>()
                .HasMany(e => e.DetalleEvidencia)
                .WithRequired(e => e.Criterio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evidencia>()
                .Property(e => e.archivo)
                .IsUnicode(false);

            modelBuilder.Entity<Evidencia>()
                .Property(e => e.tamanio)
                .IsUnicode(false);

            modelBuilder.Entity<Evidencia>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Evidencia>()
                .Property(e => e.url_archivo)
                .IsUnicode(false);

            modelBuilder.Entity<Evidencia>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Evidencia>()
                .HasMany(e => e.DetalleEvidencia)
                .WithRequired(e => e.Evidencia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Modelo>()
                .Property(e => e.nombre_modelo)
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .HasMany(e => e.Criterio)
                .WithRequired(e => e.Modelo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Modelo>()
                .HasMany(e => e.DetalleEvidencia)
                .WithRequired(e => e.Modelo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Modelo>()
                .HasMany(e => e.Evidencia)
                .WithRequired(e => e.Modelo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semestre>()
                .Property(e => e.nombre_semestre)
                .IsUnicode(false);

            modelBuilder.Entity<Semestre>()
                .HasMany(e => e.Evidencia)
                .WithRequired(e => e.Semestre)
                .WillCascadeOnDelete(false);
        }
    }
}
