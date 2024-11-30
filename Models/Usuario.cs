using System;
namespace VetConnectAPI.Models
{
    public class Usuario
    {
        public int IDUsuario { get; set; }  // Clave Primaria
        public string Nombre { get; set; }
        public string NombreMascota { get; set; }
        public int Edad { get; set; }
        public string CorreoElectronico { get; set; }

        public ICollection<Mascota> Mascotas { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}
