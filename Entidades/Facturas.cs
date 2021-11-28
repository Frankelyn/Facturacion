using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasWPF.Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public DateTime FechaFactura { get; set; } = DateTime.Now;
        public float MontoTotal { get; set; }
        public string NombreCliente { get; set; }

        [ForeignKey("FacturaId")]
        public virtual List<FacturasDetalle> Detalle { get; set; } = new List<FacturasDetalle>();


        


    }
}
