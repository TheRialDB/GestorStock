using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Usuario
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El NOMBRE DE USUARIO es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el NOMBRE DE USUARIO")]
        public string nombreUsuario { get; set; }

        [Required(ErrorMessage = "El CORREO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el CORREO")]
        public string correo { get; set; }

        [Required(ErrorMessage = "La CONTRASEÑA es Obligatoria")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en la CONTRASEÑA")]
        public string contrasena { get; set; }

        //Conexiones
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public List<Deposito> Depositos { get; set; } = new List<Deposito>();

    }
}
