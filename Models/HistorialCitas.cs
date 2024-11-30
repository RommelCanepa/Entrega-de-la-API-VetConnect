using System;

namespace VetConnectAPI.Models
{
    public class HistorialCita
    {
        public int IDHistorialCitas { get; set; }
        public int IDCita { get; set; }
        public int IDServicio { get; set; }
        public int IDUsuario { get; set; }
        public DateTime FechaRealizacion { get; set; }

        public Cita Cita { get; set; }
        public ServicioVeterinario ServicioVeterinario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
