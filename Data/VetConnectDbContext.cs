using VetConnectAPI.Data;
using VetConnectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace VetConnectAPI.Data
{
    public class VetConnectDbContext : DbContext
    {
        public VetConnectDbContext(DbContextOptions<VetConnectDbContext> options) : base(options) { }

        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<ServicioVeterinario> ServiciosVeterinarios { get; set; }
        public DbSet<HistorialCita> HistorialCitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuración de claves primarias
            modelBuilder.Entity<Cita>().HasKey(c => c.IdCita);
            modelBuilder.Entity<Mascota>().HasKey(m => m.IdMascota);
            modelBuilder.Entity<Usuario>().HasKey(u => u.IDUsuario);
            modelBuilder.Entity<Veterinario>().HasKey(v => v.IDVeterinario);
            modelBuilder.Entity<ServicioVeterinario>().HasKey(s => s.IDServicio); // Clave primaria para ServicioVeterinario
            modelBuilder.Entity<HistorialCita>().HasKey(h => h.IDHistorialCitas); // Clave primaria para HistorialCita
            
            // Configuración de relaciones
            modelBuilder.Entity<Mascota>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Mascotas)
                .HasForeignKey(m => m.IDUsuario);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Mascota)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.IDMascota);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Veterinario)
                .WithMany(v => v.Citas)
                .HasForeignKey(c => c.IDVeterinario);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Citas)
                .HasForeignKey(c => c.IDUsuario);

            // Relación entre HistorialCita y ServicioVeterinario
            modelBuilder.Entity<HistorialCita>()
                .HasOne(h => h.ServicioVeterinario)
                .WithMany(s => s.HistorialCitas)  // Asegúrate de que esta propiedad esté en ServicioVeterinario
                .HasForeignKey(h => h.IDServicio)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación entre HistorialCita y Cita
            modelBuilder.Entity<HistorialCita>()
                .HasOne(h => h.Cita)
                .WithMany()
                .HasForeignKey(h => h.IDCita)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación entre HistorialCita y Usuario
            modelBuilder.Entity<HistorialCita>()
                .HasOne(h => h.Usuario)
                .WithMany()
                .HasForeignKey(h => h.IDUsuario)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
