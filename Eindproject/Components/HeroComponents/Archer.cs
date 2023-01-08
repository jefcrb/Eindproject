using Eindproject.Animations;
using Eindproject.Input;
using Eindproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Eindproject.Components.HeroComponents
{
    public class Archer : IComponent
    {
        private IInputReader inputReader;
        private Vector2 speed = new Vector2(2, 2);
        private Texture2D texture;
        private Vector2 position;
        private Bow bow;
        private Animation animation;
        private float jumpHeight = 5f;
        private bool jumping = false;
        private SpriteEffects dir = SpriteEffects.None;


        public Archer(Texture2D texture, Texture2D textureBow, Texture2D textureArrow, IInputReader inputReader)
        {
            this.texture = texture;
            this.inputReader = inputReader;
            position = new Vector2(100, 200);
            animation = new Animation(7);

            for (int i = 1; i <= 92; i += 23)
                animation.AddFrame(new AnimationFrame(new Rectangle(i, 0, 21, 23)));

            bow = new Bow(textureBow, position, textureArrow);
        }

        public void Update(GameTime gt)
        {
            bow.Update(gt);
            bow.ArcherData(position);
            animation.Update(gt);

            var direction = inputReader.ReadInput();
            direction.X *= speed.X;

            if (position.X + direction.X > 0 && position.X + direction.X < 190)
                position.X += direction.X;

            Rotate(direction);

            if (direction.Y < 0)
                jumping = true;

            if (jumping)
                Jump();
        }

        public void Draw(SpriteBatch sb)
        {
            bow.Draw(sb);
            sb.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), 2f, dir, 0f);
        }

        public void Jump()
        {
            position.Y -= jumpHeight;
            jumpHeight -= 0.2f;

            if (position.Y > 200)
            {
                position.Y = 200;
                jumping = false;
                jumpHeight = 5f;
            }
        }

        public void Rotate(Vector2 direction)
        {
            if (direction.X < 0)
                dir = SpriteEffects.FlipHorizontally;
            else
                dir = SpriteEffects.None;
        }
    }
}
