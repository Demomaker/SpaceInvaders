using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SpaceInvaders.Utils;

namespace SpaceInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Init();
            while(Finder.Window.IsOpen)
            {
                game.Inputs();
                game.Update();
                game.Draw();
            }
        }
    }
}
