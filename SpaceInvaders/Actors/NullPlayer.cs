using SFML.Graphics;
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
    public class NullPlayer : Player
    {

        public bool PlayerDied => true;

        private static NullPlayer instance;
        public static NullPlayer Instance
        {
            get
            {
                if(instance == null)
                    instance = new NullPlayer();
                if(!Drawables.Contains(instance))
                    Drawables.Add(instance);
                return instance;
            }
        }

        public NullPlayer() : base()
        {
            texture = Assets.NoPlayerTexture;
            UpdateTexture();   
        }

        public override void Update()
        {
            //Vide
        }

        public override void Die()
        {
            //Vide
        }
    }
}
