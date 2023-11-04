using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.Shared.DTO
{
    public class ProductoComponenteDTO
    {
        public int ProductoId { get; set; }
        public int ComponenteId { get; set; }
        [Required(ErrorMessage = "La CANTIDAD de insumos es Obligatorio")]
        public int cantidad { get; set; }
    }
}
