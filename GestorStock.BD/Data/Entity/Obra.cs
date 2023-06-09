using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Obra
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE de la OBRA es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE")]
        public string nombreObra { get; set; }

        [Required(ErrorMessage = "La DIRECCIÓN de la OBRA es Obligatoria")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en la DIRECCIÓN")]
        public string direccionObra { get; set; }

        [Required(ErrorMessage = "El ESTADO de la OBRA es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el ESTADO")]
        public string estadoObra { get; set; }

        [Required(ErrorMessage = "El CLIENTE es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el CLIENTE")]
        public string cliente { get; set; }
    }
}
