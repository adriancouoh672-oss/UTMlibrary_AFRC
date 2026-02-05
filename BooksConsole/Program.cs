using System;
using Application;
using Core; // To use Libro and Autor classes
using System.Collections.Generic; // For List
using System.Linq; // For Count()

namespace BooksConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando UTMLibrary Console Application...");

            LibraryService libraryService = new LibraryService();

            // 1. Obtener todos los libros de sci-fi.
            Console.WriteLine("\n--- Libros de Ciencia Ficción ---");
            List<Libro> sciFiBooks = libraryService.GetSciFiBooks();
            if (sciFiBooks.Any())
            {
                foreach (var libro in sciFiBooks)
                {
                    Console.WriteLine($"  - {libro.Nombre} ({libro.AnioPublicacion})");
                }
            }
            else
            {
                Console.WriteLine("  No se encontraron libros de ciencia ficción.");
            }


            // 2. Obtener todos los libros que hayan sido escritos por Octavio Paz.
            Console.WriteLine("\n--- Libros de Octavio Paz ---");
            List<Libro> octavioPazBooks = libraryService.GetBooksByOctavioPaz();
            if (octavioPazBooks.Any())
            {
                foreach (var libro in octavioPazBooks)
                {
                    Console.WriteLine($"  - {libro.Nombre} ({libro.AnioPublicacion})");
                }
            }
            else
            {
                Console.WriteLine("  No se encontraron libros de Octavio Paz.");
            }


            // 3. Obtener todos los escritores colombianos.
            Console.WriteLine("\n--- Escritores Colombianos ---");
            List<Autor> colombianWriters = libraryService.GetColombianWriters();
            if (colombianWriters.Any())
            {
                foreach (var autor in colombianWriters)
                {
                    Console.WriteLine($"  - {autor.Nombre} (Año nacimiento: {autor.AnioNacimiento})");
                }
            }
            else
            {
                Console.WriteLine("  No se encontraron escritores colombianos.");
            }


            // 4. Obtener a todos los autores que escriban novelas románticas.
            Console.WriteLine("\n--- Autores de Novelas Románticas ---");
            List<Autor> romanticAuthors = libraryService.GetAuthorsOfRomanticNovels();
            if (romanticAuthors.Any())
            {
                foreach (var autor in romanticAuthors)
                {
                    Console.WriteLine($"  - {autor.Nombre}");
                }
            }
            else
            {
                Console.WriteLine("  No se encontraron autores de novelas románticas.");
            }


            // 5. Crear un caso de uso que permita agregar un libro al sistema.
            Console.WriteLine("\n--- Agregando un nuevo libro ---");
            int initialBookCount = libraryService.GetAllBooks().Count;
            Console.WriteLine($"  Número inicial de libros: {initialBookCount}");

            Autor newAuthor = new Autor { Nombre = "Douglas Adams", PaisDeOrigen = "Reino Unido", AnioNacimiento = 1952 };
            Libro newBook = new Libro
            {
                Nombre = "The Hitchhiker's Guide to the Galaxy",
                ISBN = "978-0345391803",
                Genero = "Ciencia ficción",
                AnioPublicacion = 1979,
                Editorial = "Pan Books",
                Autores = new List<Autor> { newAuthor }
            };
            libraryService.AddBook(newBook);
            Console.WriteLine($"  - Libro '{newBook.Nombre}' agregado.");

            int finalBookCount = libraryService.GetAllBooks().Count;
            Console.WriteLine($"  Número final de libros: {finalBookCount}");
            if (finalBookCount > initialBookCount)
            {
                Console.WriteLine("  Verificación: El libro fue agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("  Verificación: El libro NO fue agregado correctamente.");
            }

            Console.WriteLine("\nFin de la aplicación.");
        }
    }
}