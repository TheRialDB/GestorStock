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
        public DbSet<Solicitud> Solicitudes => Set<Solicitud>();
        public DbSet<Envio> Envios => Set<Envio>();
        public DbSet<Obra> Obras => Set<Obra>();
        public DbSet<Deposito> Depositos => Set<Deposito>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Componente> Componentes => Set<Componente>();
        public DbSet<Unidad> Unidades => Set<Unidad>();
        public DbSet<Direccion> Direcciones => Set<Direccion>();
        public DbSet<DetallePedido> DetallePedidos => Set<DetallePedido>();
        public DbSet<Estado> Estados => Set<Estado>();
        public DbSet<NotaPedido> NotaPedidos => Set<NotaPedido>();
        public DbSet<Remito> Remitos => Set<Remito>();

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
