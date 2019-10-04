using SFML.Graphics;
using SpaceInvaders.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Utils
{
    public class Assets
    {
        private static Texture playerTexture;
        private static Texture enemyTexture;
        private static Texture missileTexture;
        private static Texture noPlayerTexture;
        private static Font font;
        private static Text scoreText;
        private static Text highscoreText;
        private static Text gameOverText;
        public static Texture PlayerTexture
        {
            get
            {
                if(playerTexture == null)
                {
                    playerTexture = new Texture(Constants.Resources.PathStrings.PLAYER);
                }
                return playerTexture;
            }
        }
        public static Texture EnemyTexture
        {
            get
            {
                if(enemyTexture == null)
                {
                    enemyTexture = new Texture(Constants.Resources.PathStrings.ENEMY);
                }
                return enemyTexture;
            }
        }
        public static Texture MissileTexture
        {
            get
            {
                if(missileTexture == null)
                {
                    missileTexture = new Texture(Constants.Resources.PathStrings.MISSILE);
                }
                return missileTexture;
            }
        }
        public static Texture NoPlayerTexture
        {
            get
            {
                if(noPlayerTexture == null)
                {
                    noPlayerTexture = new Texture(Constants.Resources.PathStrings.NO_PLAYER_PLACE_HOLDER);
                }
                return noPlayerTexture;
            }
        }
        public static Font Font
        {
            get
            {
                if(font == null)
                {
                    font = new Font(Constants.Resources.PathStrings.DEFAULT_FONT);
                }
                return font;
            }
        }
        public static Text ScoreText
        {
            get
            {
                if(scoreText == null)
                {
                    scoreText = new Text("Score : " + Finder.Score.ToString("00"), Font, Constants.World.FONT_SIZE);
                    scoreText.Position = new SFML.System.Vector2f(Constants.World.SCORE_POSITION_X, Constants.World.SCORE_POSITION_Y + (Constants.World.FONT_SIZE / 2));
                }
                return scoreText;
            }
        }

        public static Text HighscoreText
        {
            get
            {
                if(highscoreText == null)
                {
                    highscoreText = new Text("Highscore : " + Finder.Highscore.ToString("00"), font, Constants.World.FONT_SIZE);
                    highscoreText.Position = new SFML.System.Vector2f(Constants.World.HIGHSCORE_POSITION_X, Constants.World.HIGHSCORE_POSITION_Y + (Constants.World.FONT_SIZE / 2));
                }
                return highscoreText;
            }
        }

        public static Text GameOverText
        {
            get
            {
                if(gameOverText == null)
                {
                    gameOverText = new Text("GAME OVER!\n" + "Press " + Constants.Inputs.RESTART_KEY.ToString() + "\nTo Retry", font, Constants.World.FONT_SIZE * 2);
                    gameOverText.Position = new SFML.System.Vector2f(Constants.Window.WINDOW_WIDTH / 2 - 125, Constants.Window.WINDOW_HEIGHT / 2);
                }
                return gameOverText;
            }
        }

        public static void UpdateTextWithString(Text text, string newText)
        {
            text.DisplayedString = newText;
        }

        
    }
}
