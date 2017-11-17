using Gateway.Database;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gateway.Services
{
    public class ConversorMoneda
    {
        private readonly FacturaRepository _facturaService;

        public ConversorMoneda(FacturaRepository facturaService)
        {
            _facturaService = facturaService;
        }

        public async void ConvertirUSD()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://free.currencyconverterapi.com/api/v4/convert?q=COP_USD&compact=y");
            JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            double valorUSD = json.GetValue("COP_USD").First.First.Value<float>();
            System.Diagnostics.Debug.WriteLine("-------------------------------------------------- " + valorUSD);
            /*foreach (var producto in factura.Productos)
            {
                producto.Precio = (valorUSD * float.Parse(producto.Precio)).ToString();
            }
            facturas.Add(factura);*/
        }

        public async Task<double> ConvertirCOP(string precio)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://free.currencyconverterapi.com/api/v4/convert?q=USD_COP&compact=y");
            JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            double valorCOP = json.GetValue("USD_COP").First.First.Value<float>();
            return double.Parse(precio) * valorCOP;
            /* foreach (var producto in factura.Productos)
             {
                 producto.Precio = (valorCOP * float.Parse(producto.Precio)).ToString();
             }
             facturas.Add(factura);*/
        }
    }
}