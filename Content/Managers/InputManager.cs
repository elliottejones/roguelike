using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace game2.Content.Managers
{
    internal class InputManager
    {
        public static Vector2 MoveVector = Vector2.Zero;

        public static void Update(KeyboardState kb)
        {
            Vector2 output = Vector2.Zero;

            if (kb.IsKeyDown(Keys.W)) output += new Vector2(0, -1);
            if (kb.IsKeyDown(Keys.A)) output += new Vector2(-1, 0);
            if (kb.IsKeyDown(Keys.S)) output += new Vector2(0, 1);
            if (kb.IsKeyDown(Keys.D)) output += new Vector2(1, 0);

            if (output.LengthSquared() > 0)
            {
                output = Vector2.Normalize(output);
            }

            MoveVector = output;
        }
    }
}