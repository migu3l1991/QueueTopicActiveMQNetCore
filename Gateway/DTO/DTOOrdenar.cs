using System.Collections.Generic;

namespace Gateway.DTO
{
    public class DTOOrdenar
    {
        public string Organizacion { get; set; }
        public int ShippingId { get; set; }
        public List<DTOProductosOrden> Productos { get; set; }

        public DTOOrdenar(string organizacion, int shippingId, List<DTOProductosOrden> productos)
        {
            Organizacion = organizacion;
            ShippingId = shippingId;
            Productos = productos;
        }
    }
}