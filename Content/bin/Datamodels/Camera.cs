using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Matrix = Microsoft.Xna.Framework.Matrix;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace game2.Content.bin.Datamodels
{
    internal class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Vector2 targetPosition, Viewport viewport)
        {
            var position = Matrix.CreateTranslation(
                -targetPosition.X + viewport.Width / 2,
                -targetPosition.Y + viewport.Height / 2,
                0);
            Transform = position;
        }
    }
}
