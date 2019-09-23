using SpaceInvaders.Actors;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Common
{
    public static class InputHandler
    {
        public static void OnWindowClose(object sender, EventArgs e)
        {
            Finder.Window.Close();
        }

        public static EventHandler OnPlayerMoveRight()
        {
            Finder.Player.MoveWithVector(new SFML.System.Vector2f(Constants.Physics.MOVEMENT_SPEED,0));
            return null;
        }

        public static EventHandler OnPlayerMoveLeft()
        {
            Finder.Player.MoveWithVector(new SFML.System.Vector2f(-Constants.Physics.MOVEMENT_SPEED, 0)); return null;
        }

        public static EventHandler OnPlayerShoot()
        {
            int? missileIndex = Missile.Missiles.FindIndex(missil => missil is NoMissile);
            if (missileIndex == null || missileIndex < 0 || missileIndex > Missile.Missiles.Count) return null;
            Missile.Missiles[(int)missileIndex].Die();
            Missile.Missiles[(int)missileIndex] = new Missile();
            Missile.Missiles[(int)missileIndex].Position = Finder.Player.Position;
            Missile.Missiles[(int)missileIndex].SetParentType(typeof(Player));
            Missile.Missiles[(int)missileIndex].SetTargetType(typeof(Enemy));
            Missile.Missiles[(int)missileIndex].SetDirection(-Constants.World.MISSILE_SPEED);
            return null;
        }

        public static EventHandler OnRestart()
        {
            Finder.Game.ResetGame();
            return null;
        }
    }
}
