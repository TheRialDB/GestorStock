using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GestorStock.BD.Data.Entity
{
    public class Stock
    {
        public int id { get; set; }


        [Required(ErrorMessage = "La CANTIDAD es Obligatoria")]
		[Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero")]
		public double cantidad { get; set; }

        [Required(ErrorMessage = "El ESTADO es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el ESTADO")]
        public string estado { get; set; }

        //Conexiones

        [Required(ErrorMessage = "El PRODUCTO es Obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un producto")]
        public int ProductoId { get; set; }
        public Producto Productos { get; set; }

        [Required(ErrorMessage = "El DEPOSITO es Obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un deposito")]
        public int DepositoId { get; set; }
        public Deposito Depositos { get; set; }

        //public List<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
    }
}
