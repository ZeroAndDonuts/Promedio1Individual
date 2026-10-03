using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promedio1Individual
{
    internal class Enemy
    {
        private string EnemyName{ get; set; }
        private int EnemyHealth{ get; set; }
        private int EnemyDamage{ get; set; }
        private bool EnemyAlive;
        public Enemy(string name, int health, int damage)
        {
            EnemyName = name;
            EnemyHealth = health;
            EnemyDamage = damage;
            EnemyAlive = true;
        }
        public void EnemyAttack()
        {
            Console.WriteLine($"{EnemyName} te ataca causando {EnemyDamage} de daño.");
        }
        public void TakeDamage(int damage)
        {
            EnemyHealth -= damage;
            if (EnemyHealth <= 0)
            {
                EnemyHealth = 0;
                EnemyAlive = false;
            }
        }
        public bool EnemyStatus()
        {
            return EnemyAlive;
        }
    }
}