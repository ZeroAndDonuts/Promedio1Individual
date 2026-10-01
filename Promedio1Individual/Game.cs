using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promedio1Individual
{
    internal class Game
    {
        public string PlayerName;
        public int PlayerHealth;
        public int PlayerDamage;
        public bool GameOver;
        public void execute()
        {
            RunGame();

        }
        private void RunGame()
        {
            Console.WriteLine("Bienvenido");
            Console.Write("Introduce el nombre de tu personaje: ");
            PlayerName = Console.ReadLine();
            PlayerHealth = 100;
            PlayerDamage = 10;
            GameOver = false;
            while (!GameOver)
            {
                Console.WriteLine($"\nSu nombre es: {PlayerName} \nTu vida es: {PlayerHealth} \nTu daño es: {PlayerDamage}");
                Console.WriteLine("Presiona ENTER para continuar");
                Console.ReadLine();
                Console.WriteLine("Elige una acción: ");
                Console.WriteLine("1. Atacar \n2. Curar \n3. Salir");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Ataque();
                        break;
                    case "2":
                        Curar();
                        break;
                    case "3":
                        GameOver = true;
                        Console.WriteLine("Gracias por jugar");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, inténtalo de nuevo.");
                        break;
                }
            }
        }
        public void Ataque()
        {
            Random rand = new Random();
            int damage = rand.Next(5, 16);
            PlayerHealth -= damage;
            Console.WriteLine($"Has atacado y recibido {damage} de daño. Vida restante: {PlayerHealth}");
            if (PlayerHealth <= 0)
            {
                GameOver = true;
                Console.WriteLine("¡Has muerto! Fin del juego.");
            }
        }
        public void Curar()
        {
            Random rand = new Random();
            int heal = rand.Next(10, 21);
            PlayerHealth += heal;
            Console.WriteLine($"Te has curado {heal} puntos de vida. Vida actual: {PlayerHealth}");
        }
        public void Salir()
        {
            GameOver = true;
            Console.WriteLine("Gracias por jugar");
        }
    }
}