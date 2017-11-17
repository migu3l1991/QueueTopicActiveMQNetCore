using Apache.NMS;
using Apache.NMS.Util;
using Gateway.Database;
using Gateway.DTO;
using Gateway.Model;
using Gateway.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gateway.Services
{
    public class LeerCola
    {
        private readonly FacturaRepository _facturaService;
        private readonly EscribirCola _escribirCola;
        private readonly ConexionCola _conexionCola;
        private readonly Constantes _constantes;
        private readonly ConversorMoneda _conversorMoneda;

        public LeerCola(FacturaRepository facturaService, EscribirCola escribirCola, ConexionCola conexionCola, Constantes constantes, ConversorMoneda conversorMoneda)
        {
            _facturaService = facturaService;
            _escribirCola = escribirCola;
            _conexionCola = conexionCola;
            _constantes = constantes;
            _conversorMoneda = conversorMoneda;
            LeerOrden();
        }
        
        public void SuscribirseTopic(string topic)
        {
            var connection = _conexionCola.Conexion(_constantes.UriTopic, _constantes.UserName, _constantes.Password);
            connection.Start();
            ISession _session = connection.CreateSession();
            IDestination topicDestination = SessionUtil.GetDestination(_session, "topic://" + topic);
            IMessageConsumer _consumer = _session.CreateConsumer(topicDestination);
            _consumer.Listener += new MessageListener(OnMessageTopic);
        }

        public void LeerOrden()
        {
            var connection = _conexionCola.Conexion(_constantes.Uri, _constantes.UserName, _constantes.Password);
            connection.Start();
            ISession _session = connection.CreateSession();
            IDestination queueDestination = SessionUtil.GetDestination(_session, _constantes.QueueOrdenes);
            IMessageConsumer _consumer = _session.CreateConsumer(queueDestination);
            _consumer.Listener += new MessageListener(OnMessageAsync);
        }

        protected async void OnMessageAsync(IMessage receivedMsg)
        {
            var request = receivedMsg as ITextMessage;
            var message = request?.Text;
            DTOOrden factura = JsonConvert.DeserializeObject<DTOOrden>(message);
            List<DTOProductosOrden> items = new List<DTOProductosOrden>();
            foreach(var producto in factura.Productos)
            {
                items.Add(new DTOProductosOrden(producto.SKU.ToString(),producto.Cantidad));
            }
            DTOOrdenar orden = new DTOOrdenar(factura.Organizacion,factura.Id, items);
            _conversorMoneda.ConvertirUSD();
            SuscribirseTopic(factura.Organizacion);
            var client = new HttpClient();
            await client.PostAsync("http://localhost:60548/api/values", new StringContent(JsonConvert.SerializeObject(orden), Encoding.UTF8, "application/json"));
        }

        protected void OnMessageTopic(IMessage receivedMsg)
        {
            var request = receivedMsg as ITextMessage;
            var message = request?.Text;

            XDocument doc;
            using (StringReader s = new StringReader(message))
            {
                doc = XDocument.Load(s);
            }
            string estado = "Aceptada";
            if (doc.Root.Element("orderReceivedStatus").Value.Equals("false") )
            {
                estado = "Rechazada";
            }
            Task<Factura> factura = _facturaService.FindFacturaAsync(int.Parse(doc.Root.Element("id").Value));
            factura.Wait();
            factura.Result.Estado = estado;
            _facturaService.UpdateFactura(factura.Result);
            JObject json = new JObject
            {
                new JProperty("to",factura.Result.Correo),
                new JProperty("subject","Cobro"),
                new JProperty("message","El costo de la factura es de " + _conversorMoneda.ConvertirCOP(doc.Root.Element("shippingOrder").Element("TOTAL").Value).Result.ToString() + " y ha sido " + estado)
            };
            _escribirCola.EscribirRespuesta(json);
        }
    }
}