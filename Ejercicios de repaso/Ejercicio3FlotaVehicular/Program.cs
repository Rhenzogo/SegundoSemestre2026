using System;
using System.Collections.Generic;

namespace Ejercicio3FlotaVehicular
{
    // Clase base Vehiculo
    public class Vehiculo
    {
        public double LitrosCombustible { get; set; }

        public Vehiculo(double litrosCombustible)
        {
            LitrosCombustible = litrosCombustible;
        }

        // Método virtual: asume un rendimiento base genérico de 10 km por litro
        public virtual double CalcularAutonomiaKm()
        {
            return LitrosCombustible * 10.0;
        }
    }

    // Clase derivada Automovil
    public class Automovil : Vehiculo
    {
        public int NumeroPuertas { get; set; }

        public Automovil(double litrosCombustible, int numeroPuertas) : base(litrosCombustible)
        {
            NumeroPuertas = numeroPuertas;
        }

        // Se sobreescribe (override): un automóvil es más eficiente, asumiendo 15 km por litro
        public override double CalcularAutonomiaKm()
        {
            return LitrosCombustible * 15.0;
        }
    }

    // Clase derivada Camion
    public class Camion : Vehiculo
    {
        public double CapacidadCargaTon { get; set; }

        public Camion(double litrosCombustible, double capacidadCargaTon) : base(litrosCombustible)
        {
            CapacidadCargaTon = capacidadCargaTon;
        }

        // Se sobreescribe (override): el camión consume más, y su rendimiento baja con su carga
        public override double CalcularAutonomiaKm()
        {
            // Asumimos un base de 8 km/l, y restamos 0.5 km/l por cada tonelada de capacidad de carga.
            // (Aseguramos un rendimiento mínimo de 2 km/l por seguridad en el cálculo)
            double rendimiento = 8.0 - (CapacidadCargaTon * 0.5);
            if (rendimiento < 2.0) 
            {
                rendimiento = 2.0; 
            }
            
            return LitrosCombustible * rendimiento;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creación de la flota unificada con distintos tipos de vehículos
            List<Vehiculo> flotaLogistica = new List<Vehiculo>
            {
                new Vehiculo(45.0),                   // Vehículo genérico con 45 litros
                new Automovil(40.0, 4),               // Auto con 40 litros y 4 puertas
                new Camion(120.0, 10.0)               // Camión con 120 litros y 10 toneladas de carga
            };

            Console.WriteLine("--- Cálculo de Autonomía de Flota Vehicular ---");
            Console.WriteLine("Evaluando rendimiento energético...\n");

            // Bucle que invoca la autonomía polimórficamente
            foreach (var vehiculo in flotaLogistica)
            {
                double autonomia = vehiculo.CalcularAutonomiaKm();
                
                Console.WriteLine($"Tipo de Vehículo: {vehiculo.GetType().Name}");
                Console.WriteLine($"Combustible: {vehiculo.LitrosCombustible} Litros");
                
                // Extra: mostramos el detalle específico según el tipo
                if (vehiculo is Automovil auto)
                {
                    Console.WriteLine($"Detalle: {auto.NumeroPuertas} puertas");
                }
                else if (vehiculo is Camion camion)
                {
                    Console.WriteLine($"Detalle: {camion.CapacidadCargaTon} Toneladas de capacidad");
                }

                Console.WriteLine($"Autonomía Restante: {autonomia} km");
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
