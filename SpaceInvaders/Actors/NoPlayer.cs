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
    public class NoPlayer : Player
    {

        public NoPlayer() : base()
        {
            texture = Finder.Game.noPlayerTexture;
            UpdateTexture();
        }
    }
}
