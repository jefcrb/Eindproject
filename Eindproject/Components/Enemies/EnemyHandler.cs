using Eindproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;

namespace Eindproject.Components.Enemies
{
    public class EnemyHandler : IComponent
    {
        private Dictionary<int, Enemy> enemies;
        private int timer = 0;

        public EnemyHandler()
        {
            enemies = new Dictionary<int, Enemy>();
        }

        public void Update(GameTime gt)
        {
            timer += (int)gt.ElapsedGameTime.TotalMilliseconds;
            int count = 0;

            foreach (Enemy e in enemies.Values)
            {
                e.Update(gt);
                if (e.IsAlive)
                    count++;
            }

            foreach (int t in enemies.Keys)
            {
                if (t < timer && !enemies[t].Initiated)
                    enemies[t].Initiated = true;
            }

            if (count <= 0)
                GameMaster.HasWon = true;
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Enemy e in enemies.Values)
                e.Draw(sb);
        }

        public void AddEnemies(Dictionary<int, Enemy> enemyList)
        {
            enemies = enemyList;
        }
    }
}
