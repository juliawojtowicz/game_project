using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace C1gameProject
{
    public class EndTurnState : State
    {
        public EndTurnState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
            : base(_game, _graphicsDevice, _content) { }

        public override void Update()
        {
            MonopolyBoard.CurrentPlayerIndex = (MonopolyBoard.CurrentPlayerIndex + 1) % 2;

            game.ChangeState(new PlayerTurnState(game, graphicsDevice, content));
        }

        public override void Draw()
        { }

    }
}
