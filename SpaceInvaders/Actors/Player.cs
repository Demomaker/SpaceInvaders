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
    public class Player : Character
    {
        public bool PlayerDied => false;

        public Player() : base()
        {
            texture = Assets.PlayerTexture;
            UpdateTexture();
            Position = new SFML.System.Vector2f(Constants.World.PLAYER_START_POSITION_X, Constants.World.PLAYER_START_POSITION_Y);
        }
        

        public override void Die()
        {
            base.Die();
            Finder.Player = NullPlayer.Instance;
            Finder.Player.Position = this.Position;
            Drawables.Remove(this);
        }
    }
}
