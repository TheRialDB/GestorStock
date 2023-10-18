using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Unidad
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE de la UNIDAD es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el NOMBRE")]
        public string nombreUnidad { get; set; }

        [Required(ErrorMessage = "El SIMBOLO de la UNIDAD es Obligatorio")]
        [MaxLength(4, ErrorMessage = "Solo se aceptan hasta 4 caracteres en el SIMBOLO")]
        public string simbolo { get; set; }

        //Conexiones
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
