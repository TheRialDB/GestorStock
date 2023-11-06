using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class ProductoComponente
    {
        [Required(ErrorMessage = "El PRODUCTO es Obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione el PRODUCTO")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "El COMPONENTE es Obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un COMPONENTE")]
        public int ComponenteId { get; set; }
        public Componente Componente { get; set; }

        [Required(ErrorMessage = "La CANTIDAD de insumos es Obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int cantidad { get; set; }
    }
}
