using System;
using Agregacion.Models;

// Creación de recursos independientes
Libro libro1 = new("123-456-789", " El principito", "Antoine de Saint-Exupéry");
Libro libro2 = new("987-654-321", "El hombre en busca de sentido", "Viktor Frankl");
Libro libro3 = new("456-789-123", "1984", "George Orwell");

Console.WriteLine("--- Libros creados independientemente ---");
Console.WriteLine(libro1);
Console.WriteLine(libro2);
Console.WriteLine(libro3);
Console.WriteLine();

// Creación de la entidad contenedora
Biblioteca? biblioteca = new("Biblioteca Municipal");

// Agregación: Asociamos los libros a la biblioteca
biblioteca.AgregarLibro(libro1);
biblioteca.AgregarLibro(libro2);
biblioteca.AgregarLibro(libro3);

biblioteca.MostrarLibros();
Console.WriteLine();

// Simulamos el cierre/destrucción de la biblioteca
Console.WriteLine("--- Cerrando y destruyendo la biblioteca ---");
biblioteca = null;
Console.WriteLine("La biblioteca ha sido destruida.");
Console.WriteLine();

// Demostración de Agregación: Los libros siguen existiendo
Console.WriteLine("--- Verificando existencia de los libros ---");
Console.WriteLine("Los libros siguen existiendo en el mundo real / base de datos:");
Console.WriteLine(libro1);
Console.WriteLine(libro2);
Console.WriteLine(libro3);
