﻿// <auto-generated />
using System;
using EntregasADomicilio.Web.Platillos.Repositorios.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntregasADomicilio.Web.Platillos.Repositorios.Sql.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240213203947_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntregasADomicilio.Web.Repositorios.Sql.Entities.Archivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AliasDelArchivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaDeRegistro")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NombreDelAlmacen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreDelArchivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatilloId")
                        .HasColumnType("int");

                    b.Property<string>("RutaDelArchivo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlatilloId");

                    b.ToTable("Archivo");
                });

            modelBuilder.Entity("EntregasADomicilio.Web.Repositorios.Sql.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("EntregasADomicilio.Web.Repositorios.Sql.Entities.Platillo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Platillo");
                });

            modelBuilder.Entity("EntregasADomicilio.Web.Repositorios.Sql.Entities.Archivo", b =>
                {
                    b.HasOne("EntregasADomicilio.Web.Repositorios.Sql.Entities.Platillo", "Platillo")
                        .WithMany("ListaDeArchivos")
                        .HasForeignKey("PlatilloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platillo");
                });

            modelBuilder.Entity("EntregasADomicilio.Web.Repositorios.Sql.Entities.Platillo", b =>
                {
                    b.HasOne("EntregasADomicilio.Web.Repositorios.Sql.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("EntregasADomicilio.Web.Repositorios.Sql.Entities.Platillo", b =>
                {
                    b.Navigation("ListaDeArchivos");
                });
#pragma warning restore 612, 618
        }
    }
}
