using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.Shared.DTO
{
    public class ProductoDTO
    {
        [Required(ErrorMessage = "El CODIGO del PRODUCTO es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el CODIGO")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "El NOMBRE del PRODUCTO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE")]
        public string nombreProducto { get; set; }

        [Required(ErrorMessage = "La DESCRIPCIÓN del PRODUCTO es Obligatoria")]
        [MaxLength(100, ErrorMessage = "Solo se aceptan hasta 100 caracteres en la DESCRIPCIÓN")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "La CANTIDAD es Obligatoria")]
        public double cantidad { get; set; }

        [Required(ErrorMessage = "El ESTADO es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el ESTADO")]
        public string estado { get; set; }

        //Conexiones
        public int DepositoId { get; set; }
        public int UnidadId { get; set; }
    }
}
