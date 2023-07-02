﻿using System;
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

        [Required(ErrorMessage = "EL Nombre del Rol debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string nombre { get; set; }

    }
}
