using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Deposito
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE del DEPOSITO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE del DEPOSITO")]
        public string nombreDeposito { get; set; }

        [Required(ErrorMessage = "La DIRECCIÓN del DEPOSITO es Obligatoria")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en la DIRECCIÓN del DEPOSITO")]
        public string direccionDeposito { get; set; }
    }
}
