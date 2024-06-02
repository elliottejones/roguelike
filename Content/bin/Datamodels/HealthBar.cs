using game2.Content.Characters;
using game2.Content.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2.Content.bin.Datamodels
{
    internal class HealthBar
    {
        private Texture2D BarTexture;
        private Texture2D BitTexture;

        public HealthBar(Texture2D BarTexture, Texture2D BitTexture) 
        {
            this.BarTexture = BarTexture;
            this.BitTexture = BitTexture;
        }

        public void Draw(Vector2 PlayerPosition, float Health, float MaxHealth)
        {
            Globals.SpriteBatch.Draw(BarTexture, new Vector2(PlayerPosition.X, PlayerPosition.Y + 36), null, Microsoft.Xna.Framework.Color.White, 0, new Vector2(BarTexture.Width/2,0), Vector2.One, SpriteEffects.None, 1);
            Globals.SpriteBatch.Draw(BitTexture, new Vector2(PlayerPosition.X - 15, PlayerPosition.Y + 37), null, Microsoft.Xna.Framework.Color.White, 0, Vector2.Zero, new Vector2(30*(Health/MaxHealth),6), SpriteEffects.None, 1);
        }
    }
}
