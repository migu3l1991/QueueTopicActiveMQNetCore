using Funciones.Model;
using System.Collections.Generic;

namespace Funciones.DTO
{
    public class DTOOrden
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Organizacion { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
