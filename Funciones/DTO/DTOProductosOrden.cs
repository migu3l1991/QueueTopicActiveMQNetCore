using System;
using System.Collections.Generic;
using System.Text;

namespace Funciones.DTO
{
    public class DTOProductosOrden
    {
        public string SKU { get; set; }
        public string Cantidad { get; set; }

        public DTOProductosOrden(string sKU, string cantidad)
        {
            SKU = sKU;
            Cantidad = cantidad;
        }
    }
}
