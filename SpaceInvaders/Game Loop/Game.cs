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
        public Texture playerTexture;
        public Texture enemyTexture;
        public Texture missileTexture;
        public Texture noPlayerTexture;
        public Font font;
        public Text scoreText;
        public Text highscoreText;
        public Text gameOverText;
        public DateTime time = DateTime.Now;
        private List<Keyboard.Key> keysBeingUsed = new List<Keyboard.Key>();

        internal void Init()
        {
            Finder.Game = this;
            Finder.Window.Closed += InputHandler.OnWindowClose;
            Finder.CollisionDetecter.Collision += ObjectsCollided;
            LoadTextures();
            for (int i = 0; i < Constants.World.AMOUNT_OF_INSTANTIATED_MISSILES; i++)
            {
                Missile.Missiles.Add(new NoMissile());
            }
            Finder.Player = new Player();
            gameOverText = new Text("GAME OVER!\n" + "Press " + Constants.Inputs.RESTART_KEY.ToString() + "\nTo Retry",font,Constants.World.FONT_SIZE * 2);
            gameOverText.Position = new SFML.System.Vector2f(Constants.Window.WINDOW_WIDTH / 2 - 125, Constants.Window.WINDOW_HEIGHT / 2);
        }

        public void LoadTextures()
        {
            playerTexture = new Texture(Constants.Resources.PathStrings.PLAYER);
            enemyTexture = new Texture(Constants.Resources.PathStrings.ENEMY);
            missileTexture = new Texture(Constants.Resources.PathStrings.MISSILE);
            noPlayerTexture = new Texture(Constants.Resources.PathStrings.NO_PLAYER_PLACE_HOLDER);
            font = new Font(Constants.Resources.PathStrings.DEFAULT_FONT);
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
            if(!(Finder.Player is NoPlayer))
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
            renderWindow.Draw(scoreText);
            renderWindow.Draw(highscoreText);
            if (Finder.Player is NoPlayer)
                renderWindow.Draw(gameOverText);
            renderWindow.Display();
        }

        internal void Update()
        {
            if(DateTime.Now.Millisecond - time.Millisecond > 900)
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

            highscoreText = new Text("Highscore : " + Finder.Highscore.ToString("00"),font,Constants.World.FONT_SIZE);
            highscoreText.Position = new SFML.System.Vector2f(Constants.World.HIGHSCORE_POSITION_X, Constants.World.HIGHSCORE_POSITION_Y + (Constants.World.FONT_SIZE / 2));
            scoreText = new Text("Score : " + Finder.Score.ToString("00"),font, Constants.World.FONT_SIZE);
            scoreText.Position = new SFML.System.Vector2f(Constants.World.SCORE_POSITION_X, Constants.World.SCORE_POSITION_Y + (Constants.World.FONT_SIZE / 2));
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
