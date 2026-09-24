using System;
using System.Collections.Generic;

namespace Ejercicio4Notificaciones
{
    // Clase base Notificacion
    public class Notificacion
    {
        public string Mensaje { get; set; }

        public Notificacion(string mensaje)
        {
            Mensaje = mensaje;
        }

        // Método virtual que puede ser sobrescrito por clases hijas
        public virtual void Enviar()
        {
            Console.WriteLine($"[SISTEMA] Enviando notificación genérica: \"{Mensaje}\"");
        }
    }

    // Clase derivada CorreoElectronico
    public class CorreoElectronico : Notificacion
    {
        public string DireccionCorreo { get; set; }

        public CorreoElectronico(string mensaje, string direccionCorreo) : base(mensaje)
        {
            DireccionCorreo = direccionCorreo;
        }

        // Sobrescritura de método para aplicar protocolo de email
        public override void Enviar()
        {
            Console.WriteLine($"[EMAIL] Destinatario: {DireccionCorreo}");
            Console.WriteLine($"Conectando por SMTP... Enviando cuerpo del mensaje: \"{Mensaje}\"");
        }
    }

    // Clase derivada Sms
    public class Sms : Notificacion
    {
        public string NumeroTelefono { get; set; }

        public Sms(string mensaje, string numeroTelefono) : base(mensaje)
        {
            NumeroTelefono = numeroTelefono;
        }

        // Sobrescritura de método para aplicar protocolo SMS
        public override void Enviar()
        {
            Console.WriteLine($"[SMS] Teléfono destino: {NumeroTelefono}");
            Console.WriteLine($"Conectando con red móvil... Transmitiendo texto: \"{Mensaje}\"");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Motor central de alertas: agrupa distintas notificaciones
            List<Notificacion> centroAlertas = new List<Notificacion>
            {
                new CorreoElectronico("ALERTA CRÍTICA: Base de datos caída.", "admin@empresa.com"),
                new Sms("Servidor web sobrecargado, latencia alta.", "+502 5555-1234"),
                new Notificacion("Respaldo del sistema completado con éxito.")
            };

            Console.WriteLine("--- Centro de Envíos de Alertas Multicanal ---");
            Console.WriteLine("Iniciando despacho...\n");

            // Ejecución polimórfica: el motor despacha sin acoplarse a los detalles internos
            foreach (var notificacion in centroAlertas)
            {
                notificacion.Enviar();
                Console.WriteLine(new string('-', 60));
            }
        }
    }
}
