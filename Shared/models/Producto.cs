using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basededatos.Shared.models
{
    public class Producto
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "El Nombre no debe de ser vacio")]
        public string? Nombre { get; set; }

        //[Required(ErrorMessage = "Agrega las marcas que sean compatibles")]
        public string? Compatibilidad { get; set; }

        //[Required(ErrorMessage = "La marca no debe de ser vacia")]
        public string? Marca { get; set; }

        //Uno-Muchos con la tabla Invntario.
        public int? InventarioId { get; set; }
        public virtual Inventario? Inventario { get; set; }

        public virtual ICollection<Ventas>? Ventas { get; set; }

    }
}
