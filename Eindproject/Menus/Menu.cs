using Eindproject.Input;
using Eindproject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Menus
{
    public abstract class Menu : IComponent
    {
        internal SpriteFont font;
        internal string text;
        internal IInputReader inputReader;

        public Menu(SpriteFont font, IInputReader inputReader)
        {
            this.font = font;
            this.inputReader = inputReader;
        }

        protected Menu(SpriteFont font)
        {
            this.font = font;
        }

        public void Update(GameTime gt)
        {
            HandleEnter();
        }

        public void Draw(SpriteBatch sb)
        {
            Vector2 textSize = font.MeasureString(text);

            sb.DrawString(font, text, new Vector2((800 - textSize.X) / 2, 180), Color.LightBlue);
        }

        public virtual bool HandleEnter()
        {
            if (inputReader.ReadInput().Y > 0)
                return true;
            return false;
        }
    }
}