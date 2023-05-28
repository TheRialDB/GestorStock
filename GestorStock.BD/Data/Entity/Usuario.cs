using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }
        [Required]
        public string nombreUsuario { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string contrasena { get; set; }
        public int idRol {get; set; }

        public virtual Rol Rol { get; set; }


    }
}
