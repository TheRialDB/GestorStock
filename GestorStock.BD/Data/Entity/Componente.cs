using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Componente
    {
        public int id { get; set; }


        //Conexiones
        public List<ProductoComponente> ProductoComponentes { get; set; } = new List<ProductoComponente>();

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
