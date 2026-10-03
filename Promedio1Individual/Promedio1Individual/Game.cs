using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Promedio1Individual
{
    internal class Game
    {
        private string PlayerName;
        private int PlayerHealth = 100;
        private int PlayerDamage = 20;
        private bool GameOver;
        private string EnemyName;
        private int EnemyHealth;
        private int EnemyDamage;
        public void execute()
        {
            RunGame();
        }
        private void RunGame()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido");
            Console.Write("Introduce el nombre de tu personaje: ");
            PlayerName = Console.ReadLine();
            Console.Clear();
            if (PlayerName == "")
            {
                Console.WriteLine("No has introducido un nombre...");
            }
            else
            {
                Console.WriteLine($"\nSu nombre es: {PlayerName} \nTu vida es: {PlayerHealth} \nTu daño es: {PlayerDamage}");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine($"¡Un {EnemyName} ha aparecido!");
            Goblin Goblin = new Goblin();
            Fight(Goblin);
            if (PlayerHealth <= 0 && !Goblin.EnemyStatus())
            {
                Defeat();
                return;
            }
            else
            {
                Victory();
                return;

            }
            Console.WriteLine($"Has derrotado al {EnemyName}.");
            Console.WriteLine("Continúas tu camino.");
            Console.Clear();
            Console.WriteLine($"¡Un {EnemyName} ha aparecido!");
            Orc Orc = new Orc();
            Fight(Orc);
            if (PlayerHealth <= 0 && !Orc.EnemyStatus())
            {
                Defeat();
                return;
            }
            else
            {
                Victory();
                return;
            }
            Console.WriteLine($"Has derrotado al {EnemyName}.");
        }
        private void Fight(Enemy enemy)
        {
            while (PlayerHealth > 0 && enemy.EnemyStatus())
            {
                Console.WriteLine($"\nTu vida: {PlayerHealth} | Vida del enemigo: {EnemyHealth}");
                Console.WriteLine("Elige una acción: ");
                Console.WriteLine("1. Atacar \n2. Salir");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        Ataque(enemy);
                        break;
                    case "2":
                        GameOver = true;
                        Console.WriteLine("Gracias por jugar");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, inténtalo de nuevo.");
                        break;
                }
            }
        }
        private void Ataque(Enemy enemy)
        {
            enemy.TakeDamage(PlayerDamage);
            Console.WriteLine($"Has atacado y recibido {PlayerDamage} de daño. Vida restante: {PlayerHealth}");
            if (enemy.EnemyStatus())
            {
                enemy.EnemyAttack();
                PlayerHealth -= EnemyDamage;
                return;
            }
            if (PlayerHealth <= 0)
            {
                GameOver = true;
                Console.WriteLine("¡Has muerto! Fin del juego.");
            }
        }
        private void Victory()
        {
            Console.Clear();
            Console.WriteLine("VICTORIA! :)");
            Console.WriteLine($"¡Felicidades {PlayerName}! Has completado la aventura.");
        }
        private void Defeat()
        {
            Console.Clear();
            Console.WriteLine("DERROTA :c");
            Console.WriteLine($"¡Has muerto! Fin del juego.");
        }
    }
}