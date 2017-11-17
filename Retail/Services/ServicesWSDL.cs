using Retail.DTO;
using System.Threading.Tasks;
using WSOrden;

namespace Retail.Services
{
    public class ServicesWSDL
    {
        public static void Ordenar(DTOOrdenar peticion)
        {
            WSOrden.orderServiceClient cliente = new WSOrden.orderServiceClient();
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
            Task<ordenarResponse> response = cliente.ordenarAsync(orden);
        }
    }
}
