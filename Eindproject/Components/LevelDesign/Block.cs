using Eindproject.Animations;
using Eindproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Components.LevelDesign
{
    public abstract class Block : IBlock
    {
        private Vector2 position;
        private Texture2D texture;
        private Random rand = new Random();
        internal Rectangle block;
        

        public Block(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, block, Color.White, 0f, new Vector2(0, 0), 3f, SpriteEffects.None, 0f);
        }
    }
}
