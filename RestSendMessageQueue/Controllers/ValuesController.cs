using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Funciones.Services;
using Funciones.Model;
using Funciones.Database;
using Funciones.DTO;

namespace RestSendMessageQueue.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly FacturaRepository _facturaService;

        public ValuesController(FacturaRepository facturaService)
        {
            _facturaService = facturaService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
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
                    EscribirCola.Escribir(value);
                }
            }
            return true;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
