using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;



namespace C1gameProject
{
    
    public class PlayerRollState : State
    {
        private SpriteBatch spriteBatch = Program.game.spriteBatch;

        public Button buyButton;
        public Button endTurnButton;
        public List<Button> buttons;

        public static int positionToMove;
        public static int currentPlayerPosition;
        public PlayerRollState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
            : base(_game, _graphicsDevice, _content)
        {

            Random rng = new Random();
            positionToMove = rng.Next(1, 6);

            Program.game.text = $"Player {(MonopolyBoard.CurrentPlayerIndex + 1)} rolled {positionToMove}";

            buyButton = Initializer.CreateBuyButton(content);
            endTurnButton = Initializer.CreateEndTurnButton(content);
            buttons = new List<Button>() { buyButton, endTurnButton };

            currentPlayerPosition = MonopolyBoard.players[MonopolyBoard.CurrentPlayerIndex].currentPosition;

            PlayerMoveState.playerOldPosition = currentPlayerPosition;
            MonopolyBoard.players[MonopolyBoard.CurrentPlayerIndex].SetPosition(currentPlayerPosition + positionToMove);
        }

        public override void Update()
        {
            foreach (var _buttons in buttons)
                _buttons.Update(gameTime);

            game.ChangeState(new PlayerMoveState(game, graphicsDevice, content));
        }

        public override void Draw()
        {
            foreach (var _buttons in buttons)
                _buttons.Draw(gameTime, spriteBatch);
        }
    }

}
