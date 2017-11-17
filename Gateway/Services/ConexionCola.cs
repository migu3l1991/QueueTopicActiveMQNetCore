using Apache.NMS;
using System;

namespace Gateway.Services
{
    public class ConexionCola
    {
        public IConnection Conexion(string uri, string userName, string password)
        {
            var connecturi = new Uri(uri);
            var factory = new NMSConnectionFactory(connecturi);
            var connection = factory.CreateConnection(userName, password);
            return connection;
        }
    }
}