using System;

namespace ejercicio8ago
{
    public class Producto
    {
        public string Nombre { get; set; } = string.Empty;
        public double Precio { get; set; }

        public void MostrarInfo()
        {
            Console.WriteLine($"Producto: {Nombre} - Precio: Q{Precio:F2}");
        }
    }
}
