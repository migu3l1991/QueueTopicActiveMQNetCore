using Microsoft.AspNetCore.Mvc;
using Gateway.Services;
using Gateway.Model;
using Gateway.Database;
using Gateway.DTO;

namespace ReceptorOrden.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly FacturaRepository _facturaService;
        private readonly EscribirCola _escribirCola;

        public ValuesController(FacturaRepository facturaService, EscribirCola escribirCola)
        {
            _facturaService = facturaService;
            _escribirCola = escribirCola;
        }
        
        [HttpPost]
        public bool Post([FromBody]DTOOrden value)
        {
            if (value != null)
            {
                Factura factura = new Factura(value.Id,value.Nombre,value.Cedula,value.Correo);
                _facturaService.AddFactura(factura);
                if (value.Productos != null)
                {
                    foreach (var producto in value.Productos)
                    {
                        producto.IdFactura = value.Id;
                        producto.Factura = factura;
                        _facturaService.AddProducto(producto);
                    }
                    _escribirCola.EscribirOrden(value);
                }
            }
            return true;
        }
    }
}