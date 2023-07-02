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
        public int ID { get; set; }

        [Required(ErrorMessage = "El Nombre del Deposito debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string NombreDeposito { get; set; }

        [Required(ErrorMessage = "La Direccion del Deposito debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string DireccionDeposito { get; set; }
    }
}
