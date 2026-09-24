using System;
using System.Collections.Generic;

namespace Ejercicio2Multimedia
{
    // Clase base Dispositivo
    public class Dispositivo
    {
        public string Marca { get; set; }

        public Dispositivo(string marca)
        {
            Marca = marca;
        }

        // Método virtual para permitir el polimorfismo
        // Nota: Se ajustó el nombre de "ReproducerMedia" a "ReproducirMedia" (español correcto)
        public virtual void ReproducirMedia()
        {
            Console.WriteLine($"El dispositivo de marca {Marca} está reproduciendo contenido multimedia genérico.");
        }
    }

    // Clase derivada SmartTv
    public class SmartTv : Dispositivo
    {
        public string Resolucion { get; set; }

        public SmartTv(string marca, string resolucion) : base(marca)
        {
            Resolucion = resolucion;
        }

        public override void ReproducirMedia()
        {
            Console.WriteLine($"La Smart TV {Marca} está reproduciendo video en resolución avanzada {Resolucion}.");
        }
    }

    // Clase derivada ParlanteInteligente
    public class ParlanteInteligente : Dispositivo
    {
        public int PotenciaWatts { get; set; }

        public ParlanteInteligente(string marca, int potenciaWatts) : base(marca)
        {
            PotenciaWatts = potenciaWatts;
        }

        public override void ReproducirMedia()
        {
            Console.WriteLine($"El parlante inteligente {Marca} está emitiendo sonido con un perfil acústico a {PotenciaWatts}W de potencia.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creación del ecosistema de domótica con varios dispositivos
            List<Dispositivo> dispositivosHogar = new List<Dispositivo>
            {
                new Dispositivo("MarcaGenérica"),
                new SmartTv("LG", "4K OLED"),
                new ParlanteInteligente("Amazon Echo", 15)
            };

            Console.WriteLine("--- Ecosistema de Dispositivos Multimedia en el Hogar ---");
            Console.WriteLine("Activando comando de reproducción...\n");

            // Ejecución polimórfica: cada dispositivo responde según su propia implementación
            foreach (var dispositivo in dispositivosHogar)
            {
                dispositivo.ReproducirMedia();
                Console.WriteLine(new string('-', 60));
            }
        }
    }
}
