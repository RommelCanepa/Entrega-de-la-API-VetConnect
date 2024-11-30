using System;

namespace VetConnectAPI.Models
{

    public class Veterinario
    {
        public int IDVeterinario { get; set; }  // Clave primaria
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}