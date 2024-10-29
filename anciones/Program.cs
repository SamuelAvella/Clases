using System;

namespace Canciones
{
    internal class Cancion
    {
        private string titulo;
        private string autor;

        public Cancion(string titulo, string autor)
        {
            this.titulo = titulo;
            this.autor = autor;
        }

        public Cancion()
        {
            this.titulo = string.Empty;
            this.autor = string.Empty;
        }

        public string DameTitulo()
        {
            return titulo;
        }

        public string DameAutor()
        {
            return autor;
        }

        public void PonTitulo(string nuevoTitulo)
        {
            titulo = nuevoTitulo;
        }

        public void PonAutor(string nuevoAutor)
        {
            autor = nuevoAutor;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la primera canción con título 'Despacito' y autor 'Luis Fonsi'.");
            Cancion cancion1 = new Cancion("Despacito", "Luis Fonsi");
            Console.WriteLine($"Título de la canción 1: {cancion1.DameTitulo()}");
            Console.WriteLine($"Autor de la canción 1: {cancion1.DameAutor()}");

            Console.WriteLine("Creando una segunda canción utilizando el constructor predeterminado.");
            Cancion cancion2 = new Cancion();
            Console.WriteLine($"Título de la canción 2 (inicialmente vacío): {cancion2.DameTitulo()}");
            Console.WriteLine($"Autor de la canción 2 (inicialmente vacío): {cancion2.DameAutor()}");

            Console.WriteLine("Estableciendo el título de la canción 2 a 'Shape of You'.");
            cancion2.PonTitulo("Shape of You");
            Console.WriteLine("Estableciendo el autor de la canción 2 a 'Ed Sheeran'.");
            cancion2.PonAutor("Ed Sheeran");
            Console.WriteLine($"Título de la canción 2 después de establecer: {cancion2.DameTitulo()}");
            Console.WriteLine($"Autor de la canción 2 después de establecer: {cancion2.DameAutor()}");
        }
    }
}
