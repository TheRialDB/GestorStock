using GestorStock.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public DbSet<Componente> Componentes {get; set;}
        public DbSet<Deposito> Depositos => Set<Deposito>();
        public DbSet<DetallePedido> DetallePedidos => Set<DetallePedido>();
        public DbSet<Direccion> Direccion => Set<Direccion>();
        public DbSet<Envio> Envios => Set<Envio>();
        public DbSet<Estado> Estados => Set<Estado>();
        public DbSet<NotaPedido> notaPedidos => Set<NotaPedido>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Remito> Remitos => Set<Remito>();
        public DbSet<Unidad> Unidades => Set<Unidad>();
            



        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
