using Eindproject.Animations;
using Eindproject.Components.HeroComponents.Physics;
using Eindproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Components.Enemies
{
    public class Enemy : IComponent
    {
        internal Texture2D texture;
        internal Animation animation;
        internal float speed = 1;

        public bool IsAlive { get; set; } = true;
        public bool Initiated { get; set; } = false;
        public Vector2 Position { get; set; }

        public Enemy(Texture2D texture)
        {
            this.texture = texture;
            CollisionDetection.AddEnemy(this);
        }

        public void Update(GameTime gt)
        {
            animation.Update(gt);

            if (IsAlive && Initiated)
                Position = new Vector2(Position.X - speed, Position.Y);

            if (Position.X < 0 && IsAlive)
                ReachEnd();
        }

        public void Draw(SpriteBatch sb)
        {
            if (IsAlive && Initiated)
                sb.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 2f, SpriteEffects.FlipHorizontally, 0f);
        }

        public void IsHit()
        {
            IsAlive = false;

            Scoreboard.Score += 1;
            Console.WriteLine(Scoreboard.Score);
        }

        public void ReachEnd()
        {
            GameMaster.Health -= 1;
            IsAlive = false;

            Console.WriteLine(GameMaster.GameOver);
        }
    }
}
