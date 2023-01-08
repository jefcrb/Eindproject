using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Interfaces
{
    internal interface IComponent
    {
        public void Update(GameTime gt);
        public void Draw(SpriteBatch sb);
    }
}
