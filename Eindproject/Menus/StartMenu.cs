using Eindproject.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Menus
{
    public class StartMenu : Menu
    {
        public StartMenu(SpriteFont font, IInputReader inputReader) : base(font, inputReader)
        {
            text = "Press Enter to start";
        }
    }
}
