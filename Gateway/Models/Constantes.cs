namespace Gateway.Models
{
    public class Constantes
    {
        public string UserName { get => "admin"; }
        public string Password { get => "admin"; }
        public string Uri { get => "activemq:tcp://localhost:61616"; }
        public string QueueOrdenes { get => "queue://TestNet"; }
        public string UriTopic { get => "activemq:tcp://35.193.201.229:61616"; }
        public string UriRespuesta { get => "activemq:tcp://35.193.201.229:61616"; }
        public string QueueRespuesta { get => "queue://mailerqueue​ "; }
    }
}