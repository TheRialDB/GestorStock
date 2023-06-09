using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Solicitud
    {
        public int id { get; set; }

        [Required(ErrorMessage = "La DESCRIPCIÓN es Obligatoria")]
        [MaxLength(100, ErrorMessage = "Solo se aceptan hasta 100 caracteres en la DESCRIPCIÓN")]
        public string descripcion { get; set; }

    }
}
