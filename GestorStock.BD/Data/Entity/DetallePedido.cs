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
        public int cantidad { get; set; }
    }
}
