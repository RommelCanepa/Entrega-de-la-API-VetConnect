using Microsoft.EntityFrameworkCore;
using VetConnectAPI.Data; // Este es el espacio de nombres correcto para tu DbContext 
using VetConnectAPI.Models; // Este es el espacio de nombres para tus modelos
using VetConnectAPI.Services;

namespace VetConnectAPI // Asegúrate de que este es el correcto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura el DbContext con la cadena de conexión a SQL Server
            builder.Services.AddDbContext<VetConnectDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registra los servicios necesarios para los controladores
           builder.Services.AddScoped<IUsuarioService, UsuarioService>();  // Aquí debe estar el registro correcto
            builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();
            builder.Services.AddScoped<IMascotaService, MascotaService>();
            builder.Services.AddScoped<ICitaService, CitaService>();

            // Configuración de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // Agregar los controladores
            builder.Services.AddControllers();

            // Agregar Swagger para la documentación de la API
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configuración para el entorno de desarrollo
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configuración del pipeline de HTTP
            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Habilitar el uso de CORS en la aplicación
            app.UseCors("AllowAllOrigins");

            app.MapControllers(); // Mapea los controladores

            app.Run(); // Inicia la aplicación
        }
    }
}
