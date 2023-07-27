using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Direccion
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "El NOMBRE de la Dirección es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en la DIRECCIÓN")]
        public string nombreDireccion { get; set; }

        //Conexiones
        public int DepositoId{ get; set; }
        public Deposito Deposito { get; set; }
        public int ObraId { get; set; }
        public Obra Obra { get; set; }
    }
}
