using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppBackend.Models
{
    public partial class CursosBDContext : DbContext
    {
        public CursosBDContext()
        {
        }

        public CursosBDContext(DbContextOptions<CursosBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Certificado> Certificados { get; set; } = null!;
        public virtual DbSet<Cuestionario> Cuestionarios { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Inscripción> Inscripcións { get; set; } = null!;
        public virtual DbSet<Instructor> Instructors { get; set; } = null!;
        public virtual DbSet<MaterialEducativo> MaterialEducativos { get; set; } = null!;
        public virtual DbSet<Notificación> Notificacións { get; set; } = null!;
        public virtual DbSet<Preguntum> Pregunta { get; set; } = null!;
        public virtual DbSet<Retroalimentación> Retroalimentacións { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificado>(entity =>
            {
                entity.ToTable("Certificado");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaExpedicion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.Certificados)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("FK__Certifica__Curso__656C112C");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.Certificados)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("FK__Certifica__Estud__6477ECF3");
            });

            modelBuilder.Entity<Cuestionario>(entity =>
            {
                entity.ToTable("Cuestionario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaLimite).HasColumnType("datetime");

                entity.Property(e => e.Titulo).HasMaxLength(100);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("Curso");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Titulo).HasMaxLength(100);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Estudiante)
                    .HasForeignKey<Estudiante>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estudiante__ID__52593CB8");
            });

            modelBuilder.Entity<Inscripción>(entity =>
            {
                entity.ToTable("Inscripción");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalificacionFinal).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FechaInscripcion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Progreso).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.Inscripcións)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("FK__Inscripci__Curso__60A75C0F");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.Inscripcións)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("FK__Inscripci__Estud__5FB337D6");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("Instructor");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Especialidad).HasMaxLength(100);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Instructor)
                    .HasForeignKey<Instructor>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Instructor__ID__4F7CD00D");
            });

            modelBuilder.Entity<MaterialEducativo>(entity =>
            {
                entity.ToTable("MaterialEducativo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaSubida)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tipo).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Notificación>(entity =>
            {
                entity.ToTable("Notificación");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaEnvio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tipo).HasMaxLength(50);

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Notificacións)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK__Notificac__Usuar__693CA210");
            });

            modelBuilder.Entity<Preguntum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Retroalimentación>(entity =>
            {
                entity.ToTable("Retroalimentación");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.Retroalimentacións)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("FK__Retroalim__Curso__6E01572D");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.Retroalimentacións)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("FK__Retroalim__Estud__6D0D32F4");

                entity.HasOne(d => d.InstructorNavigation)
                    .WithMany(p => p.Retroalimentacións)
                    .HasForeignKey(d => d.Instructor)
                    .HasConstraintName("FK__Retroalim__Instr__6C190EBB");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105345C5A70F4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Clave).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Rol).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
