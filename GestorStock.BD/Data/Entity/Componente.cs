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
        public int ID { get; set; }

        
        public int idComponentes { get; set; }

        [Required(ErrorMessage = "La Cantidad del Componente debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public int cantidad { get; set; }

      






    }
}
