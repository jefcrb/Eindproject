using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Eindproject.Components.LevelDesign
{
    public class FloorBlock : Block
    {
        private Random rand = new Random();
        private Rectangle block1;
        private Rectangle block2;
        private Rectangle block3;
        private Rectangle block4;
        public FloorBlock(Texture2D texture, Vector2 position) : base(texture, position)
        {
            block = RandomBlock();
        }

        internal virtual Rectangle RandomBlock()
        {
            block1 = new Rectangle(8, 0, 8, 8);
            block2 = new Rectangle(16, 0, 8, 8);
            block3 = new Rectangle(24, 0, 8, 8);
            block4 = new Rectangle(32, 0, 8, 8);

            switch (rand.Next(0, 4))
            {
                case 0:
                    return block1;
                case 1:
                    return block2;
                case 2:
                    return block3;
                case 3:
                    return block4;
                default:
                    return block1;
            }
        }
    }
}
