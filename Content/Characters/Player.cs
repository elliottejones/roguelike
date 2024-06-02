using game2.Content.bin.Datamodels;
using game2.Content.bin.Weapons;
using game2.Content.Managers;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace game2.Content.Characters
{
    internal class Player
    {
        private static Texture2D Texture;
        public Vector2 Position { get; private set; }
        private readonly Animation Animation;
        private readonly HealthBar HealthBar;

        private float MoveSpeed;
        private float Health = 100;
        private float MaxHealth = 100;

        private List<ProjectileWeapon> ProjectileWeapons = new List<ProjectileWeapon>();

        private Globals.Orientation Orientation;

        public Player(Vector2 pos, float MoveSpeed)
        {
            Texture = Globals.Content.Load<Texture2D>("character");

            Animation = new Animation(Texture, 32, 5, 0.09f);
            HealthBar = new HealthBar(Globals.Content.Load<Texture2D>("healthbar"), Globals.Content.Load<Texture2D>("healthbit"));

            ProjectileWeapons.Add(new ProjectileWeapon(AttackDelay: 1f, ProjectileSpeed: 15, Damage: 30, Penetration: 2, Globals.Content.Load<Texture2D>("arrow")));

            Position = pos;
            this.MoveSpeed = MoveSpeed;

        }

        public void Update()
        {
            if (Globals.GetMagnitude(InputManager.MoveVector) > 0)
            {
                if (InputManager.MoveVector.X > 0)
                {
                    Orientation = Globals.Orientation.right;
                }
                else if (InputManager.MoveVector.X < 0)
                {
                    Orientation = Globals.Orientation.left;
                }

                Animation.Start();
                Position += InputManager.MoveVector * MoveSpeed;
            }
            else
            {
                Animation.Reset();
                Animation.Stop();
            }

            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine("Game Over");
            }

            foreach (var item in ProjectileWeapons)
            {
                item.Update(Position);
            }

            Animation.Update();    
        }

        public void Draw()
        {
            foreach (var item in ProjectileWeapons)
            {
                item.Draw();
            }

            Animation.Draw(Position, Orientation);

            if (Health != MaxHealth)
            {
                HealthBar.Draw(Position, Health, MaxHealth);
            }   
        }

        public void Damage(float damage)
        {
            Health -= damage;
        }

    }
}
