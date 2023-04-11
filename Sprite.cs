using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace C1gameProject
{
    public class Sprite
    {
        public Rectangle rectangle;
        public Texture2D texture;
        public Sprite(Rectangle _rectangle, Texture2D _texture)
        {
            rectangle = _rectangle;
            texture = _texture;
        }

    }
}