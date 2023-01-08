using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Components.Enemies
{
    public class EnemyGenerator
    {
        private List<Texture2D> textures;
        private Dictionary<int, Enemy> enemies = new Dictionary<int, Enemy>();
        private Random random = new Random();
        private int difficulty;

        public EnemyGenerator(List<Texture2D> enemyTextures, int difficulty)
        {
            textures = enemyTextures;
            this.difficulty = difficulty;
        }

        public Dictionary<int, Enemy> Generate()
        {
            for (int i = 0; i < 10 + 10 * difficulty; i++)
            {
                switch (random.Next(0, 3))
                {
                    case 0:
                        AddGroundEnemy(i * 1000 - difficulty * 100);
                        break;
                    case 1:
                        AddFastGroundEnemy(i * 1000 - difficulty * 100);
                        break;
                    case 2:
                        AddFlyingEnemy(i * 1000 - difficulty * 100);
                        break;
                }
            }
            return enemies;
        }

        internal void AddGroundEnemy(int t)
        {
            enemies.Add(t, new EnemyGround(textures[0]));
        }

        internal void AddFastGroundEnemy(int t)
        {
            enemies.Add(t, new EnemyGroundFast(textures[1]));
        }

        internal void AddFlyingEnemy(int t)
        {
            enemies.Add(t, new EnemyFlying(textures[2]));
        }
    }
}
