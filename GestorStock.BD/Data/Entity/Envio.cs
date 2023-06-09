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

        [Required(ErrorMessage = "El ORIGEN del ENVIO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el ORIGEN")]
        public string origen { get; set; }

        [Required(ErrorMessage = "El DESTINO del ENVIO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el DESTINO")]
        public string destino { get; set; }

        [Required(ErrorMessage = "El ESTADO del ENVIO es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el ESTADO")]
        public string estadoEnvio { get; set; }

        [Required(ErrorMessage = "El NÚMERO del REMITO es Obligatorio")]
        [MaxLength(60, ErrorMessage = "Solo se aceptan hasta 60 caracteres en el NÚMERO de REMITO")]
        public string nroRemito { get; set; }
    }
}
