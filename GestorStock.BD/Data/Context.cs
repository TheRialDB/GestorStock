using GestorStock.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data
{
    public class Context : DbContext
    {

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Obra> Obras => Set<Obra>();
        public DbSet<Deposito> Depositos => Set<Deposito>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Componente> Componentes => Set<Componente>();
        public DbSet<Unidad> Unidades => Set<Unidad>();
        public DbSet<DetallePedido> DetallePedidos => Set<DetallePedido>();
        public DbSet<Estado> Estados => Set<Estado>();
        public DbSet<NotaPedido> NotaPedidos => Set<NotaPedido>();
        public DbSet<Remito> Remitos => Set<Remito>();
        public DbSet<ProductoComponente> ProductoComponentes => Set<ProductoComponente>();

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.Entity<Deposito>()
            //    .HasOne(dep => dep.Direccion)
            //    .WithOne(dir => dir.Deposito)
            //.HasForeignKey<Direccion>(c => c.DepositoId);

            modelBuilder.Entity<ProductoComponente>()
        .HasKey(ec => new { ec.ProductoId, ec.ComponenteId });

            base.OnModelCreating(modelBuilder);
        }


    }
}
