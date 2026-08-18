using System;

namespace ejercicio8ago
{
    public class Carro
    {
        public string Marca { get; set; } = string.Empty;
        public int Anio { get; set; }

        public void Arrancar()
        {
            Console.WriteLine($"El carro marca {Marca} del año {Anio} ha arrancado.");
        }
    }
}
