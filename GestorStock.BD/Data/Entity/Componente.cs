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


        //[Required(ErrorMessage = "El NOMBRE del COMPONENTE es Obligatorio")]
        //[MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE")]
        //public string nombreComponente { get; set; }

        //[Required(ErrorMessage = "La CANTIDAD de insumos es Obligatorio")]
        //public int cantidad { get; set; }

        //Conexiones
        public List<ProductoComponente> ProductoComponentes { get; set; } = new List<ProductoComponente>();

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
