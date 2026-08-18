using System;

namespace ejercicio8ago
{
    public class Estudiante
    {
        public string Nombre { get; set; } = string.Empty;
        public double Nota { get; set; }

        public void EstadoAprobacion()
        {
            if (Nota >= 61)
            {
                Console.WriteLine($"Estudiante: {Nombre} - Nota: {Nota} - Estado: APROBADO");
            }
            else
            {
                Console.WriteLine($"Estudiante: {Nombre} - Nota: {Nota} - Estado: REPROBADO");
            }
        }
    }
}
