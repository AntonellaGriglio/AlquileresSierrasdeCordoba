﻿// <auto-generated />
using System;
using AlquileresPunilla.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlquileresPunilla.Migrations
{
    [DbContext(typeof(AlquilerespunillaContext))]
    [Migration("20230410191940_imagenesalojamientos")]
    partial class imagenesalojamientos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("AlquileresPunilla.Models.Alojamiento", b =>
                {
                    b.Property<int>("IdAlojamientos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idAlojamientos");

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("IdComplejo")
                        .HasColumnType("int");

                    b.Property<string>("LinkFotos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdAlojamientos")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdComplejo" }, "Fk_complejos_idx");

                    b.ToTable("alojamientos", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Complejo", b =>
                {
                    b.Property<int>("IdComplejo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LinkFotos")
                        .HasColumnType("longtext");

                    b.Property<string>("NombreComplejo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdComplejo")
                        .HasName("PRIMARY");

                    b.ToTable("complejos", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Detalleestadium", b =>
                {
                    b.Property<int>("IdDetalleEstadia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDetalleEstadia");

                    b.Property<int>("IdEstadia")
                        .HasColumnType("int");

                    b.Property<int>("IdPago")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleEstadia")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEstadia" }, "Fk_Estadia_idx");

                    b.HasIndex(new[] { "IdPago" }, "Fk_Pagos_idx");

                    b.ToTable("detalleestadia", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Estadia", b =>
                {
                    b.Property<int>("NroEstadia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantPersonas")
                        .HasColumnType("int");

                    b.Property<sbyte>("Desayuno")
                        .HasColumnType("tinyint");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaEgreso")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<int>("IdAlojamiento")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("ImporteTotal")
                        .HasColumnType("int");

                    b.HasKey("NroEstadia")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdAlojamiento" }, "Fk_Alojameinto_idx");

                    b.HasIndex(new[] { "IdEstado" }, "Fk_Estado_idx");

                    b.HasIndex(new[] { "IdPersona" }, "Fk_Persona_idx");

                    b.ToTable("estadias", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Estadoestadium", b =>
                {
                    b.Property<int>("IdEstadoEstadia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idEstadoEstadia");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdEstadoEstadia")
                        .HasName("PRIMARY");

                    b.ToTable("estadoestadia", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Formasdepago", b =>
                {
                    b.Property<int>("IdFormasDePagos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idFormasDePagos");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdFormasDePagos")
                        .HasName("PRIMARY");

                    b.ToTable("formasdepagos", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.ImagenesAlojamiento", b =>
                {
                    b.Property<int>("idImagenes")
                        .HasColumnType("int")
                        .HasColumnName("idImagenes");

                    b.Property<string>("LinkFotos")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("idAlojamiento")
                        .HasColumnType("int");

                    b.HasKey("idImagenes")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "idAlojamiento" }, "fk-img-Alojamiento_idx");

                    b.ToTable("imagenesalojamientos", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Localidade", b =>
                {
                    b.Property<int>("IdLocalidades")
                        .HasColumnType("int")
                        .HasColumnName("idLocalidades");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("IdProvicia")
                        .HasColumnType("int");

                    b.HasKey("IdLocalidades")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdProvicia" }, "fkPro-Loc_idx");

                    b.ToTable("localidades", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Pago", b =>
                {
                    b.Property<int>("IdPagos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPagos");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("IdFormaPago")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPago")
                        .HasColumnType("int");

                    b.Property<int>("Importe")
                        .HasColumnType("int");

                    b.HasKey("IdPagos")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdFormaPago" }, "Fk_forrmasdepago_idx");

                    b.HasIndex(new[] { "IdTipoPago" }, "Fk_tipoPagos_idx");

                    b.ToTable("pagos", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Persona", b =>
                {
                    b.Property<int>("Idpersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idpersona");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<sbyte>("Estado")
                        .HasColumnType("tinyint");

                    b.Property<int>("IdLocalidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Idpersona")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdLocalidad" }, "fk_localidad_idx");

                    b.ToTable("personas", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Provincia", b =>
                {
                    b.Property<int>("IdProvincia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idProvincia");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdProvincia")
                        .HasName("PRIMARY");

                    b.ToTable("provincias", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Tipospago", b =>
                {
                    b.Property<int>("IdTiposPagos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTiposPagos");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdTiposPagos")
                        .HasName("PRIMARY");

                    b.ToTable("tipospagos", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuarios")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUsuarios");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("IdComplejo")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdUsuarios")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdComplejo" }, "IdComplejo_idx");

                    b.ToTable("usuarios", (string)null);
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Alojamiento", b =>
                {
                    b.HasOne("AlquileresPunilla.Models.Complejo", "IdComplejoNavigation")
                        .WithMany("Alojamientos")
                        .HasForeignKey("IdComplejo")
                        .IsRequired()
                        .HasConstraintName("Fk_complejos");

                    b.Navigation("IdComplejoNavigation");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Detalleestadium", b =>
                {
                    b.HasOne("AlquileresPunilla.Models.Estadia", "IdEstadiaNavigation")
                        .WithMany("Detalleestadia")
                        .HasForeignKey("IdEstadia")
                        .IsRequired()
                        .HasConstraintName("Fk_Estadia");

                    b.HasOne("AlquileresPunilla.Models.Pago", "IdPagoNavigation")
                        .WithMany("Detalleestadia")
                        .HasForeignKey("IdPago")
                        .IsRequired()
                        .HasConstraintName("Fk_Pagos");

                    b.Navigation("IdEstadiaNavigation");

                    b.Navigation("IdPagoNavigation");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Estadia", b =>
                {
                    b.HasOne("AlquileresPunilla.Models.Alojamiento", "IdAlojamientoNavigation")
                        .WithMany("Estadia")
                        .HasForeignKey("IdAlojamiento")
                        .IsRequired()
                        .HasConstraintName("Fk_Alojameinto");

                    b.HasOne("AlquileresPunilla.Models.Estadoestadium", "IdEstadoNavigation")
                        .WithMany("Estadia")
                        .HasForeignKey("IdEstado")
                        .IsRequired()
                        .HasConstraintName("Fk_Estado");

                    b.HasOne("AlquileresPunilla.Models.Persona", "IdPersonaNavigation")
                        .WithMany("Estadia")
                        .HasForeignKey("IdPersona")
                        .IsRequired()
                        .HasConstraintName("Fk_Persona");

                    b.Navigation("IdAlojamientoNavigation");

                    b.Navigation("IdEstadoNavigation");

                    b.Navigation("IdPersonaNavigation");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.ImagenesAlojamiento", b =>
                {
                    b.HasOne("AlquileresPunilla.Models.Alojamiento", "IdAlojamientoNavigation")
                        .WithMany("ImagenesAlojamiento")
                        .HasForeignKey("idAlojamiento")
                        .IsRequired()
                        .HasConstraintName("fk-img-Alojamiento");

                    b.Navigation("IdAlojamientoNavigation");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Localidade", b =>
                {
                    b.HasOne("AlquileresPunilla.Models.Provincia", "IdProviciaNavigation")
                        .WithMany("Localidades")
                        .HasForeignKey("IdProvicia")
                        .IsRequired()
                        .HasConstraintName("fkPro-Loc");

                    b.Navigation("IdProviciaNavigation");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Pago", b =>
                {
                    b.HasOne("AlquileresPunilla.Models.Formasdepago", "IdFormaPagoNavigation")
                        .WithMany("Pagos")
                        .HasForeignKey("IdFormaPago")
                        .IsRequired()
                        .HasConstraintName("Fk_forrmasdepago");

                    b.HasOne("AlquileresPunilla.Models.Tipospago", "IdTipoPagoNavigation")
                        .WithMany("Pagos")
                        .HasForeignKey("IdTipoPago")
                        .IsRequired()
                        .HasConstraintName("Fk_tipoPagos");

                    b.Navigation("IdFormaPagoNavigation");

                    b.Navigation("IdTipoPagoNavigation");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Persona", b =>
                {
                    b.HasOne("AlquileresPunilla.Models.Localidade", "IdLocalidadNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdLocalidad")
                        .IsRequired()
                        .HasConstraintName("fk_localidad");

                    b.Navigation("IdLocalidadNavigation");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Usuario", b =>
                {
                    b.HasOne("AlquileresPunilla.Models.Complejo", "IdComplejoNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdComplejo")
                        .IsRequired()
                        .HasConstraintName("IdComplejo");

                    b.Navigation("IdComplejoNavigation");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Alojamiento", b =>
                {
                    b.Navigation("Estadia");

                    b.Navigation("ImagenesAlojamiento");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Complejo", b =>
                {
                    b.Navigation("Alojamientos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Estadia", b =>
                {
                    b.Navigation("Detalleestadia");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Estadoestadium", b =>
                {
                    b.Navigation("Estadia");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Formasdepago", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Localidade", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Pago", b =>
                {
                    b.Navigation("Detalleestadia");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Persona", b =>
                {
                    b.Navigation("Estadia");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Provincia", b =>
                {
                    b.Navigation("Localidades");
                });

            modelBuilder.Entity("AlquileresPunilla.Models.Tipospago", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
