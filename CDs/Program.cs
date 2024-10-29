using System;

namespace CDs
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

    internal class CD
    {
        private Cancion[] canciones;
        private int contador;

        public CD()
        {
            canciones = new Cancion[10];
            contador = 0;
        }

        public int NumeroCanciones()
        {
            return contador;
        }

        public Cancion DameCancion(int indice)
        {
            if (indice >= 0 && indice < contador)
            {
                return canciones[indice];
            }
            return null;
        }

        public void GrabaCancion(int indice, Cancion nuevaCancion)
        {
            if (indice >= 0 && indice < contador)
            {
                canciones[indice] = nuevaCancion;
            }
        }

        public void Agrega(Cancion nuevaCancion)
        {
            if (contador < canciones.Length)
            {
                canciones[contador] = nuevaCancion;
                contador++;
            }
        }

        public void Elimina(int indice)
        {
            if (indice >= 0 && indice < contador)
            {
                for (int i = indice; i < contador - 1; i++)
                {
                    canciones[i] = canciones[i + 1];
                }
                canciones[contador - 1] = null;
                contador--;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando un CD para almacenar canciones.");
            CD miCD = new CD();

            Console.WriteLine("Agregando canciones al CD.");
            Cancion cancion1 = new Cancion("Despacito", "Luis Fonsi");
            miCD.Agrega(cancion1);
            Console.WriteLine($"Canción agregada: {cancion1.DameTitulo()} por {cancion1.DameAutor()}");

            Cancion cancion2 = new Cancion("Shape of You", "Ed Sheeran");
            miCD.Agrega(cancion2);
            Console.WriteLine($"Canción agregada: {cancion2.DameTitulo()} por {cancion2.DameAutor()}");

            Console.WriteLine($"Número total de canciones en el CD: {miCD.NumeroCanciones()}");

            Console.WriteLine("Recuperando las canciones del CD.");
            for (int i = 0; i < miCD.NumeroCanciones(); i++)
            {
                Cancion cancionRecuperada = miCD.DameCancion(i);
                Console.WriteLine($"Canción {i + 1}: {cancionRecuperada.DameTitulo()} por {cancionRecuperada.DameAutor()}");
            }

            Console.WriteLine("Reemplazando la primera canción del CD.");
            Cancion nuevaCancion = new Cancion("Blinding Lights", "The Weeknd");
            miCD.GrabaCancion(0, nuevaCancion);
            Console.WriteLine($"Canción en la posición 1 después de reemplazar: {miCD.DameCancion(0).DameTitulo()} por {miCD.DameCancion(0).DameAutor()}");

            Console.WriteLine("Eliminando la segunda canción del CD.");
            miCD.Elimina(1);
            Console.WriteLine($"Número total de canciones en el CD después de eliminar: {miCD.NumeroCanciones()}");

            Console.WriteLine("Listando canciones restantes en el CD:");
            for (int i = 0; i < miCD.NumeroCanciones(); i++)
            {
                Cancion cancionRecuperada = miCD.DameCancion(i);
                Console.WriteLine($"Canción {i + 1}: {cancionRecuperada.DameTitulo()} por {cancionRecuperada.DameAutor()}");
            }
        }
    }
}
