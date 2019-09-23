using SFML.Graphics;
using SpaceInvaders.Actors;
using SpaceInvaders.Common;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class Missile : Character
    {
        public static List<Missile> Missiles = new List<Missile>();
        public Type ParentType = null;
        public Type TargetType = null;
        private float direction = 1;
        public Missile() : base()
        {
            texture = Finder.Game.missileTexture;
            UpdateTexture();
        }
        
        public override void Die()
        {
            base.Die();
            Missiles[Missiles.IndexOf(this)] = new NoMissile();
            Drawables.Remove(this);
        }

        public override void Update()
        {
            base.Update();
            MoveWithVector(new SFML.System.Vector2f(0,direction));
        }

        public void SetParentType(Type type)
        {
            ParentType = type;
        }

        public void SetTargetType(Type type)
        {
            TargetType = type;
        }

        public void SetDirection(float direction)
        {
            this.direction = direction;
        }
    }
}
