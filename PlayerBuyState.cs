using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace C1gameProject
{
    public class PlayerBuyState : State
    {
        private SpriteBatch spriteBatch = Program.game.spriteBatch;

        public Button buyButton;
        public Button endTurnButton;
        public List<Button> buttons;
        
        public static int playerCurrentPosition;
        public static int currentPlayer;

        public PlayerBuyState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
            : base(_game, _graphicsDevice, _content)
        {
            buyButton = Initializer.CreateBuyButton(content);
            endTurnButton = Initializer.CreateEndTurnButton(content);
            buttons = new List<Button>() { buyButton, endTurnButton };
        }

        public override void Update()
        {
            int playerIndex = MonopolyBoard.CurrentPlayerIndex;
            playerCurrentPosition = MonopolyBoard.players[playerIndex].currentPosition;
            GameField currentTile = MonopolyBoard.allTiles[playerCurrentPosition];
            currentPlayer = MonopolyBoard.CurrentPlayerIndex;
            MonopolyBoard.AddCityToPlayer(playerCurrentPosition, currentPlayer);

            Program.game.player1Money = MonopolyBoard.players[0].currentAmountOfMoney + "$";
            Program.game.player2Money = MonopolyBoard.players[1].currentAmountOfMoney + "$";

            if (MonopolyBoard.players[0].currentAmountOfMoney <= 0 || MonopolyBoard.players[1].currentAmountOfMoney <= 0)
            {
                State.game.ChangeState(new GameOverState(State.game, State.graphicsDevice, State.content));
            }
            else
            {
                State.game.ChangeState(new EndTurnState(State.game, State.graphicsDevice, State.content));
            }

            foreach (var _buttons in buttons)
                _buttons.Update(gameTime);
        }


        public override void Draw()
        {
            foreach (var _buttons in buttons)
                _buttons.Draw(gameTime, spriteBatch);
        }

    }
}
