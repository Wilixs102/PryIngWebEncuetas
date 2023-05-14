using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaEncuestas_WP.Data;

public partial class EncuestaUdlaContext : DbContext
{
    public EncuestaUdlaContext()
    {
    }

    public EncuestaUdlaContext(DbContextOptions<EncuestaUdlaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Preguntum> Pregunta { get; set; }

    public virtual DbSet<Respuestum> Respuesta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=constring");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Preguntum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pregunta_PK");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaCreacion).HasColumnType("date");
            entity.Property(e => e.NombreArea)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pregunta)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Respuestum>(entity =>
        {
            entity.HasKey(e => e.IdRespuesta).HasName("Respuesta_PK");

            entity.Property(e => e.IdRespuesta).HasColumnName("ID_Respuesta");
            entity.Property(e => e.IdPregunta).HasColumnName("ID_Pregunta");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.IdPregunta)
                .HasConstraintName("Pregunta_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
