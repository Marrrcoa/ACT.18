using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basededatos.Shared.models
{
    public class Ventas
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Agrega la cantidad de productos a vender")]
        public int? Cantidad { get; set; }

        //[Required(ErrorMessage = "Agrega la FECHA de venta")]
        public string? Fecha { get; set; }

        //Muchos-muchos con la tabla Productos.
       public int? ProductoId { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
