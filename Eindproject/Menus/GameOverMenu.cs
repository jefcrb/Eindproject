using Eindproject.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Menus
{
    public class GameOverMenu : Menu
    {
        public GameOverMenu(SpriteFont font, IInputReader inputReader) : base(font, inputReader)
        {
            text = "Game Over!";
        }

        public override bool HandleEnter()
        {
            if (base.HandleEnter())
                GameMaster.HasStarted = true;

            return true;
        }
    }
}
