using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.Shared.DTO
{
    public class StockDTO
    {
        [Required(ErrorMessage = "La CANTIDAD es Obligatoria")]
        public double cantidad { get; set; }

        [Required(ErrorMessage = "El ESTADO es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el ESTADO")]
        public string estado { get; set; }

        public int DepositoId { get; set; }

        public int ProductoId { get; set; }

    }
}
