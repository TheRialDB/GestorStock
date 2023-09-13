using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class ProductoComponente
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int ComponenteId { get; set; }
        public Componente Componente { get; set; }
    }
}
