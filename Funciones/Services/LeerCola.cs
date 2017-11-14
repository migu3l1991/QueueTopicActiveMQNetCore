﻿using Apache.NMS;
using Apache.NMS.Util;
using Funciones.Database;
using Funciones.DTO;
using Funciones.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Funciones.Services
{
    public class LeerCola
    {
        const string userName = "admin";
        const string password = "admin";
        const string uri = "activemq:tcp://localhost:61616";
        const string uriTopic = "activemq:tcp://35.193.201.229:61616";
        //const string Topic = "topic://Ordenes";
        const string Queue = "queue://TestNet";

        private readonly FacturaRepository _facturaService;

        /*private static List<DTOOrden> facturas;
        private static DTOOrden factura = null;*/
        //private static float valorUSD = 0;

        public LeerCola(FacturaRepository facturaService)
        {
            _facturaService = facturaService;
            //facturas = new List<DTOOrden>();
            LeerOrden();
            SuscribirseTopic("Miguel");
        }

        public IConnection Conexion()
        {
            var connecturi = new Uri(uri);
            var factory = new NMSConnectionFactory(connecturi);
            var connection = factory.CreateConnection(userName, password);
            return connection;
        }
        
        public void SuscribirseTopic(string topic)
        {
            var connecturi = new Uri(uriTopic);
            var factory = new NMSConnectionFactory(connecturi);
            var connection = factory.CreateConnection(userName, password);
            connection.Start();
            ISession _session = connection.CreateSession();
            IDestination topicDestination = SessionUtil.GetDestination(_session, "topic://" + topic);
            IMessageConsumer _consumer = _session.CreateConsumer(topicDestination);
            _consumer.Listener += new MessageListener(OnMessageTopic);
        }

        public void LeerOrden()
        {
            var connection = Conexion();
            connection.Start();
            ISession _session = connection.CreateSession();
            IDestination queueDestination = SessionUtil.GetDestination(_session, Queue);
            IMessageConsumer _consumer = _session.CreateConsumer(queueDestination);
            _consumer.Listener += new MessageListener(OnMessage);
        }

        protected static void OnMessage(IMessage receivedMsg)
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
            ConvertirUSD();
            var client = new HttpClient();
            HttpResponseMessage response = client.PostAsync("http://localhost:60548/api/values", new StringContent(JsonConvert.SerializeObject(orden), Encoding.UTF8, "application/json")).Result;
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
            string estado = "Rechazada";
            if (doc.Root.Element("orderReceivedStatus").Value.Equals("true") )
            {
                estado = "Aceptada";
            }
            Task<Factura> factura = _facturaService.FindFacturaAsync(int.Parse(doc.Root.Element("id").Value));
            factura.Result.Estado = estado;
            _facturaService.UpdateFactura(factura.Result);
            ConvertirCOP(doc.Root.Element("shippingOrder").Element("TOTAL").Value);
        }

        public static void ConvertirUSD()
        {
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://free.currencyconverterapi.com/api/v4/convert?q=COP_USD&compact=y").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            JObject json = JObject.Parse(stringData);
            double valorUSD = json.GetValue("COP_USD").First.First.Value<float>();
            /*foreach (var producto in factura.Productos)
            {
                producto.Precio = (valorUSD * float.Parse(producto.Precio)).ToString();
            }
            facturas.Add(factura);*/
        }

        public static void ConvertirCOP(string precio)
        {
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://free.currencyconverterapi.com/api/v4/convert?q=USD_COP&compact=y").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            JObject json = JObject.Parse(stringData);
            double valorCOP = json.GetValue("USD_COP").First.First.Value<float>();
            double precioCOP = double.Parse(precio) * valorCOP;
           /* foreach (var producto in factura.Productos)
            {
                producto.Precio = (valorUSD * float.Parse(producto.Precio)).ToString();
            }
            facturas.Add(factura);*/
        }
    }
}