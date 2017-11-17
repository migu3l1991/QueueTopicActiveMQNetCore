using Retail.DTO;
using System.Threading.Tasks;
using WSOrden;

namespace Retail.Services
{
    public class ServicesWSDL
    {
        public async Task Ordenar(DTOOrdenar peticion)
        {
            orderServiceClient cliente = new orderServiceClient();
            orderItem[] productos = new orderItem[peticion.Productos.Count];
            int contador = 0;
            foreach(var producto in peticion.Productos)
            {
                orderItem item = new orderItem();
                item.merchantSKU = producto.SKU;
                item.quantity = int.Parse(producto.Cantidad);
                productos[contador] = item;
            }
            shippingOrder orden = new shippingOrder
            {
                organization = peticion.Organizacion,
                idOrder = peticion.ShippingId,
                order = productos
            };
            await cliente.ordenarAsync(orden);
        }
    }
}