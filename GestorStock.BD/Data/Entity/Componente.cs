using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Componente
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "La CANTIDAD de insumos es Obligatorio")]
        public int cantidad { get; set; }

        //Conexiones
    }
}
