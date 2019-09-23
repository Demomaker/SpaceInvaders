using SpaceInvaders.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Utils
{
    public class CollisionDetection
    {
        public class CollisionEventArgs : EventArgs
        {
            public Object object1 { get; set; }
            public Object object2 { get; set; }
            public CollisionEventArgs(Object object1, Object object2)
            {
                this.object1 = object1;
                this.object2 = object2;
            }
        }
        public EventHandler Collision { get; set; }
        public void RaiseCollision(Object object1, Object object2)
        {
            Collision.Invoke(this, new CollisionEventArgs(object1, object2));
        }

        public void DetectCollision()
        {
            Object collisioner1 = null;
            Object collisioner2 = null;
            bool collisionDetected = false;
            for(int i = 0; i < Updatable.Updatables.Count; i++)
            {
                for(int j = 0; j < Updatable.Updatables.Count; j++)
                {
                    if (i == j) continue;
                    if (AreColliding(Updatable.Updatables[i], Updatable.Updatables[j]))
                    {
                        collisioner1 = Updatable.Updatables[i];
                        collisioner2 = Updatable.Updatables[j];
                        collisionDetected = true;
                    }
                    if(collisionDetected)
                    {
                        break;
                    }
                }
                if(collisionDetected)
                {
                    break;
                }
            }
            if(collisionDetected)
            RaiseCollision(collisioner1, collisioner2);
        }

        public bool AreColliding(Object object1, Object object2)
        {
            if (!(object1 is Updatable) || !(object2 is Updatable)) return false;

            Updatable updatable1 = (object1 as Updatable);
            Updatable updatable2 = (object2 as Updatable);

            if (updatable1.Position.X + updatable1.Size.X > updatable2.Position.X && updatable1.Position.Y + updatable1.Size.Y > updatable2.Position.Y && updatable1.Position.X + updatable1.Size.X < updatable2.Position.X + updatable2.Size.X && updatable1.Position.Y + updatable1.Size.Y < updatable2.Position.Y + updatable2.Size.Y
                || updatable2.Position.X + updatable2.Size.X > updatable1.Position.X && updatable2.Position.Y + updatable2.Size.Y > updatable1.Position.Y && updatable2.Position.X + updatable2.Size.X < updatable1.Position.X + updatable1.Size.X && updatable2.Position.Y + updatable2.Size.Y < updatable1.Position.Y + updatable1.Size.Y)
            {
                return true;
            }
            return false;
        }
    }
}
