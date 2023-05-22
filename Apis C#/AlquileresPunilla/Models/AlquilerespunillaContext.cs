using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlquileresPunilla.Models;

public partial class AlquilerespunillaContext : DbContext
{
    public AlquilerespunillaContext()
    {
    }

    public AlquilerespunillaContext(DbContextOptions<AlquilerespunillaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alojamiento> Alojamientos { get; set; }

    public virtual DbSet<Complejo> Complejos { get; set; }

    public virtual DbSet<Detalleestadium> Detalleestadia { get; set; }

    public virtual DbSet<Estadia> Estadias { get; set; }

    public virtual DbSet<Estadoestadium> Estadoestadia { get; set; }

    public virtual DbSet<Formasdepago> Formasdepagos { get; set; }

    public virtual DbSet<Localidade> Localidades { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Tipospago> Tipospagos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<ImagenesAlojamiento> ImagenesAlojamientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql("server=localhost;database=alquilerespunilla;user=root;pwd=42218872Anto", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alojamiento>(entity =>
        {
            entity.HasKey(e => e.IdAlojamientos).HasName("PRIMARY");

            entity.ToTable("alojamientos");

            entity.HasIndex(e => e.IdComplejo, "Fk_complejos_idx");

            entity.Property(e => e.IdAlojamientos).HasColumnName("idAlojamientos");
            entity.Property(e => e.Descripcion).HasMaxLength(45);

            entity.HasOne(d => d.IdComplejoNavigation).WithMany(p => p.Alojamientos)
                .HasForeignKey(d => d.IdComplejo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_complejos");
        });

        modelBuilder.Entity<Complejo>(entity =>
        {
            entity.HasKey(e => e.IdComplejo).HasName("PRIMARY");

            entity.ToTable("complejos");

            entity.Property(e => e.NombreComplejo).HasMaxLength(45);
        });

        modelBuilder.Entity<Detalleestadium>(entity =>
        {
            entity.HasKey(e => e.IdDetalleEstadia).HasName("PRIMARY");

            entity.ToTable("detalleestadia");

            entity.HasIndex(e => e.IdEstadia, "Fk_Estadia_idx");

            entity.HasIndex(e => e.IdPago, "Fk_Pagos_idx");

            entity.Property(e => e.IdDetalleEstadia).HasColumnName("idDetalleEstadia");

            entity.HasOne(d => d.IdEstadiaNavigation).WithMany(p => p.Detalleestadia)
                .HasForeignKey(d => d.IdEstadia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Estadia");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.Detalleestadia)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Pagos");
        });

        modelBuilder.Entity<Estadia>(entity =>
        {
            entity.HasKey(e => e.NroEstadia).HasName("PRIMARY");

            entity.ToTable("estadias");

            entity.HasIndex(e => e.IdAlojamiento, "Fk_Alojameinto_idx");

            entity.HasIndex(e => e.IdEstado, "Fk_Estado_idx");

            entity.HasIndex(e => e.IdPersona, "Fk_Persona_idx");

            entity.HasOne(d => d.IdAlojamientoNavigation).WithMany(p => p.Estadia)
                .HasForeignKey(d => d.IdAlojamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Alojameinto");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Estadia)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Estado");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Estadia)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Persona");
        });

        modelBuilder.Entity<Estadoestadium>(entity =>
        {
            entity.HasKey(e => e.IdEstadoEstadia).HasName("PRIMARY");

            entity.ToTable("estadoestadia");

            entity.Property(e => e.IdEstadoEstadia).HasColumnName("idEstadoEstadia");
            entity.Property(e => e.Descripcion).HasMaxLength(45);
        });

        modelBuilder.Entity<Formasdepago>(entity =>
        {
            entity.HasKey(e => e.IdFormasDePagos).HasName("PRIMARY");

            entity.ToTable("formasdepagos");

            entity.Property(e => e.IdFormasDePagos).HasColumnName("idFormasDePagos");
            entity.Property(e => e.Descripcion).HasMaxLength(45);
        });

        modelBuilder.Entity<Localidade>(entity =>
        {
            entity.HasKey(e => e.IdLocalidades).HasName("PRIMARY");

            entity.ToTable("localidades");

            entity.HasIndex(e => e.IdProvicia, "fkPro-Loc_idx");

            entity.Property(e => e.IdLocalidades)
                .ValueGeneratedNever()
                .HasColumnName("idLocalidades");
            entity.Property(e => e.Descripcion).HasMaxLength(45);

            entity.HasOne(d => d.IdProviciaNavigation).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.IdProvicia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkPro-Loc");
        });
         modelBuilder.Entity<ImagenesAlojamiento>(entity =>
        {
            entity.HasKey(e => e.idImagenes).HasName("PRIMARY");

            entity.ToTable("imagenesalojamiento");

            entity.HasIndex(e => e.idAlojamiento, "fk-img-Alojamiento_idx");

            entity.Property(e => e.idImagenes)
                .ValueGeneratedNever()
                .HasColumnName("idImagenes");
            entity.Property(e => e.LinkFotos).HasMaxLength(150);

            entity.HasOne(d => d.IdAlojamientoNavigation).WithMany(p => p.ImagenesAlojamiento)
                .HasForeignKey(d => d.idAlojamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk-img-Alojamiento");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPagos).HasName("PRIMARY");

            entity.ToTable("pagos");

            entity.HasIndex(e => e.IdFormaPago, "Fk_forrmasdepago_idx");

            entity.HasIndex(e => e.IdTipoPago, "Fk_tipoPagos_idx");

            entity.Property(e => e.IdPagos).HasColumnName("idPagos");

            entity.HasOne(d => d.IdFormaPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdFormaPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_forrmasdepago");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdTipoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_tipoPagos");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Idpersona).HasName("PRIMARY");

            entity.ToTable("personas");

            entity.HasIndex(e => e.IdLocalidad, "fk_localidad_idx");

            entity.Property(e => e.Idpersona).HasColumnName("idpersona");
            entity.Property(e => e.Apellido).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Telefono).HasMaxLength(45);

            entity.HasOne(d => d.IdLocalidadNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdLocalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_localidad");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("PRIMARY");

            entity.ToTable("provincias");

            entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");
            entity.Property(e => e.Descripcion).HasMaxLength(45);
        });

        modelBuilder.Entity<Tipospago>(entity =>
        {
            entity.HasKey(e => e.IdTiposPagos).HasName("PRIMARY");

            entity.ToTable("tipospagos");

            entity.Property(e => e.IdTiposPagos).HasColumnName("idTiposPagos");
            entity.Property(e => e.Descripcion).HasMaxLength(45);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.IdComplejo, "IdComplejo_idx");

            entity.Property(e => e.IdUsuarios).HasColumnName("idUsuarios");
            entity.Property(e => e.Contraseña).HasMaxLength(45);
            entity.Property(e => e.NombreUsuario).HasMaxLength(45);

            entity.HasOne(d => d.IdComplejoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdComplejo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdComplejo");
        });
       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
