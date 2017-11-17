using Apache.NMS;
using Apache.NMS.Util;
using Gateway.DTO;
using Gateway.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gateway.Services
{
    public class EscribirCola
    {
        private readonly ConexionCola _conexionCola;
        private readonly Constantes _constantes;

        public EscribirCola(ConexionCola conexionCola, Constantes constantes)
        {
            _conexionCola = conexionCola;
            _constantes = constantes;
        }

        public bool EscribirOrden(DTOOrden message)
        {
            var connection = _conexionCola.Conexion(_constantes.Uri, _constantes.UserName, _constantes.Password);
            connection.Start();
            ISession _session = connection.CreateSession();
            IDestination queueDestination = SessionUtil.GetDestination(_session, _constantes.QueueOrdenes);
            IMessageProducer _producer = _session.CreateProducer(queueDestination);
            var response = _session.CreateTextMessage();
            string jsonMessage = JsonConvert.SerializeObject(message);
            response.Text = jsonMessage;
            _producer.Send(response);
            return true;
        }

        public bool EscribirRespuesta(JObject message)
        {
            var connection = _conexionCola.Conexion(_constantes.UriRespuesta, _constantes.UserName, _constantes.Password);
            connection.Start();
            ISession _session = connection.CreateSession();
            IDestination queueDestination = SessionUtil.GetDestination(_session, _constantes.QueueRespuesta);
            IMessageProducer _producer = _session.CreateProducer(queueDestination);
            var response = _session.CreateTextMessage();
            string jsonMessage = JsonConvert.SerializeObject(message);
            response.Text = jsonMessage;
            _producer.Send(response);
            return true;
        }
    }
}