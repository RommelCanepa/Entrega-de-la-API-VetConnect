using System;
using System.Collections.Generic;

namespace VetConnectAPI.Models
{
    public class ServicioVeterinario
    {
        public int IDServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        // Relación con HistorialCitas
        public ICollection<HistorialCita> HistorialCitas { get; set; }  // Relación uno a muchos
    }
}
