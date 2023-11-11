using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GestorStock.Shared.DTO
{
    public class DatosSolicitudDTO
    {

        public string Stock { get; set; }
        public int Cantidad { get; set; }

    }
}
