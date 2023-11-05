using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.Shared.DTO
{
    public class DepositoDTO
    {
        [Required]
        public string codDeposito { get; set; }

        [Required(ErrorMessage = "El NOMBRE del DEPOSITO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE del DEPOSITO")]
        public string nombreDeposito { get; set; }

        [Required(ErrorMessage = "La DIRECCIÓN de la OBRA es Obligatoria")]
        [MaxLength(150, ErrorMessage = "Solo se aceptan hasta 150 caracteres en la DIRECCIÓN")]
        public string direccion { get; set; }

        //Conexiones
        public int ObraId { get; set; }
    }
}
