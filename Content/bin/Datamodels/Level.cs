using game2.Content;
using game2.Content.Managers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace game2.Content.bin.Datamodels
{
    internal class Level
    {
        private Texture2D MapTexture;

        public Level(Texture2D MapTexture)
        {
            this.MapTexture = MapTexture;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(MapTexture, Vector2.Zero, null, Microsoft.Xna.Framework.Color.White, 0, new Microsoft.Xna.Framework.Vector2(MapTexture.Width / 2, MapTexture.Height / 2), Vector2.One, SpriteEffects.None, 0);
        }
    }
}
