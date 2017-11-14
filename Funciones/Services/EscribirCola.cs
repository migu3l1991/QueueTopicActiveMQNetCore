using Apache.NMS;
using Apache.NMS.Util;
using Funciones.DTO;
using Newtonsoft.Json;
using System;

namespace Funciones.Services
{
    public class EscribirCola
    {
        const string userName = "admin";
        const string password = "admin";
        const string uri = "activemq:tcp://localhost:61616";
        //const string Topic = "topic://Ordenes";
        const string Queue = "queue://TestNet";

        public static IConnection Conexion()
        {
            var connecturi = new Uri(uri);
            var factory = new NMSConnectionFactory(connecturi);
            var connection = factory.CreateConnection(userName, password);
            return connection;
        }

        public static bool Escribir(DTOOrden message)
        {
            var connection = Conexion();
            connection.Start();
            ISession _session = connection.CreateSession();
            IDestination queueDestination = SessionUtil.GetDestination(_session, Queue);
            IMessageProducer _producer = _session.CreateProducer(queueDestination);
            var response = _session.CreateTextMessage();
            string jsonMessage = JsonConvert.SerializeObject(message);
            response.Text = jsonMessage;
            _producer.Send(response);
            return true;
        }
    }
}