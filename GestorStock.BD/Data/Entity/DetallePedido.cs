using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class DetallePedido
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "La Cantidad del Detalle Pedido debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public int cantidad { get; set; }

        //Conexiones
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int NotaPedidoId { get; set; }
        public NotaPedido NotaPedido { get; set; }

    }
}
