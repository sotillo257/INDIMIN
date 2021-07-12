﻿// <auto-generated />
using AccesoDato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace INDIMIN.Migrations
{
    [DbContext(typeof(Conexion))]
    [Migration("20210711154455_UsuariosId")]
    partial class UsuariosId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Modelo.Ciudadano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ciudadano");
                });

            modelBuilder.Entity("Modelo.CuentaAxie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nick")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoninWallet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuariosId");

                    b.ToTable("CuentaAxie");
                });

            modelBuilder.Entity("Modelo.DiaSemana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiaSemana");
                });

            modelBuilder.Entity("Modelo.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CiudadanoId")
                        .HasColumnType("int");

                    b.Property<int>("DiaSemanaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CiudadanoId");

                    b.HasIndex("DiaSemanaId");

                    b.ToTable("Tarea");
                });

            modelBuilder.Entity("Modelo.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Modelo.CuentaAxie", b =>
                {
                    b.HasOne("Modelo.Usuarios", null)
                        .WithMany("CuentasAxie")
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Modelo.Tarea", b =>
                {
                    b.HasOne("Modelo.Ciudadano", "Ciudadano")
                        .WithMany("Tareas")
                        .HasForeignKey("CiudadanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.DiaSemana", "DiaSemana")
                        .WithMany()
                        .HasForeignKey("DiaSemanaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudadano");

                    b.Navigation("DiaSemana");
                });

            modelBuilder.Entity("Modelo.Ciudadano", b =>
                {
                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("Modelo.Usuarios", b =>
                {
                    b.Navigation("CuentasAxie");
                });
#pragma warning restore 612, 618
        }
    }
}
