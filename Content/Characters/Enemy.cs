using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomUtil = SharpDX.RandomUtil;
using game2.Content.bin.Datamodels;
using game2.Content.Managers;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

namespace game2.Content.Characters
{
    internal class Enemy
    {
        private Texture2D Texture;
        public Vector2 Position { get; private set; }
        private readonly Animation Animation;

        private float MoveSpeed;
        private float Health = 1;
        private float HitDamage;
        private float HitDelay;

        private float TimeUntilNextHit;

        public Rectangle Collider;

        private Random Random = new Random();

        public Enemy(Texture2D texture, float moveSpeed, Vector2 PlayerPositiion, float HitDamage, float HitDelay)
        {
            Position = new Vector2(PlayerPositiion.X + RandomUtil.NextFloat(Random,-300,300), PlayerPositiion.Y + RandomUtil.NextFloat(Random, -300, 300));
            Collider = new Rectangle(new Point(0, 0), new Point(texture.Width / 5, texture.Height));

            Texture = texture;
            MoveSpeed = moveSpeed;
            this.HitDamage = HitDamage;
            this.HitDelay = HitDelay;

            TimeUntilNextHit = HitDelay;

            Animation = new Animation(texture, 32, 5, 0.1f);
            Animation.Start(); 
        }

        public void Update(Player player)
        {
            Vector2 direction = player.Position - Position;

            if (direction != Vector2.Zero)
                direction.Normalize();

            Vector2 movement = direction * MoveSpeed;

            Position += movement;

            Collider.Location = new Point((int)Position.X - Texture.Width / 10, (int)Position.Y - Texture.Height / 2);

            TimeUntilNextHit -= Globals.TotalSeconds;

            if (Collider.Contains(player.Position))
            {
                if (TimeUntilNextHit <= 0)
                {
                    TimeUntilNextHit = HitDelay;
                    player.Damage(HitDamage);
                }

                Position -= movement;
            }

            if (Health <= 0)
            {
                Death();
            }
        }

        public void Draw()
        {
            Animation.Draw(Position, Globals.Orientation.left);
        }

        public void Damage(float damage)
        {
            Health -= damage;
        }

        public void Death()
        {
            EnemyManager.RemoveEnemy(this);
        }
    }
}
