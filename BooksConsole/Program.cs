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


            // 5. Crear un caso de uso que permita agregar un libro al sistema (interactivo).
            Console.WriteLine("\n--- Agregando un nuevo libro (interactivo) ---");

            Console.WriteLine("Por favor, introduce los datos del Autor:");
            Console.Write("Nombre del Autor: ");
            string autorNombre = Console.ReadLine() ?? string.Empty;
            Console.Write("País de Origen del Autor: ");
            string autorPais = Console.ReadLine() ?? string.Empty;
            Console.Write("Año de Nacimiento del Autor: ");
            int autorAnioNacimiento;
            while (!int.TryParse(Console.ReadLine(), out autorAnioNacimiento))
            {
                Console.Write("Entrada inválida. Por favor, introduce un número para el año de nacimiento: ");
            }

            Autor nuevoAutor = new Autor
            {
                Nombre = autorNombre,
                PaisDeOrigen = autorPais,
                AnioNacimiento = autorAnioNacimiento
            };

            Console.WriteLine("\nPor favor, introduce los datos del Libro:");
            Console.Write("Nombre del Libro: ");
            string libroNombre = Console.ReadLine() ?? string.Empty;
            Console.Write("ISBN del Libro: ");
            string libroISBN = Console.ReadLine() ?? string.Empty;
            Console.Write("Género del Libro: ");
            string libroGenero = Console.ReadLine() ?? string.Empty;
            Console.Write("Año de Publicación del Libro: ");
            int libroAnioPublicacion;
            while (!int.TryParse(Console.ReadLine(), out libroAnioPublicacion))
            {
                Console.Write("Entrada inválida. Por favor, introduce un número para el año de publicación: ");
            }
            Console.Write("Editorial del Libro: ");
            string libroEditorial = Console.ReadLine() ?? string.Empty;

            Libro nuevoLibro = new Libro
            {
                Nombre = libroNombre,
                ISBN = libroISBN,
                Genero = libroGenero,
                AnioPublicacion = libroAnioPublicacion,
                Editorial = libroEditorial,
                Autores = new List<Autor> { nuevoAutor }
            };

            int initialBookCount = libraryService.GetAllBooks().Count;
            libraryService.AddBook(nuevoLibro);
            Console.WriteLine($"  - Libro '{nuevoLibro.Nombre}' agregado interactivamente.");

            int finalBookCount = libraryService.GetAllBooks().Count;
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