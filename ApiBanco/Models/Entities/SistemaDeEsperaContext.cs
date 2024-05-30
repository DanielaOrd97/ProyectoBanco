using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ApiBanco.Models.Entities;

public partial class SistemaDeEsperaContext : DbContext
{
    public SistemaDeEsperaContext()
    {
    }

    public SistemaDeEsperaContext(DbContextOptions<SistemaDeEsperaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cajas> Cajas { get; set; }

    public virtual DbSet<Turnos> Turnos { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=SistemaDeEspera", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cajas>(entity =>
        {
            entity.HasKey(e => e.IdCaja).HasName("PRIMARY");

            entity.ToTable("cajas");

            entity.Property(e => e.NombreCaja).HasMaxLength(50);
        });

        modelBuilder.Entity<Turnos>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PRIMARY");

            entity.ToTable("turnos");

            entity.HasIndex(e => e.CajaId, "CajaId");

            entity.HasIndex(e => e.UsuarioId, "UsuarioId");

            entity.Property(e => e.EstadoTurno).HasMaxLength(20);

            entity.HasOne(d => d.Caja).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.CajaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("turnos_ibfk_2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("turnos_ibfk_1");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.Contraseña).HasMaxLength(50);
            entity.Property(e => e.FechaDeRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
