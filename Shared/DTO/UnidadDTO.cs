using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.Shared.DTO
{
    public class UnidadDTO
    {
        [Required(ErrorMessage = "El NOMBRE de la UNIDAD es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el NOMBRE")]
        public string nombreUnidad { get; set; }

        [Required(ErrorMessage = "El SIMBOLO de la UNIDAD es Obligatorio")]
        [MaxLength(4, ErrorMessage = "Solo se aceptan hasta 4 caracteres en el SIMBOLO")]
        public string simbolo { get; set; }
    }
}
