using SFML.Graphics;
using SFML.System;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Actors
{
    public class Drawable
    {
        private static List<Drawable> drawables = new List<Drawable>();
        public static List<Drawable> Drawables { get { return drawables; } }
        protected string texturePath;
        protected Texture texture;
        protected Sprite sprite;
        protected Vector2f position = new Vector2f(0,0);
        protected Vector2u size;
        public Vector2u Size => size;

        public Drawable()
        {
            Drawables.Add(this);
        }

        protected virtual void UpdateTexture()
        {
            texture.Smooth = true;
            size = texture.Size;
            sprite = new Sprite(texture);
        }

        public virtual void Draw()
        {
            if (sprite == null) return;
            if(sprite.Position != position)
            sprite.Position = position;
            Finder.Window.Draw(sprite);
        }
    }
}
