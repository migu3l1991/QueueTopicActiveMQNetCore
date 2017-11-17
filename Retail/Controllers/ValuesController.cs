using Microsoft.AspNetCore.Mvc;
using Retail.DTO;
using Retail.Services;

namespace Retail.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ServicesWSDL _servicesWSDL;

        public ValuesController(ServicesWSDL servicesWSDL)
        {
            _servicesWSDL = servicesWSDL;
        }

        [HttpPost]
        public async void Post([FromBody]DTOOrdenar value)
        {
            await _servicesWSDL.Ordenar(value);
        }
    }
}