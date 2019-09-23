using SpaceInvaders.Common;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Actors
{
    /*
        Implémentation du patron de conception NullObject 
    */
    public class NoEnemy : Enemy
    {
        public NoEnemy() : base()
        {
            sprite = null;
            Position = new SFML.System.Vector2f(-size.X, -size.Y);
        }

        public override void Die()
        {
            
        }

        public override void Update()
        {
        }

        protected override void UpdateTexture()
        {

        }
    }
}
