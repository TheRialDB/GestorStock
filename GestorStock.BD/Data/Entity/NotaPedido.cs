using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class NotaPedido
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "La FECHA DEL PEDIDO es Obligatoria")]
        public DateTime fechaPedido { get; set; }

        [Required(ErrorMessage = "El codigo del deposito EMISOR de esta Solicitud es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el nombre del EMISOR")]
        public string codDepEmisor { get; set; }

        [Required(ErrorMessage = "El codigo del Deposito Solicitado es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el nombre del EMISOR")]
        public string codDepReceptor { get; set; }

        //[Required(ErrorMessage = "El Codigo del Producto es obligatorio")]
        [NotMapped] // Esta propiedad no se mapea a una entidad en la base de datos
        public List<string> CodStock { get; set; } = new List<string>();

        //[Required(ErrorMessage = "La Cantidad del Detalle Pedido debe ser OBLIGATORIO")]
        [NotMapped] // Esta propiedad no se mapea a una entidad en la base de datos
        public List<int> Cantidad { get; set; } = new List<int>();

        //Conexiones
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        //public List<Remito> Remitos { get; set; } = new List<Remito>();
        //public List<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
    }
}
