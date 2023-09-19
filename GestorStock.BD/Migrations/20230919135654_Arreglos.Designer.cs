﻿// <auto-generated />
using System;
using GestorStock.BD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestorStock.BD.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230919135654_Arreglos")]
    partial class Arreglos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DepositoUsuario", b =>
                {
                    b.Property<int>("Depositosid")
                        .HasColumnType("int");

                    b.Property<int>("Usuariosid")
                        .HasColumnType("int");

                    b.HasKey("Depositosid", "Usuariosid");

                    b.HasIndex("Usuariosid");

                    b.ToTable("DepositoUsuario");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Componente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Componentes");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Deposito", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("nombreDeposito")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("ObraId");

                    b.ToTable("Depositos");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.DetallePedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("NotaPedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("NotaPedidoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallePedidos");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Estado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nombreEstado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.NotaPedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("emisor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("fechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<string>("receptor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("EstadoId");

                    b.ToTable("NotaPedidos");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Obra", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("nombreObra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("DepositoId")
                        .HasColumnType("int");

                    b.Property<int>("UnidadId")
                        .HasColumnType("int");

                    b.Property<double>("cantidad")
                        .HasColumnType("float");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("nombreProducto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("DepositoId");

                    b.HasIndex("UnidadId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.ProductoComponente", b =>
                {
                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("ComponenteId")
                        .HasColumnType("int");

                    b.HasKey("ProductoId", "ComponenteId");

                    b.HasIndex("ComponenteId");

                    b.ToTable("ProductoComponentes");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Remito", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("fechaEgreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaIngreso")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Remitos");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Rol", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Unidad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nombreUnidad")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("simbolo")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("id");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nombreUsuario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("NotaPedidoRemito", b =>
                {
                    b.Property<int>("NotaPedidosid")
                        .HasColumnType("int");

                    b.Property<int>("Remitosid")
                        .HasColumnType("int");

                    b.HasKey("NotaPedidosid", "Remitosid");

                    b.HasIndex("Remitosid");

                    b.ToTable("NotaPedidoRemito");
                });

            modelBuilder.Entity("DepositoUsuario", b =>
                {
                    b.HasOne("GestorStock.BD.Data.Entity.Deposito", null)
                        .WithMany()
                        .HasForeignKey("Depositosid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorStock.BD.Data.Entity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("Usuariosid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Deposito", b =>
                {
                    b.HasOne("GestorStock.BD.Data.Entity.Obra", "Obra")
                        .WithMany("Depositos")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.DetallePedido", b =>
                {
                    b.HasOne("GestorStock.BD.Data.Entity.NotaPedido", "NotaPedido")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("NotaPedidoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorStock.BD.Data.Entity.Producto", "Producto")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NotaPedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.NotaPedido", b =>
                {
                    b.HasOne("GestorStock.BD.Data.Entity.Estado", "Estado")
                        .WithMany("NotaPedidos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Obra", b =>
                {
                    b.HasOne("GestorStock.BD.Data.Entity.Estado", "Estado")
                        .WithMany("Obras")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Producto", b =>
                {
                    b.HasOne("GestorStock.BD.Data.Entity.Deposito", "Depositos")
                        .WithMany("Productos")
                        .HasForeignKey("DepositoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorStock.BD.Data.Entity.Unidad", "Unidad")
                        .WithMany("Productos")
                        .HasForeignKey("UnidadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Depositos");

                    b.Navigation("Unidad");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.ProductoComponente", b =>
                {
                    b.HasOne("GestorStock.BD.Data.Entity.Componente", "Componente")
                        .WithMany("ProductoComponentes")
                        .HasForeignKey("ComponenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorStock.BD.Data.Entity.Producto", "Producto")
                        .WithMany("ProductoComponentes")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Componente");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Usuario", b =>
                {
                    b.HasOne("GestorStock.BD.Data.Entity.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("NotaPedidoRemito", b =>
                {
                    b.HasOne("GestorStock.BD.Data.Entity.NotaPedido", null)
                        .WithMany()
                        .HasForeignKey("NotaPedidosid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestorStock.BD.Data.Entity.Remito", null)
                        .WithMany()
                        .HasForeignKey("Remitosid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Componente", b =>
                {
                    b.Navigation("ProductoComponentes");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Deposito", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Estado", b =>
                {
                    b.Navigation("NotaPedidos");

                    b.Navigation("Obras");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.NotaPedido", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Obra", b =>
                {
                    b.Navigation("Depositos");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Producto", b =>
                {
                    b.Navigation("DetallePedidos");

                    b.Navigation("ProductoComponentes");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("GestorStock.BD.Data.Entity.Unidad", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
