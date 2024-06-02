using game2.Content.Characters;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2.Content.Managers
{
    internal class EnemyManager
    {
        public static List<Enemy> Enemies = new List<Enemy>();
        public static List<Enemy> DeadEnemies = new List<Enemy>();

        private static Random RandomX = new Random();
        private static Random RandomY = new Random();

        public static void Spawn(Vector2 PlayerPosition)
        {
            Enemies.Add(new Enemy(Globals.Content.Load<Texture2D>("bloon"), 1f, PlayerPosition, 3, 0.3f));
        }

        public static void Update(Player player)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Update(player);
            }
            foreach (Enemy enemy in DeadEnemies)
            {
                Enemies.Remove(enemy);
            }
            DeadEnemies.Clear();
        }

        public static void Draw()
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw();
            }
        }

        public static void RemoveEnemy(Enemy Enemy)
        {
            DeadEnemies.Add(Enemy);
        }

    }
}
