using System.Collections.Generic;

namespace Funciones.Model
{
    public class Factura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }

        public Factura(int id, string nombre, string cedula, string correo)
        {
            Id = id;
            Nombre = nombre;
            Cedula = cedula;
            Correo = correo;
            Estado = null;
        }
    }
}
