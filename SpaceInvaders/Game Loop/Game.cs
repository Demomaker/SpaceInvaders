using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SpaceInvaders.Actors;
using SpaceInvaders.Common;
using SpaceInvaders.Utils;
using static SpaceInvaders.Utils.CollisionDetection;

namespace SpaceInvaders
{
    public class Game
    {
        public DateTime time = DateTime.Now;
        private List<Keyboard.Key> keysBeingUsed = new List<Keyboard.Key>();

        internal void Init()
        {
            Finder.Game = this;
            Finder.Window.Closed += InputHandler.OnWindowClose;
            Finder.CollisionDetecter.Collision += ObjectsCollided;
            for (int i = 0; i < Constants.World.AMOUNT_OF_INSTANTIATED_MISSILES; i++)
            {
                Missile.Missiles.Add(new NoMissile());
            }
            Finder.Player = new Player();
        }

        public void ResetGame()
        {
            if (Finder.Score > Finder.Highscore)
                Finder.Highscore = Finder.Score;
            Finder.Score = 0;
            Finder.TimeInMillisecondsBeforeEnemyMoves = Constants.World.STARTING_MILLISECOND_DIFFERENCE_BEFORE_ENEMY_MOVES;
            Updatable.Updatables.Clear();
            Actors.Drawable.Drawables.Clear();
            Enemy.Enemies.Clear();
            EnemyMap.Reset();
            Finder.Player = new Player();

        }

        internal void Inputs()
        {
            if(!(Finder.Player is NullPlayer))
            {
                OnKeyPressed(Constants.Inputs.LEFT_KEY, InputHandler.OnPlayerMoveLeft);
                OnKeyPressed(Constants.Inputs.RIGHT_KEY, InputHandler.OnPlayerMoveRight);
                OnKeyPressedOnce(Constants.Inputs.SHOOT_KEY, InputHandler.OnPlayerShoot);
            }
            else
            {
                OnKeyPressedOnce(Constants.Inputs.RESTART_KEY, InputHandler.OnRestart);
            }
            Finder.Window.DispatchEvents();
        }

        internal void Draw()
        {
            RenderWindow renderWindow = Finder.Window;
            renderWindow.Clear();
            foreach(SpaceInvaders.Actors.Drawable drawable in SpaceInvaders.Actors.Drawable.Drawables)
            {
                drawable.Draw();
            }
            renderWindow.Draw(Assets.ScoreText);
            renderWindow.Draw(Assets.HighscoreText);
            if (Finder.Player.PlayerDied)
                renderWindow.Draw(Assets.GameOverText);
            renderWindow.Display();
        }

        internal void Update()
        {
            if(DateTime.Now.Millisecond - time.Millisecond > Constants.World.NUMBER_OF_MILLISECONDS_BEFORE_SPEED_CHANGE)
            {
                if (Finder.TimeInMillisecondsBeforeEnemyMoves > 1)
                    Finder.TimeInMillisecondsBeforeEnemyMoves--;
            }

            if(EnemyMap.AllEnemiesAreDead())
            {
                SpawnEnemies();
                Thread.Sleep(100); 
            }

            Finder.CollisionDetecter.DetectCollision();

            for(int i = 0; i < Updatable.Updatables.Count; i++)
            {
                Updatable.Updatables[i].Update();
            }
        }

        internal void OnKeyPressed(Keyboard.Key key, Func<EventHandler> eventHandler)
        {
            if (Keyboard.IsKeyPressed(key))
            {
                keysBeingUsed.Add(key);
                eventHandler();
            }
            else
            {
                keysBeingUsed.Remove(key);
            }
        }

        internal void OnKeyPressedOnce(Keyboard.Key key, Func<EventHandler> eventHandler)
        {
            if (Keyboard.IsKeyPressed(key) && KeyAvailable(key))
            {
                keysBeingUsed.Add(key);
                eventHandler();
            }
            else if(!Keyboard.IsKeyPressed(key))
            {
                keysBeingUsed.Remove(key);
            }
        }

        internal bool KeyAvailable(Keyboard.Key key)
        {
            return !keysBeingUsed.Contains(key);
        }

        public void SpawnEnemies()
        {
            for (int i = 0; i < Constants.World.AMOUNT_OF_ENEMIES_IN_X * Constants.World.AMOUNT_OF_ENEMIES_IN_Y; i++)
            {
                Enemy.Enemies.Add(new Enemy());
            }
        }

        public static EventHandler OnScoreChange()
        {
            Assets.UpdateTextWithString(Assets.ScoreText, "Score : " + Finder.Score.ToString("00"));
            return null;
        }

        public static EventHandler OnHighScoreChange()
        {
            Assets.UpdateTextWithString(Assets.HighscoreText, "Highscore : " + Finder.Highscore.ToString("00"));
            return null;
        }

        private static void ObjectsCollided(object sender, EventArgs e)
        {
            Updatable collidingObject1 = (Updatable)(e as CollisionEventArgs).object1;
            Updatable collidingObject2 = (Updatable)(e as CollisionEventArgs).object2;
            if (collidingObject1 is Missile)
            {
                if (collidingObject2 is Player)
                {
                    if ((collidingObject1 as Missile).ParentType == typeof(Enemy))
                    {
                        collidingObject2.Die();
                        collidingObject1.Die();
                    }
                }

                if (collidingObject2 is Enemy)
                {
                    if ((collidingObject1 as Missile).ParentType == typeof(Player))
                    {
                        collidingObject2.Die();
                        collidingObject1.Die();
                    }
                }
            }

            if (collidingObject1 is Player)
            {
                if (collidingObject2 is Missile)
                {
                    if ((collidingObject2 as Missile).ParentType == typeof(Enemy))
                    {
                        collidingObject1.Die();
                        collidingObject2.Die();
                    }
                }
            }

            if (collidingObject1 is Enemy)
            {
                if (collidingObject2 is Missile)
                {
                    if ((collidingObject2 as Missile).ParentType == typeof(Player))
                    {
                        collidingObject1.Die();
                        collidingObject2.Die();
                    }
                }
            }
        }
    }
}
