using Eindproject.Components.Enemies;
using Eindproject.Components.HeroComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Eindproject.Components.HeroComponents.Physics
{
    static class CollisionDetection
    {
        static List<Arrow> arrows = new List<Arrow>();
        static List<Enemy> enemies = new List<Enemy>();
        static internal bool cont = false;

        public static void AddArrow(Arrow a)
        {
            arrows.Add(a);
        }

        public static void AddEnemy(Enemy e)
        {
            enemies.Add(e);
        }

        public static void Detect()
        {
            foreach (Enemy e in enemies)
            {
                if (!e.Initiated)
                    return;

                Rectangle enRect = EnemyToRect(e);
                foreach (Arrow a in arrows)
                {
                    Rectangle arrRect = ArrowToRect(a);
                    if (enRect.Intersects(arrRect))
                    {
                        if (e.IsAlive && a.State == ArrowState.Traveling)
                        {
                            a.Disappear();
                            e.IsHit();
                        }
                    }
                }
            }
        }

        internal static Rectangle ArrowToRect(Arrow a)
        {
            float degrees = a.Rotation * 180 / (float)Math.PI;
            float arrowHeight = (float)Math.Cos(degrees);
            float arrowWidth = (float)Math.Sin(degrees);
            Rectangle arrow = new Rectangle((int)a.Position.X, (int)a.Position.Y, (int)arrowWidth, (int)arrowHeight);

            return arrow;
        }

        internal static Rectangle EnemyToRect(Enemy e)
        {
            return new Rectangle((int)e.Position.X, (int)e.Position.Y, 64, 64);
        }
    }
}
