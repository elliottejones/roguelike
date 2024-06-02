using game2.Content.Characters;
using game2.Content.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2.Content.bin.Weapons
{
    internal class Projectile
    {
        private Texture2D Texture;
        private float Speed;
        private float Damage;
        private float Penetration;
        private Vector2 Direction;
        private ProjectileWeapon FiredFrom;

        private Vector2 StartPosition;
        private Vector2 Position;

        private SpriteEffects Flipped;

        public Projectile(Texture2D Texture, float Speed, float Damage, float Penetration, Vector2 StartPosition, Vector2 Direction, ProjectileWeapon FiredFrom)
        {
            Position = StartPosition;

            this.Texture = Texture;
            this.Speed = Speed;
            this.Damage = Damage;
            this.Penetration = Penetration;
            this.Direction = Direction;
            this.FiredFrom = FiredFrom;
        }

        public void Update()
        {
            Position += Direction * Speed;

            if (Math.Abs(Position.X) > 1024 || Math.Abs(Position.Y) > 1024)
            {
                FiredFrom.ProjectileHit(this);
            }

            foreach (Enemy enemy in EnemyManager.Enemies)
            {
                if (enemy.Collider.Contains(Position))
                {
                    Console.WriteLine(Position);
                    Console.WriteLine("Hit");
                    enemy.Damage(Damage);
                    Penetration--;

                    if (Penetration == 0)
                    {
                        FiredFrom.ProjectileHit(this);
                    }
                }
            }
        }

        public void Draw()
        {
            if (Direction.X < 0)
            {
                Flipped = SpriteEffects.FlipHorizontally;
            }
            else
            {
                Flipped = SpriteEffects.None;
            }
            Globals.SpriteBatch.Draw(Texture, Position, null, Microsoft.Xna.Framework.Color.White, (float)Math.Atan(Direction.Y/Direction.X), new Vector2(Texture.Width / 2, Texture.Height / 2), new Vector2(3,3), Flipped, 1);
        }
    }
}
