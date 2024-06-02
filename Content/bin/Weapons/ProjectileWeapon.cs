using game2.Content.Managers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace game2.Content.bin.Weapons
{
    internal class ProjectileWeapon
    {
        private float AttackDelay;
        private float ProjectileSpeed;
        private float Damage;
        private float Penetration;

        private float TimeUntilNextAttack;

        private Vector2 Direction;

        private List<Projectile> Projectiles = new List<Projectile>();
        private List<Projectile> ProjectilesToRemove = new List<Projectile>();

        private Texture2D ProjectileTexture;

        public ProjectileWeapon(float AttackDelay, float ProjectileSpeed, float Damage, float Penetration, Texture2D ProjectileTexture)
        {
            this.AttackDelay = AttackDelay;
            this.ProjectileSpeed = ProjectileSpeed;
            this.Damage = Damage;
            this.Penetration = Penetration;
            this.ProjectileTexture = ProjectileTexture;
            this.Direction = new Vector2(1, 0);
        }

        public void Update(Vector2 StartPosition)
        {
            Vector2 inputDirection = InputManager.MoveVector;

            if (inputDirection != Vector2.Zero)
            {
                Direction = inputDirection;
                Direction = Vector2.Normalize(Direction); 
            }

            TimeUntilNextAttack -= Globals.TotalSeconds;

            if (TimeUntilNextAttack <= 0)
            {
                TimeUntilNextAttack = AttackDelay;
                Projectiles.Add(new Projectile(ProjectileTexture, ProjectileSpeed, Damage, Penetration, StartPosition, Direction, this));

                EnemyManager.Spawn(StartPosition);
            }

            foreach (Projectile projectile in Projectiles)
            {
                projectile.Update();
            }

            foreach (Projectile projectile in ProjectilesToRemove)
            {
                Projectiles.Remove(projectile);
            }
            ProjectilesToRemove.Clear();
        }

        public void Draw()
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Draw();
            }
        }

        public void ProjectileHit(Projectile Projectile)
        {
            ProjectilesToRemove.Add(Projectile);
        }
    }
}