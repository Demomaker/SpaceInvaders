using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SpaceInvaders.Actors;
using SpaceInvaders.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Utils
{
    public static class Finder
    {
        private static RenderWindow window;
        public static RenderWindow Window { get { return window ?? (window = new RenderWindow(new VideoMode(Constants.Window.WINDOW_WIDTH, Constants.Window.WINDOW_HEIGHT), Constants.Window.WINDOW_TITLE)) ; } }

        private static Player player = null;
        public static Player Player { get { return player;  } set { player = value; } }

        private static Game game = new Game();
        public static Game Game { get { return game;  } set { game = value; } }

        public static int Score = 0;
        public static int Highscore = 0;
        public static int TimeInMillisecondsBeforeEnemyMoves = Constants.World.STARTING_MILLISECOND_DIFFERENCE_BEFORE_ENEMY_MOVES;

        public static CollisionDetection CollisionDetecter = new CollisionDetection();
    }
}
