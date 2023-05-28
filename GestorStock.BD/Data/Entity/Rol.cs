using System;
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

        public string nombre { get; set; }

    }
}
