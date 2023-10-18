using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.Shared.DTO
{
    public class NotaPedidoDTO
    {
        [Required(ErrorMessage = "La FECHA DEL PEDIDO es Obligatoria")]
        public DateTime fechaPedido { get; set; }

        [Required(ErrorMessage = "El nombre del EMISOR es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el nombre del EMISOR")]
        public string emisor { get; set; }

        [Required(ErrorMessage = "El nombre del RECEPTOR es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el RECEPTOR")]
        public string receptor { get; set; }

        public int EstadoId { get; set; }
    }
}
