using System;

namespace VetConnectAPI.Models
{
        public class Cita
    {
        public int IdCita { get; set; } //Clave primaria
        public int IDMascota { get; set; }
        public int IDVeterinario { get; set; }
        public int IDUsuario { get; set; }
        public Mascota Mascota { get; set; }
        public Veterinario Veterinario { get; set; }
        public Usuario Usuario { get; set; }
    }

}