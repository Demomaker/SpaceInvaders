using SpaceInvaders.Actors;
using SpaceInvaders.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Utils
{
    public static class Screen
    {
        public static bool IsOutOfScreen(this Object obj)
        {
            if (!(obj is Updatable)) return false;
            if((obj as Updatable).Position.X > Constants.Window.WINDOW_WIDTH || (obj as Updatable).Position.Y > Constants.Window.WINDOW_HEIGHT || (obj as Updatable).Position.X + (obj as Updatable).Size.X < 0 || (obj as Updatable).Position.Y + (obj as Updatable).Size.Y < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
