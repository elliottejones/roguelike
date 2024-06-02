using game2.Content.bin.Datamodels;
using game2.Content.Characters;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game2.Content.Managers
{
    internal class GameManager
    {
        private Player player;
        private Camera camera;
        private Level level;

        public void Init()
        {
            player = new(new(0, 0), 3f);
            camera = new Camera();
            level = new Level(Globals.Content.Load<Texture2D>("level"));
        }

        public void Update()
        {
            player.Update();
            camera.Follow(player.Position, Globals.GraphicsDevice.Viewport);
            EnemyManager.Update(player);
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointWrap, null, null, null, camera.Transform);
            player.Draw();
            level.Draw();
            EnemyManager.Draw();
            Globals.SpriteBatch.End();
        }
    }
}
