using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace C1gameProject
{
    public class DisplayTextState : State
    {
        private SpriteBatch spriteBatch = Program.game.spriteBatch;

        public Button buyButton;
        public Button endTurnButton;
        public List<Button> buttons;
        public DisplayTextState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
            : base(_game, _graphicsDevice, _content)
        {

            buyButton = Initializer.CreateBuyButton(content);
            endTurnButton = Initializer.CreateEndTurnButton(content);
            endTurnButton.click += Initializer.ToETSGameButton;
            buttons = new List<Button>() { buyButton, endTurnButton };

            int playerIndex = MonopolyBoard.CurrentPlayerIndex;
            int playerCurrentPosition = MonopolyBoard.players[playerIndex].currentPosition;
            GameField currentTile = MonopolyBoard.allTiles[playerCurrentPosition];
            Program.game.text = $"Player {(playerIndex + 1)} is on \n{currentTile.name} field.\n";
            Program.game.text += MonopolyBoard.allTiles[playerCurrentPosition].PlayerAction(MonopolyBoard.players[MonopolyBoard.CurrentPlayerIndex]);
        }

        public override void Update()
        {

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
