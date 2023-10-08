using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Envio
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El origen del envio debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string origen { get; set; }

        [Required(ErrorMessage = "el destino del envio debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string destino { get; set; }

        //Atributos
        public int idEstado { get; set; }
        public Estado Estado { get; set; }
    }
}
