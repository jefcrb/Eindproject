using Eindproject.Components.HeroComponents.Physics;
using Eindproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace Eindproject.Components.HeroComponents
{
    public enum ArrowState
    {
        Initiated,
        Traveling,
        Landed
    }

    public class Arrow : Gravity, IComponent
    {
        private Rectangle arrowRect;
        private Texture2D arrowTexture;
        private float initRotation;
        private float strength;
        private bool isDisappearing = false;
        private bool disappeared = false;
        private Timer timer;

        public ArrowState State { get; set; } = ArrowState.Initiated;
        public Vector2 Position { get; set; }
        public Vector2 ArrowSize { get; set; } = new Vector2(60, 2);
        public float Rotation { get; set; }

        public Arrow(Vector2 pos, Texture2D arrowTexture)
        {
            Position = pos;
            arrowTexture.SetData(new[] { Color.White });
            this.arrowTexture = arrowTexture;
            arrowRect = new Rectangle((int)Position.X, (int)Position.Y, (int)ArrowSize.X, (int)ArrowSize.Y);
            CollisionDetection.AddArrow(this);
        }

        public void BowData(float rot, float str, Vector2 pos)
        {
            initRotation = rot;
            Rotation = rot;
            strength = str;
            Position = pos;
        }

        public void Update(GameTime gt)
        {
            if (State == ArrowState.Traveling)
            {
                Drop(Position, strength, Rotation);
                Rotate();

                if (Position.X >= 780 || Position.Y >= 440)
                    State = ArrowState.Landed;
            }

            if (State == ArrowState.Landed)
            {
                if (!isDisappearing)
                    isDisappearing = true;

                timer = new Timer(Disappear, null, 10000, 0);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (!disappeared)
                sb.Draw(arrowTexture, Position, arrowRect, Color.Black, Rotation, new Vector2(20, 1), 1f, SpriteEffects.None, 0f);
        }

        public void Release()
        {
            State = ArrowState.Traveling;
        }

        public override Vector2 Drop(Vector2 position, float speed, float rotation)
        {
            Position = base.Drop(position, speed, initRotation);
            return Position;
        }

        public override float Rotate()
        {
            Rotation = base.Rotate();
            return Rotation;
        }

        public void Disappear(object state = null)
        {
            State = ArrowState.Landed;
            disappeared = true;
        }
    }
}
