using System.Collections.Generic;
using Core; // To use Libro and Autor classes
using System.Linq; // To use LINQ queries

namespace Application
{
    public class LibraryService
    {
        private List<Libro> _libros;
        private List<Autor> _autores;

        public LibraryService()
        {
            _autores = new List<Autor>
            {
                new Autor { Nombre = "Octavio Paz", PaisDeOrigen = "México", AnioNacimiento = 1914 },
                new Autor { Nombre = "Gabriel García Márquez", PaisDeOrigen = "Colombia", AnioNacimiento = 1927 },
                new Autor { Nombre = "Laura Restrepo", PaisDeOrigen = "Colombia", AnioNacimiento = 1950 },
                new Autor { Nombre = "Isaac Asimov", PaisDeOrigen = "Rusia", AnioNacimiento = 1920 },
                new Autor { Nombre = "Stephen King", PaisDeOrigen = "Estados Unidos", AnioNacimiento = 1947 },
                new Autor { Nombre = "Jane Austen", PaisDeOrigen = "Reino Unido", AnioNacimiento = 1775 }
            };

            _libros = new List<Libro>
            {
                new Libro
                {
                    Nombre = "Cien años de soledad",
                    ISBN = "978-0307455291",
                    Genero = "Realismo mágico",
                    AnioPublicacion = 1967,
                    Editorial = "Editorial Sudamericana",
                    Autores = new List<Autor> { _autores[1] } // Gabriel García Márquez
                },
                new Libro
                {
                    Nombre = "El laberinto de la soledad",
                    ISBN = "978-9681603511",
                    Genero = "Ensayo",
                    AnioPublicacion = 1950,
                    Editorial = "Fondo de Cultura Económica",
                    Autores = new List<Autor> { _autores[0] } // Octavio Paz
                },
                new Libro
                {
                    Nombre = "Crónica de una muerte anunciada",
                    ISBN = "978-0307455482",
                    Genero = "Novela",
                    AnioPublicacion = 1981,
                    Editorial = "La Oveja Negra",
                    Autores = new List<Autor> { _autores[1] } // Gabriel García Márquez
                },
                new Libro
                {
                    Nombre = "Fundación",
                    ISBN = "978-0553803717",
                    Genero = "Ciencia ficción",
                    AnioPublicacion = 1951,
                    Editorial = "Doubleday",
                    Autores = new List<Autor> { _autores[3] } // Isaac Asimov
                },
                 new Libro
                {
                    Nombre = "Dune",
                    ISBN = "978-0441172719",
                    Genero = "Ciencia ficción",
                    AnioPublicacion = 1965,
                    Editorial = "Chilton Books",
                    Autores = new List<Autor> { new Autor { Nombre = "Frank Herbert", PaisDeOrigen = "Estados Unidos", AnioNacimiento = 1920 } }
                },
                new Libro
                {
                    Nombre = "It",
                    ISBN = "978-0451457224",
                    Genero = "Terror",
                    AnioPublicacion = 1986,
                    Editorial = "Viking Press",
                    Autores = new List<Autor> { _autores[4] } // Stephen King
                },
                new Libro
                {
                    Nombre = "Orgullo y prejuicio",
                    ISBN = "978-0141439518",
                    Genero = "Romance",
                    AnioPublicacion = 1813,
                    Editorial = "T. Egerton, Whitehall",
                    Autores = new List<Autor> { _autores[5] } // Jane Austen
                },
                new Libro
                {
                    Nombre = "Delirio",
                    ISBN = "978-9588639019",
                    Genero = "Novela",
                    AnioPublicacion = 2004,
                    Editorial = "Alfaguara",
                    Autores = new List<Autor> { _autores[2] } // Laura Restrepo
                },
                new Libro
                {
                    Nombre = "The Martian",
                    ISBN = "978-0804139021",
                    Genero = "Ciencia ficción",
                    AnioPublicacion = 2011,
                    Editorial = "Crown Publishing Group",
                    Autores = new List<Autor> { new Autor { Nombre = "Andy Weir", PaisDeOrigen = "Estados Unidos", AnioNacimiento = 1972 } }
                }
            };
        }

        public void AddBook(Libro newBook)
        {
            _libros.Add(newBook);
        }

        public List<Libro> GetAllBooks()
        {
            return _libros;
        }

        public List<Autor> GetAuthorsOfRomanticNovels()
        {
            return _autores.Where(a => _libros.Any(l => l.Autores.Contains(a) && l.Genero == "Romance")).ToList();
        }

        public List<Autor> GetColombianWriters()
        {
            return _autores.Where(a => a.PaisDeOrigen == "Colombia").ToList();
        }

        public List<Libro> GetBooksByOctavioPaz()
        {
            return _libros.Where(l => l.Autores.Any(a => a.Nombre == "Octavio Paz")).ToList();
        }

        public List<Libro> GetSciFiBooks()
        {
            return _libros.Where(l => l.Genero == "Ciencia ficción").ToList();
        }
    }
}
