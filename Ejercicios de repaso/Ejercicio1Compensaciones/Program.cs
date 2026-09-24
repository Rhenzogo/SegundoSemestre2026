using System;
using System.Collections.Generic;

namespace Ejercicio1Compensaciones
{
    // Clase base Empleado
    public class Empleado
    {
        public string Nombre { get; set; }
        public decimal SalarioBase { get; set; }

        public Empleado(string nombre, decimal salarioBase)
        {
            Nombre = nombre;
            SalarioBase = salarioBase;
        }

        public virtual decimal CalcularSalarioTotal()
        {
            return SalarioBase;
        }
    }

    // Clase derivada Desarrollador
    public class Desarrollador : Empleado
    {
        public int LineasCodigoPorDia { get; set; }

        public Desarrollador(string nombre, decimal salarioBase, int lineasCodigoPorDia) 
            : base(nombre, salarioBase)
        {
            LineasCodigoPorDia = lineasCodigoPorDia;
        }

        public override decimal CalcularSalarioTotal()
        {
            // Asumimos un bono de 0.5 por línea de código al día, calculado para 30 días
            decimal bonoProductividad = LineasCodigoPorDia * 0.5m * 30m;
            return SalarioBase + bonoProductividad;
        }
    }

    // Clase derivada Gerente
    public class Gerente : Empleado
    {
        public decimal BonoAnualFijo { get; set; }

        public Gerente(string nombre, decimal salarioBase, decimal bonoAnualFijo) 
            : base(nombre, salarioBase)
        {
            BonoAnualFijo = bonoAnualFijo;
        }

        public override decimal CalcularSalarioTotal()
        {
            // El bono anual se divide entre 12 para obtener el valor mensual
            decimal bonoMensual = BonoAnualFijo / 12m;
            return SalarioBase + bonoMensual;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear lista unificada de colaboradores
            List<Empleado> empleados = new List<Empleado>
            {
                new Empleado("Ana Empleada Base", 1000m),
                new Desarrollador("Carlos Desarrollador", 1200m, 100),
                new Gerente("Laura Gerente", 2000m, 6000m)
            };

            Console.WriteLine("--- Desglose de Retribución Económica Mensual ---");
            
            // Procesar lista polimórficamente
            foreach (var empleado in empleados)
            {
                decimal salarioTotal = empleado.CalcularSalarioTotal();
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Rol: {empleado.GetType().Name}");
                Console.WriteLine($"Salario Base: {empleado.SalarioBase:C}");
                Console.WriteLine($"Salario Total Mensual: {salarioTotal:C}");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
