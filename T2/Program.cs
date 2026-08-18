using System;

namespace ejercicio8ago
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("         EJERCICIOS DE CLASE - 08/08/2026        ");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            // Ejercicio 1: Producto
            Console.WriteLine("--- Ejercicio 1: Producto ---");
            Producto miProducto = new Producto
            {
                Nombre = "Laptop Dell XPS",
                Precio = 12500.00
            };
            miProducto.MostrarInfo();
            Console.WriteLine();

            // Ejercicio 2: Carro
            Console.WriteLine("--- Ejercicio 2: Carro ---");
            Carro miCarro = new Carro
            {
                Marca = "Toyota Hilux",
                Anio = 2024
            };
            miCarro.Arrancar();
            Console.WriteLine();

            // Ejercicio 3: Estudiante
            Console.WriteLine("--- Ejercicio 3: Estudiante ---");
            Estudiante estudiante1 = new Estudiante
            {
                Nombre = "Rhenzo Gomez",
                Nota = 85.5
            };
            Estudiante estudiante2 = new Estudiante
            {
                Nombre = "Alejandro Caballeros",
                Nota = 55.0
            };

            estudiante1.EstadoAprobacion();
            estudiante2.EstadoAprobacion();
            
            Console.WriteLine();
            Console.WriteLine("==================================================");
        }
    }
}
