using Eindproject.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Menus
{
    public class VictoryMenu : Menu
    {
        public VictoryMenu(SpriteFont font, IInputReader inputReader) : base(font, inputReader)
        {
            text = "Victory!";
        }

        public override bool HandleEnter()
        {
            if (base.HandleEnter())
            {
                GameMaster.LevelCount++;
                GameMaster.HasWon = false;
            }
            return true;
        }
    }
}
