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
    public class NoMissile : Missile
    {
        public NoMissile() : base()
        {
            sprite = null;
            Position = new SFML.System.Vector2f(-32,-32);
        }

        public override void Die()
        {
            Updatables.Remove(this);
            Drawables.Remove(this);
        }

        public override void Update()
        {
        }

        protected override void UpdateTexture()
        {

        }
    }
}
