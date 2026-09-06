using System;
using System.Collections.Generic;

namespace Agregacion.Models;

public class Biblioteca
{
    public string Nombre { get; set; }
    private List<Libro> _libros;

    public Biblioteca(string nombre)
    {
        Nombre = nombre;
        _libros = new List<Libro>();
    }

    // Agregación: La biblioteca recibe el objeto Libro (que ya existe),
    // no es responsable de su ciclo de vida.
    public void AgregarLibro(Libro libro)
    {
        _libros.Add(libro);
    }

    public void MostrarLibros()
    {
        Console.WriteLine($"Libros en la biblioteca '{Nombre}':");
        if (_libros.Count == 0)
        {
            Console.WriteLine("No hay libros.");
            return;
        }
        foreach (var libro in _libros)
        {
            Console.WriteLine($"- {libro}");
        }
    }
}
