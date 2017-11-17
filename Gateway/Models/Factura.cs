using System.ComponentModel.DataAnnotations.Schema;

namespace Gateway.Model
{
    public class Factura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }

        public Factura() {}

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