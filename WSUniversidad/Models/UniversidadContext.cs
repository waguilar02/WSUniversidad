using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSUniversidad.Models
{
    public partial class UniversidadContext : DbContext
    {
        public UniversidadContext()
        {
        }

        public UniversidadContext(DbContextOptions<UniversidadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<LogEventos> LogEventos { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }
        public virtual DbSet<RelMateriaAlumno> RelMateriaAlumno { get; set; }
        public virtual DbSet<RelMateriaProfesor> RelMateriaProfesor { get; set; }
        public virtual DbSet<RelMateriaSalon> RelMateriaSalon { get; set; }
        public virtual DbSet<Salones> Salones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Universidad;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.CodigoAlumno);

                entity.ToTable("alumnos");

                entity.Property(e => e.CodigoAlumno)
                    .HasColumnName("codigo_alumno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Carrera).HasColumnName("carrera");

                entity.Property(e => e.EstadoAlumno)
                    .IsRequired()
                    .HasColumnName("estado_alumno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogEventos>(entity =>
            {
                entity.ToTable("log_eventos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DescripcionEvento)
                    .IsRequired()
                    .HasColumnName("descripcion_evento")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEvento)
                    .HasColumnName("fecha_evento")
                    .HasColumnType("datetime");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ValorActual)
                    .HasColumnName("valor_actual")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorAnterior)
                    .HasColumnName("valor_anterior")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.CodigoMateria);

                entity.ToTable("materias");

                entity.Property(e => e.CodigoMateria)
                    .HasColumnName("codigo_materia")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreditosMateria).HasColumnName("creditos_materia");

                entity.Property(e => e.NombreMateria)
                    .IsRequired()
                    .HasColumnName("nombre_materia")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.ToTable("notas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodAlumno1).HasColumnName("cod_alumno1");

                entity.Property(e => e.CodMateria1).HasColumnName("cod_materia1");

                entity.Property(e => e.CodProfesor1).HasColumnName("cod_profesor1");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("decimal(16, 3)");

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.CodAlumno1Navigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.CodAlumno1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notas_alumnos");

                entity.HasOne(d => d.CodMateria1Navigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.CodMateria1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notas_materias");

                entity.HasOne(d => d.CodProfesor1Navigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.CodProfesor1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notas_profesores");
            });

            modelBuilder.Entity<Profesores>(entity =>
            {
                entity.HasKey(e => e.CodProfesor);

                entity.ToTable("profesores");

                entity.Property(e => e.CodProfesor)
                    .HasColumnName("cod_profesor")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RelMateriaAlumno>(entity =>
            {
                entity.ToTable("rel_materia_alumno");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodAlumno1).HasColumnName("cod_alumno1");

                entity.Property(e => e.CodMateria2).HasColumnName("cod_materia2");

                entity.HasOne(d => d.CodAlumno1Navigation)
                    .WithMany(p => p.RelMateriaAlumno)
                    .HasForeignKey(d => d.CodAlumno1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rel_materia_alumno_alumnos");

                entity.HasOne(d => d.CodMateria2Navigation)
                    .WithMany(p => p.RelMateriaAlumno)
                    .HasForeignKey(d => d.CodMateria2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rel_materia_alumno_materias");
            });

            modelBuilder.Entity<RelMateriaProfesor>(entity =>
            {
                entity.ToTable("rel_materia_profesor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodigoMateria3).HasColumnName("codigo_materia3");

                entity.Property(e => e.CodigoProfesor1).HasColumnName("codigo_profesor1");

                entity.HasOne(d => d.CodigoMateria3Navigation)
                    .WithMany(p => p.RelMateriaProfesor)
                    .HasForeignKey(d => d.CodigoMateria3)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rel_materia_profesor_materias");

                entity.HasOne(d => d.CodigoProfesor1Navigation)
                    .WithMany(p => p.RelMateriaProfesor)
                    .HasForeignKey(d => d.CodigoProfesor1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rel_materia_profesor_profesores");
            });

            modelBuilder.Entity<RelMateriaSalon>(entity =>
            {
                entity.ToTable("rel_materia_salon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodigoMateria4).HasColumnName("codigo_materia4");

                entity.Property(e => e.NroSalon1).HasColumnName("nro_salon1");

                entity.HasOne(d => d.CodigoMateria4Navigation)
                    .WithMany(p => p.RelMateriaSalon)
                    .HasForeignKey(d => d.CodigoMateria4)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rel_materia_salon_materias");

                entity.HasOne(d => d.NroSalon1Navigation)
                    .WithMany(p => p.RelMateriaSalon)
                    .HasForeignKey(d => d.NroSalon1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rel_materia_salon_salones");
            });

            modelBuilder.Entity<Salones>(entity =>
            {
                entity.HasKey(e => e.NumSalon);

                entity.ToTable("salones");

                entity.Property(e => e.NumSalon)
                    .HasColumnName("num_salon")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
