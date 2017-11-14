using System.ComponentModel.DataAnnotations.Schema;

namespace Funciones.Model
{
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SKU { get; set; }
        public string Cantidad { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }

        public int IdFactura { get; set; }
        public Factura Factura { get; set; }
    }
}
