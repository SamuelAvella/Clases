using System;

namespace JuegoDeVidas
{
    internal class Juego
    {
        public int vidas;

        public Juego(int vidasIniciales)
        {
            vidas = vidasIniciales;
        }

        public void MuestraVidasRestantes()
        {
            Console.WriteLine($"Vidas restantes: {vidas}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando una instancia de Juego con 5 vidas.");
            Juego juego1 = new Juego(5);
            juego1.MuestraVidasRestantes();

            Console.WriteLine("Restando una vida.");
            juego1.vidas--;
            juego1.MuestraVidasRestantes();

            Console.WriteLine("Creando otra instancia de Juego con 5 vidas.");
            Juego juego2 = new Juego(5);
            juego2.MuestraVidasRestantes();

            Console.WriteLine("Mostrando las vidas restantes de la primera instancia:");
            juego1.MuestraVidasRestantes();
        }
    }
}
