using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Producto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El Codigo del Producto debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string codigo {  get; set; }

        [Required(ErrorMessage = "El Nombre del Producto debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string nombreProducto { get; set; }

        [Required(ErrorMessage = "La Descripcion del Producto debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string descripcion { get; set;}

        [Required(ErrorMessage = "La Cantidad del Producto debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string cantidad { get; set; }


        //Atributos
        public int idUnidad { get; set; }
        public Unidad unidad { get; set; }

        public int IdComponente { get; set; }

        public Componente componente { get; set; }  



    }
}
