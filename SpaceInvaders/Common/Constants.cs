using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Common
{
    public static class Constants
    {
        public static class Window
        {
            public const int WINDOW_WIDTH = 800;
            public const int WINDOW_HEIGHT = 600;
            public const string WINDOW_TITLE = "Space Invaders";
        }

        public static class Inputs
        {
            public const Keyboard.Key LEFT_KEY = Keyboard.Key.Left;
            public const Keyboard.Key RIGHT_KEY = Keyboard.Key.Right;
            public const Keyboard.Key SHOOT_KEY = Keyboard.Key.Space;
            public const Keyboard.Key RESTART_KEY = Keyboard.Key.Space;
        }

        public static class Physics
        {
            public const float FPS = 60.00f;
            public const float MOVEMENT_SPEED = 15f;
            public const float DELTA_TIME = 1 / FPS;
        }

        public static class World
        {
            public const int AMOUNT_OF_ENEMIES_IN_X = 8;
            public const int AMOUNT_OF_ENEMIES_IN_Y = 8;
            public const int ENEMY_OFFSET_IN_X = 64;
            public const int ENEMY_OFFSET_IN_Y = 64;
            public const int ENEMY_MAP_OFFSET_IN_X = Window.WINDOW_WIDTH / 2 - ENEMY_OFFSET_IN_X * AMOUNT_OF_ENEMIES_IN_X / 2 - 50;
            public const int ENEMY_TELEPORT_GAP_Y = 32;
            public const int ENEMY_TELEPORT_GAP_X = 32;
            public const int MAX_X_POSITION_CHANGE_BEFORE_Y_POSITION_CHANGE = 16;
            public const int PLAYER_WIDTH = 16;
            public const int PLAYER_HEIGHT = 16;
            public const int PLAYER_DISTANCE_FROM_BOTTOM_OF_SCREEN = 32;
            public const int PLAYER_START_POSITION_X = Window.WINDOW_WIDTH / 2 - PLAYER_WIDTH / 2;
            public const int PLAYER_START_POSITION_Y = Window.WINDOW_HEIGHT - (PLAYER_HEIGHT + PLAYER_DISTANCE_FROM_BOTTOM_OF_SCREEN);
            public const int AMOUNT_OF_INSTANTIATED_MISSILES = 40;
            public const int MISSILE_SPEED = 20;
            public const int ENEMY_HIT_POINTS = 20;
            public const int FONT_SIZE = 20;
            public const int SCORE_POSITION_X = 0;
            public const int SCORE_POSITION_Y = 0;
            public const int HIGHSCORE_POSITION_X = Window.WINDOW_WIDTH - 200;
            public const int HIGHSCORE_POSITION_Y = 0;
            public const int STARTING_MILLISECOND_DIFFERENCE_BEFORE_ENEMY_MOVES = 200;
        }

        public static class Resources
        {


            public static class PathStrings
            {
                public const string RESOURCES_ROOT = "Resources";
                public const string ACTORS_ROOT = "/Actors";
                public const string NO_PLAYER_PLACE_HOLDER = RESOURCES_ROOT + ACTORS_ROOT + "/NoPlayer.png";
                public const string NO_ENEMY_PLACE_HOLDER = RESOURCES_ROOT + ACTORS_ROOT + "/";
                public const string ENEMY = RESOURCES_ROOT + ACTORS_ROOT + "/Enemy.png";
                public const string PLAYER = RESOURCES_ROOT + ACTORS_ROOT + "/Player.png";
                public const string MISSILE = RESOURCES_ROOT + ACTORS_ROOT + "/Missile.png";
                public const string DEFAULT_FONT = RESOURCES_ROOT + "/Rest" + "/Minecraftia-Regular.ttf";
            }
        }
    }
}
