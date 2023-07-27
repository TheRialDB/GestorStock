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
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE de la OBRA es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE")]
        public string nombreObra { get; set; }

        //Conexiones
        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }
        public List<Deposito> Depositos { get; set; } = new List<Deposito>();
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}
