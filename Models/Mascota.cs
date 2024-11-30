using System;
namespace VetConnectAPI.Models
{
    public class Mascota
    {
        public int IdMascota { get; set; } //clave Primaria
        public string Propietario { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Especie { get; set; }

        public int IDUsuario { get; set; } // Relación con Usuario
        public Usuario Usuario { get; set; }

        public ICollection<Cita> Citas { get; set; } // Relación con Cita
    }
}
