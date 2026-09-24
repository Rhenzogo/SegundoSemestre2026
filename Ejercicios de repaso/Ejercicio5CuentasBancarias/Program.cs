using System;
using System.Collections.Generic;

namespace Ejercicio5CuentasBancarias
{
    // Clase base CuentaBancaria
    public class CuentaBancaria
    {
        public decimal Saldo { get; set; }

        public CuentaBancaria(decimal saldo)
        {
            Saldo = saldo;
        }

        // Método virtual: asume un interés base del 1% mensual para cuentas corrientes estándar
        public virtual decimal CalcularInteresMensual()
        {
            return Saldo * 0.01m;
        }
    }

    // Clase derivada CuentaAhorros
    public class CuentaAhorros : CuentaBancaria
    {
        public decimal TasaPromocional { get; set; }

        public CuentaAhorros(decimal saldo, decimal tasaPromocional) : base(saldo)
        {
            TasaPromocional = tasaPromocional;
        }

        // Sobrescritura: La cuenta de ahorros aplica su propia tasa promocional estable
        public override decimal CalcularInteresMensual()
        {
            return Saldo * TasaPromocional;
        }
    }

    // Clase derivada CuentaInversion
    public class CuentaInversion : CuentaBancaria
    {
        public double FactorRiesgo { get; set; }

        public CuentaInversion(decimal saldo, double factorRiesgo) : base(saldo)
        {
            FactorRiesgo = factorRiesgo;
        }

        // Sobrescritura: La cuenta de inversión aplica un factor multiplicador según su riesgo
        public override decimal CalcularInteresMensual()
        {
            // Asumimos que el banco otorga un 2% base a inversiones, y se multiplica por el factor de riesgo
            decimal tasaBaseInversion = 0.02m;
            return Saldo * tasaBaseInversion * (decimal)FactorRiesgo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Colección de cuentas monetarias del cliente (Polimorfismo)
            List<CuentaBancaria> cuentasCliente = new List<CuentaBancaria>
            {
                new CuentaBancaria(5000m),                       // Cuenta estándar
                new CuentaAhorros(12000m, 0.04m),                // Ahorros con tasa del 4%
                new CuentaInversion(25000m, 1.75)                // Inversión con factor de riesgo de 1.75
            };

            Console.WriteLine("--- Liquidación de Intereses Mensuales ---");
            Console.WriteLine("Procesando abonos polimórficos de la cartera...\n");

            foreach (var cuenta in cuentasCliente)
            {
                decimal interesGenerado = cuenta.CalcularInteresMensual();
                
                Console.WriteLine($"Tipo de Cuenta: {cuenta.GetType().Name}");
                Console.WriteLine($"Saldo Original: {cuenta.Saldo:C}");
                Console.WriteLine($"Intereses Generados: {interesGenerado:C}");
                
                // Aplicamos el abono
                cuenta.Saldo += interesGenerado;
                
                Console.WriteLine($"Nuevo Saldo Total: {cuenta.Saldo:C}");
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
