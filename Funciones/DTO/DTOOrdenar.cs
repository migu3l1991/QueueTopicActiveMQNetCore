using System;
using System.Collections.Generic;
using System.Text;

namespace Funciones.DTO
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