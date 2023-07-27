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
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE del DEPOSITO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE del DEPOSITO")]
        public string nombreDeposito { get; set; }

        //Conexiones
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }
        public int ObraId { get; set; }
        public Obra Obra { get; set; }
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
