using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{

    [Index(nameof(correo), Name = "Usuario_correo_UQ", IsUnique =true)]
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "EL Nombre debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "EL Nombre del Usuario debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string nombreUsuario { get; set; }
        [Required(ErrorMessage = "EL Correo del Usuario debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string correo { get; set; }
        [Required(ErrorMessage = "La contrasena del Usuario debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string contrasena { get; set; }
        public int idRol { get; set; }

        public virtual Rol Rol { get; set; }


    }
}
