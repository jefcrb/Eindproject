using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Components.HeroComponents.Physics
{
    public class Gravity
    {
        private float dt = 0.00f;
        private float stepX = 0.00f;
        private float stepY = 0.00f;

        public virtual Vector2 Drop(Vector2 position, float speed, float rotation)
        {
            speed *= 24;


            stepX = Math.Max(speed - dt, 0);
            stepY = speed * rotation + dt * dt;
            position.X += stepX;
            position.Y += stepY;

            dt += 0.01f;

            return position;
        }

        public virtual float Rotate()
        {
            float angle = stepY / stepX;
            angle = (float)Math.Min(angle, Math.PI / 2);

            return angle;
        }
    }
}