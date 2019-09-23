using SFML.System;
using SpaceInvaders.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Actors
{
    public static class EnemyMap
    {
        private static Enemy[,] enemyMap = null;
        private static NoEnemy noEnemy = new NoEnemy();

        public static Enemy[,] Map
        {
            get
            {
                if(enemyMap == null)
                {
                    enemyMap = new Enemy[Constants.World.AMOUNT_OF_ENEMIES_IN_X, Constants.World.AMOUNT_OF_ENEMIES_IN_Y];
                    InitializeMap();
                }
                return enemyMap;
            }

            private set
            {
                enemyMap = value;
            }
        }

        public static void InitializeMap()
        {
            for(int x = 0; x < Constants.World.AMOUNT_OF_ENEMIES_IN_X; x++)
            {
                for(int y = 0; y < Constants.World.AMOUNT_OF_ENEMIES_IN_Y; y++)
                {
                    Map[x, y] = new NoEnemy();
                }
            }
        }

        public static bool AllEnemiesAreDead()
        {
            for (int x = 0; x < Constants.World.AMOUNT_OF_ENEMIES_IN_X; x++)
            {
                for (int y = 0; y < Constants.World.AMOUNT_OF_ENEMIES_IN_Y; y++)
                {
                    if (!(Map[x, y] is NoEnemy))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void AddEnemyToMap(this Enemy enemy)
        {
            bool getOutOfLoop = false;
            for (int x = 0; x < Constants.World.AMOUNT_OF_ENEMIES_IN_X; x++)
            {
                for(int y = 0; y < Constants.World.AMOUNT_OF_ENEMIES_IN_Y; y++)
                {
                    if(Map[x,y] is NoEnemy)
                    {
                        enemy.Position = new SFML.System.Vector2f(Constants.World.ENEMY_MAP_OFFSET_IN_X + Constants.World.ENEMY_OFFSET_IN_X * x, Constants.World.ENEMY_OFFSET_IN_Y * y);
                        enemy.StartingPosition = enemy.Position;
                        Map[x, y] = enemy;
                        getOutOfLoop = true;
                    }
                    if (getOutOfLoop) break;
                }
                if (getOutOfLoop) break;
            }
        }

        public static void RemoveEnemyFromMap(this Enemy enemy)
        {
            Enemy something = enemy;
            bool getOutOfLoop = false;
            for (int x = 0; x < Constants.World.AMOUNT_OF_ENEMIES_IN_X; x++)
            {
                for (int y = 0; y < Constants.World.AMOUNT_OF_ENEMIES_IN_Y; y++)
                {
                    if (x == (enemy.StartingPosition.X - Constants.World.ENEMY_MAP_OFFSET_IN_X) / Constants.World.ENEMY_OFFSET_IN_X && y == enemy.StartingPosition.Y / Constants.World.ENEMY_OFFSET_IN_Y)
                    {
                        Map[x, y] = new NoEnemy();
                        getOutOfLoop = true;
                    }
                    if (getOutOfLoop) break;
                }
                if (getOutOfLoop) break;
            }
        }

        public static void Reset()
        {
            for (int x = 0; x < Constants.World.AMOUNT_OF_ENEMIES_IN_X; x++)
            {
                for (int y = 0; y < Constants.World.AMOUNT_OF_ENEMIES_IN_Y; y++)
                {
                    Map[x, y] = new NoEnemy();
                }

            }
        }
    }
}
