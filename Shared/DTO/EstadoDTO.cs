using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.Shared.DTO
{
    public class EstadoDTO
    {
        [Required(ErrorMessage = "El NOMBRE del ESTADO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el ESTADO")]
        public string nombreEstado { get; set; }
    }
}
