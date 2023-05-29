using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basededatos.Shared.models
{
    public class Inventario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Agrega la cantidad de productos en el inventario")]
        public int? Cantidad { get; set; }

        [Required(ErrorMessage = "Agrega la FECHA de actualizacion del inventario")]
        public string? Fecha { get; set; }

        [Required(ErrorMessage = "Agrega la UBICACION del producto")]
        public string? Ubicacion { get; set; }

        //Muchos-uno con la tabla Productos.
        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
