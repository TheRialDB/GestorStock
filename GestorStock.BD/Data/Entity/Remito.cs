using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Remito
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El Codigo del Remito debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "La Fecha de Egreso del Remito debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public DateTime fechaEgreso { get; set; }

        [Required(ErrorMessage = "La Fecha de Ingreso del Remito debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public DateTime fechaIngreso { get; set; }

        [Required(ErrorMessage = "La Descrpcion del Remito debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string descripcion { get; set; }

        // Atributos 

        public int idNotaPedido {get; set; }
        
        public NotaPedido NotaPedido { get; set; }  

        public int idEstado { get; set; }

        public Estado estado { get; set; }  


    }
}
