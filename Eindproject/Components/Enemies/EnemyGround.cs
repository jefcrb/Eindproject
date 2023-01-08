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
    public class EnemyGround : Enemy
    {
        public EnemyGround(Texture2D _texture) : base(_texture)
        {
            Position = new Vector2(850, 395);

            animation = new Animation(5);
            for (int i = 1; i <= 192; i += 32)
                animation.AddFrame(new AnimationFrame(new Rectangle(i, 0, 32, 32)));
        }
    }
}
