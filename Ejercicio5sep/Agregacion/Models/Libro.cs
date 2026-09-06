namespace Agregacion.Models;

public class Libro
{
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }

    public Libro(string isbn, string titulo, string autor)
    {
        ISBN = isbn;
        Titulo = titulo;
        Autor = autor;
    }

    public override string ToString()
    {
        return $"'{Titulo}' por {Autor} (ISBN: {ISBN})";
    }
}
