using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class NotaPedido
    {
        public int id { get; set; }

        [Required(ErrorMessage = "La Fecha del Pedido de Nota debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]

        public DateTime fechaPedido { get; set; }

        [Required(ErrorMessage = "El Emisor en la Nota de Pedido debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string emisor {  get; set; }

        [Required(ErrorMessage = "EL Receptor en la Nota de Pedido debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string receptor { get; set; }

        //Atributos
        public int idDetallePedido { get; set; }
        public DetallePedido detallePedido { get; set; }

      


    }
}
