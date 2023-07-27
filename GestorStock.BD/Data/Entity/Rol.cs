using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Rol
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE del ROL es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el nombre del ROL")]

        public string nombre { get; set; }

        //Conexiones
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

    }
}
