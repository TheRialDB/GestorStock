using System;
using System.Collections.Generic;
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
        public double cantidad { get; set; }

        [Required(ErrorMessage = "El ESTADO es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el ESTADO")]
        public string estado { get; set; }

        //Conexiones

        public int DepositoId { get; set; }
        public Deposito Depositos { get; set; }
    }
}
