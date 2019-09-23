using SpaceInvaders.Utils;
using static SpaceInvaders.Actors.EnemyMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.Common;
using SFML.Graphics;

namespace SpaceInvaders.Actors
{
    public class Enemy : Character
    {
        public static List<Enemy> Enemies { get; } = new List<Enemy>();
        private DateTime time = DateTime.Now;
        private int xPositionChange = 0;
        private int direction = 1;
        private static Random deathChance = new Random();

        public Enemy() : base()
        {
            texture = Finder.Game.enemyTexture;
            UpdateTexture();
            this.AddEnemyToMap();
        }
        

        public override void Update()
        {
            if(Math.Abs(DateTime.Now.Millisecond - time.Millisecond) >= Finder.TimeInMillisecondsBeforeEnemyMoves)
            {
                time = DateTime.Now;
                xPositionChange++;
                MoveWithVector(new SFML.System.Vector2f(Constants.World.ENEMY_TELEPORT_GAP_X * direction, 0));
                if(xPositionChange >= Constants.World.MAX_X_POSITION_CHANGE_BEFORE_Y_POSITION_CHANGE)
                {
                    direction *= -1;
                    xPositionChange = 0;
                    MoveWithVector(new SFML.System.Vector2f(0, Constants.World.ENEMY_TELEPORT_GAP_Y));
                }
                if (deathChance.Next(0, 100) < 1)
                {
                    LaunchMissile();
                }
            }
            base.Update();

        }

        private void LaunchMissile()
        {
            int? missileIndex = Missile.Missiles.FindIndex(missil => missil is NoMissile);
            if (missileIndex == null || missileIndex < 0 || missileIndex > Missile.Missiles.Count) return;
            Missile.Missiles[(int)missileIndex].Die();
            Missile.Missiles[(int)missileIndex] = new Missile();
            Missile.Missiles[(int)missileIndex].Position = this.Position;
            Missile.Missiles[(int)missileIndex].SetParentType(typeof(Enemy));
            Missile.Missiles[(int)missileIndex].SetTargetType(typeof(Player));
            Missile.Missiles[(int)missileIndex].SetDirection(Constants.World.MISSILE_SPEED);
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Die()
        {
            if (this.IsOutOfScreen())
            {
                Finder.Player.Die();
            }
            else
            {
                Finder.Score += Constants.World.ENEMY_HIT_POINTS;
            }
            base.Die();
            Enemies.Remove(this);
            Drawables.Remove(this);
            this.RemoveEnemyFromMap();
        }
    }
}
