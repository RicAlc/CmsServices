namespace CmsServices.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad {  get; set; }
        public string correo_electronico { get; set; }
        public string tipo_usuario {  get; set; }
    }
}
