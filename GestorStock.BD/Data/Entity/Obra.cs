using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Obra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre de la Obra debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string NombreObra { get; set; }

        [Required(ErrorMessage = "La Direccion de la Obra debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        //  public string Direccion { get; set; }



        //Atributos
        public int idEstado { get; set; }
        public Estado Estado { get; set; }

        public int idDeposito { get; set;}
        public Deposito Deposito { get; set; }


       
        
    }
}
