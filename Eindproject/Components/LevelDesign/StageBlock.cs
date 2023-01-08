using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Components.LevelDesign
{
    public class StageBlock : Block
    {
        public StageBlock(Texture2D texture, Vector2 position) : base(texture, position)
        {
            block = new Rectangle(8, 8, 8, 4);
        }
    }
}
