using Eindproject.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Components.Enemies
{
    public class EnemyFlying : Enemy
    {
        Random random = new Random();

        public EnemyFlying(Texture2D texture) : base(texture)
        {
            Position = new Vector2(850, random.Next(0, 200));

            animation = new Animation(5);
            for (int i = 1; i <= 1200; i += 150)
                animation.AddFrame(new AnimationFrame(new Rectangle(i + 51, 59, 48, 32)));
        }
    }
}
