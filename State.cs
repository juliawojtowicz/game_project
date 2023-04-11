using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace C1gameProject
{
    public abstract class State
    {
        public static ContentManager content;
        public static GraphicsDevice graphicsDevice;
        public static Game1 game;
        public static GameTime gameTime;

        public State(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
        {
            game = _game;
            graphicsDevice = _graphicsDevice;
            content = _content;

        }

        public abstract void Update();

        public abstract void Draw();

    }
}