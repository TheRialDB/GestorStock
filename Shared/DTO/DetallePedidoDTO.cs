using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.Shared.DTO
{
    public class DetallePedidoDTO
    {
        public int cantidad { get; set; }

        //Conexiones
        public int StockId { get; set; }
        public int NotaPedidoId { get; set; }
    }
}
