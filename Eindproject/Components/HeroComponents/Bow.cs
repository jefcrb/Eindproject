using Eindproject.Animations;
using Eindproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Eindproject.Components.HeroComponents
{
    internal class Bow : IComponent
    {
        private Texture2D texture;
        private Vector2 position;
        private float rotation = 0f;
        private List<Arrow> arrows = new List<Arrow>();
        private Texture2D arrowTexture;
        private Animation animation;
        private MouseState state;
        private bool isActive;

        public Bow(Texture2D texture, Vector2 initPos, Texture2D arrowTexture)
        {
            this.texture = texture;
            position = new Vector2(initPos.X + 45, initPos.Y + 35);
            this.arrowTexture = arrowTexture;
            animation = new Animation(15, true);

            for (int i = 0; i <= 90; i += 90)
            {
                for (int j = 0; j <= 350; j += 70)
                    animation.AddFrame(new AnimationFrame(new Rectangle(j, i, 70, 90)));
            }
        }

        public void Update(GameTime gt)
        {
            state = Mouse.GetState();
            TrackMouse(state);


            foreach (Arrow a in arrows)
                a.Update(gt);

            if (state.LeftButton == ButtonState.Pressed)
            {
                animation.Update(gt);

                if (!isActive)
                    InitArrow();

                arrows[arrows.Count - 1].BowData(rotation, animation.Progress, position);
            }
            else
            {
                animation.Reset();

                if (isActive)
                    arrows[arrows.Count - 1].Release();

                isActive = false;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White, rotation, new Vector2(25, 45), 1f, SpriteEffects.None, 0f);

            foreach (Arrow a in arrows)
            {
                a.Draw(sb);
            }
        }

        public void TrackMouse(MouseState state)
        {
            Vector2 mousePos = new Vector2(state.X, state.Y);
            Vector2 center = new Vector2(position.X, position.Y);

            double lengthDiff = mousePos.X - center.X;
            double heightDiff = mousePos.Y - center.Y;
            double hypo = Math.Sqrt(Math.Pow(lengthDiff, 2) + Math.Pow(heightDiff, 2));

            rotation = (float)Math.Sin(heightDiff / hypo);
        }

        public void InitArrow()
        {
            arrows.Add(new Arrow(new Vector2(position.X, position.Y), arrowTexture));
            isActive = true;
        }

        public void ArcherData(Vector2 pos)
        {
            position = new Vector2(pos.X + 45, pos.Y + 35);
        }
    }
}
