using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retail.DTO
{
    public class DTOOrdenar
    {
        public string Organizacion { get; set; }
        public string ShippingId { get; set; }
        public List<DTOProductos> Productos { get; set; }
    }
}
