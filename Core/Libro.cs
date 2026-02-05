using System.Collections.Generic;

namespace Core
{
    public class Libro
    {
        public required string Nombre { get; set; }
        public required string ISBN { get; set; }
        public required string Genero { get; set; }
        public required int AnioPublicacion { get; set; }
        public required string Editorial { get; set; }
        public required List<Autor> Autores { get; set; }
    }
}