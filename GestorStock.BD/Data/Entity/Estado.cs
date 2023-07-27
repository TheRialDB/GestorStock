using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorStock.BD.Data.Entity
{
    public class Estado
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE del ESTADO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el ESTADO")]
        public string nombreEstado { get; set; }

        //Conexiones
        public int ObraId { get; set; }
        public Obra Obra { get; set; }
        public List<NotaPedido> NotaPedidos { get; set; } = new List<NotaPedido>();
    }
}
