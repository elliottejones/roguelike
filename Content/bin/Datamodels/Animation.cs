using game2.Content.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace game2.Content.bin.Datamodels
{
    internal class Animation
    {
        private readonly Texture2D Texture;
        private readonly int TextureWidth;
        private readonly int FrameCount;
        private readonly float FrameTime;

        private bool Active = true;

        private float FrameTimeRemaining = 0;
        private int CurrentFrame = 0;

        private readonly List<Rectangle> FrameRectangles = new();

        public Animation(Texture2D Texture, int TextureWidth, int FrameCount, float FrameTime)
        {
            this.TextureWidth = TextureWidth;
            this.FrameCount = FrameCount;
            this.Texture = Texture;
            this.FrameTime = FrameTime;

            for (int i = 0; i < FrameCount; i++)
            {
                FrameRectangles.Add(new Rectangle(new Point(i * TextureWidth, 0), new Point(TextureWidth, Texture.Height)));
            }
        }

        public void Start()
        {
            Active = true;
        }

        public void Stop()
        {
            Active = false;
        }

        public void Reset()
        {
            FrameTimeRemaining = FrameTime;
            CurrentFrame = 0;
        }

        public void Update()
        {
            if (Active)
            {
                FrameTimeRemaining -= Globals.TotalSeconds;

                if (FrameTimeRemaining <= 0)
                {
                    FrameTimeRemaining = FrameTime;
                    CurrentFrame = (CurrentFrame + 1) % FrameCount;
                }
            }
        }

        public void Draw(Vector2 pos, Globals.Orientation Orientation)
        {
            SpriteEffects spriteEffects;
            if (Orientation == Globals.Orientation.left) { spriteEffects = SpriteEffects.FlipHorizontally; } else { spriteEffects = SpriteEffects.None; }
            Globals.SpriteBatch.Draw(Texture, pos, FrameRectangles[CurrentFrame], Microsoft.Xna.Framework.Color.White, 0, new Vector2(TextureWidth / 2, Texture.Height / 2), new Vector2(2, 2), spriteEffects, 1);
        }

    }
}
