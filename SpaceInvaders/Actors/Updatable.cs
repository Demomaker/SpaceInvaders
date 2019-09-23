using SFML.System;
using static SpaceInvaders.Utils.Screen;
using SpaceInvaders.Common;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpaceInvaders.Utils.CollisionDetection;

namespace SpaceInvaders.Actors
{
    public class Updatable : Drawable
    {
        private static List<Updatable> updatables = new List<Updatable>();
        public static List<Updatable> Updatables { get { return updatables; } set { updatables = value; } }
        public Vector2f Position { get { return position; } set { position = value; } }
        public Vector2f StartingPosition;

        public Updatable() : base()
        {
            Updatables.Add(this);
        }

        public virtual void Update()
        {
            if(this.IsOutOfScreen() && !(this is Player))
            {
                Die();    
            }
        }

        public void MoveWithVector(Vector2f movementVector)
        {
            Position += movementVector * Constants.Physics.DELTA_TIME * Constants.Physics.MOVEMENT_SPEED;
        }

        public virtual void Die()
        {
            Updatables.Remove(this);
        }
    }
}
