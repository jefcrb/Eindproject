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
    public class MenuHandler : IComponent
    {
        private Dictionary<string, Menu> menus;
        private Menu menu = null;

        public MenuHandler(Dictionary<string, Menu> menus)
        {
            this.menus = menus;
        }

        public void Update(GameTime gt)
        {
            if (GameMaster.GameOver)
                menu = menus["GameOverMenu"];
            else if (!GameMaster.HasStarted)
                menu = menus["StartMenu"];
            else if (GameMaster.HasWon)
                menu = menus["VictoryMenu"];
            else
                menu = null;

            menu?.Update(gt);
        }

        public void Draw(SpriteBatch sb)
        {
            menu?.Draw(sb);
        }
    }
}
