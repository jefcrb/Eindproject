using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D9;

namespace Eindproject.Components.LevelDesign
{
    public class BlockGenerator
    {
        private Texture2D texture;
        private List<Block> level;
        private int stageHeight = 246;
        private int stageLength = 200;

        public BlockGenerator(Texture2D texture)
        {
            this.texture = texture;
            GenerateMap();
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Block block in level)
                block.Draw(sb);
        }

        internal void GenerateMap()
        {
            level = new List<Block>();

            for (int i = 0; i < 800; i += 23)
            {
                level.Add(new FloorBlock(texture, new Vector2(i, 458)));
            }

            level.Add(new StageSupportBlock(texture, new Vector2(0, stageHeight)));
            
            for (int i = 23; i < stageLength; i += 23)
            {
                level.Add(new StageBlock(texture, new Vector2(i, stageHeight)));
            }
        }
    }
}
