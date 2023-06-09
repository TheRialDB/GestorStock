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
        public DbSet<ProductoSimple> ProductosSimples => Set<ProductoSimple>();
        public DbSet<ProductoCompuesto> ProductosCompuestos => Set<ProductoCompuesto>();
        public DbSet<Unidad> Unidades => Set<Unidad>();

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
