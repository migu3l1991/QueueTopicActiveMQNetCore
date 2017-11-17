namespace Gateway.DTO
{
    public class DTOProductosOrden
    {
        public string SKU { get; set; }
        public string Cantidad { get; set; }

        public DTOProductosOrden(string sKU, string cantidad)
        {
            SKU = sKU;
            Cantidad = cantidad;
        }
    }
}