using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject.Animations
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
        private double timer;
        private int fps;
        private bool shouldPause;

        public Animation(int fps, bool pauseIfMaxed = false)
        {
            frames = new List<AnimationFrame>();
            this.fps = fps;
            shouldPause = pauseIfMaxed;
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public float Progress
        {
            get
            {
                return (float)counter / ((float)frames.Count - 1);
            }
        }

        public void Update(GameTime gt)
        {
            if (shouldPause && counter == frames.Count - 1)
                return;

            CurrentFrame = frames[counter];

            timer += gt.ElapsedGameTime.TotalSeconds;

            if (timer >= 1d / fps)
            {
                counter++;
                timer = 0;
            }

            if (counter >= frames.Count)
                counter = 0;
        }

        public void Reset()
        {
            CurrentFrame = frames[0];
            counter = 0;
        }
    }
}
