using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasWPF.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public float Costo { get; set; }
        public float Precio { get; set; }

    }
}
