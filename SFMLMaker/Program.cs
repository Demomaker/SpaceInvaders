using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;

namespace SFMLMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            RenderWindow renderWindow = new RenderWindow(SFML.Window.VideoMode.DesktopMode, "Jérémie Bertrand", SFML.Window.Styles.Titlebar);
            while(renderWindow.IsOpen)
            {
                game.Inputs();
                game.Update();
                game.Draw(renderWindow);
            }
        }
    }
}
