namespace CmsServices.Models
{
    public class Factura
    {
        public int id {get; set;}
        public int id_usuario { get; set;}
        public string folio { get; set;}
        public string saldo { get; set;}
        public DateTime fecha_facturacion { get; set;}
        public DateTime fecha_creacion   { get; set;}
    }
}
