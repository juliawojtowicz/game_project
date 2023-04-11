using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;


namespace C1gameProject
{
    public class PlayerMoveState : State
    {
        private SpriteBatch spriteBatch = Program.game.spriteBatch;

        public Button buyButton;
        public Button endTurnButton;
        public List<Button> buttons;
        public static int playerOldPosition;

        public PlayerMoveState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
        : base(_game, _graphicsDevice, _content)
        {
            buyButton = Initializer.CreateBuyButton(content);
            endTurnButton = Initializer.CreateEndTurnButton(content);
            buttons = new List<Button>() { buyButton, endTurnButton };
        }

        public override void Update()
        {
            foreach (var _buttons in buttons)
                _buttons.Update(gameTime);

            Program.game.MovePlayer(MonopolyBoard.CurrentPlayerIndex, playerOldPosition, MonopolyBoard.players[MonopolyBoard.CurrentPlayerIndex].currentPosition);
            if (Program.game.shouldPlayerMove==false)
            {
                game.ChangeState(new PlayerLandedState(game, graphicsDevice, content));
            }
        }

        public override void Draw()
        {
            foreach (var _buttons in buttons)
                _buttons.Draw(gameTime, spriteBatch);
        }
    }
}




