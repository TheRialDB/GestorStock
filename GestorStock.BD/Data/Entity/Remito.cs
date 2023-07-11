using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Remito
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El CÓDIGO del remito es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el CÓDIGO")]
        public string codigo { get; set; }
        public DateTime fechaEgreso { get; set; }
        public DateTime fechaIngreso { get; set; }
        [Required(ErrorMessage = "La DESCRIPCIÓN del remito es Obligatoria")]
        [MaxLength(150, ErrorMessage = "Solo se aceptan hasta 150 caracteres en la DESCRIPCIÓN")]
        public string descripcion { get; set; }

    }
}
