using Gateway.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gateway.Database
{
    public class FacturaRepository
    {
        private readonly FacturaContext _context;

        public FacturaRepository(FacturaContext context)
        {
            _context = context;
        }

        public void AddFactura(Factura facturaToInsert)
        {
            _context.Facturas.Add(facturaToInsert);
            _context.SaveChanges();
        }

        public void DeleteFactura(int facturaId)
        {
            _context.Remove(FindFacturaAsync(facturaId).Result);
            _context.SaveChanges();
        }

        public async Task<Factura> FindFacturaAsync(int facturaId)
        {
            return await _context.Facturas
           .FirstOrDefaultAsync(factura => factura.Id == facturaId);
        }

        public void UpdateFactura(Factura facturaToUpdate)
        {
            _context.Facturas.Update(facturaToUpdate);
            _context.SaveChanges();
        }

        public void AddProducto(Producto productoToInsert)
        {
            _context.Productos.Add(productoToInsert);
            _context.SaveChanges();
        }

        public void DeleteProducto(int productoId)
        {
            _context.Remove(FindProductoAsync(productoId).Result);
            _context.SaveChanges();
        }

        public async Task<Producto> FindProductoAsync(int productoId)
        {
            return await _context.Productos
           .FirstOrDefaultAsync(producto => producto.SKU == productoId);
        }

        public void UpdateProducto(Producto productoToUpdate)
        {
            _context.Productos.Update(productoToUpdate);
            _context.SaveChanges();
        }
    }
}