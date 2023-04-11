using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace C1gameProject
{
    public class PlayerLandedState : State
    {
        private SpriteBatch spriteBatch = Program.game.spriteBatch;

        public Button buyButton;
        public Button endTurnButton;
        public List<Button> buttons;

        public PlayerLandedState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
            : base(_game, _graphicsDevice, _content)
        {
            buyButton = Initializer.CreateBuyButton(content);
            endTurnButton = Initializer.CreateEndTurnButton(content);
            endTurnButton.click += Initializer.ToETSGameButton;
            buttons = new List<Button>() { buyButton, endTurnButton };
        }

        public override void Update()
        {
            int playerIndex = MonopolyBoard.CurrentPlayerIndex;
            int playerCurrentPosition = MonopolyBoard.players[playerIndex].currentPosition;
            GameField currentTile = MonopolyBoard.allTiles[playerCurrentPosition];
            Program.game.text = $"Player {(playerIndex + 1)} is on \n{currentTile.name} field.\n";
            Program.game.text += MonopolyBoard.allTiles[playerCurrentPosition].PlayerAction(MonopolyBoard.players[MonopolyBoard.CurrentPlayerIndex]);
            Program.game.player1Money = MonopolyBoard.players[0].currentAmountOfMoney + "$";
            Program.game.player2Money = MonopolyBoard.players[1].currentAmountOfMoney + "$";

            if (currentTile is CityField)
            {
                var currentTileAsStreet = currentTile as CityField;
                if (currentTileAsStreet.owner != MonopolyBoard.players[MonopolyBoard.CurrentPlayerIndex] && currentTileAsStreet.owner == null)
                {
                    buyButton.click += Initializer.ToBUYameButton;
                }
                else //if (Program.game.shouldPlayerMove==false)
                {
                    if (MonopolyBoard.players[0].currentAmountOfMoney <= 0 || MonopolyBoard.players[1].currentAmountOfMoney <= 0)
                    {
                        game.ChangeState(new GameOverState(game, graphicsDevice, content));
                    }
                    else
                    {
                        game.ChangeState(new DisplayTextState(game, graphicsDevice, content));
                    }
                }

            }

            else if (currentTile is OtherField)
            {
                var currentTileAsSpecial = currentTile as OtherField;
                if (currentTile.name == "Go To Jail")
                {
                    Program.game.MovePlayer(MonopolyBoard.CurrentPlayerIndex, 15, 5);
                }
                else
                {
                    game.ChangeState(new DisplayTextState(game, graphicsDevice, content));
                }

            }

            else if (currentTile is TaxField)
            {
                if (MonopolyBoard.players[0].currentAmountOfMoney <= 0 || MonopolyBoard.players[1].currentAmountOfMoney <= 0)
                {
                    game.ChangeState(new GameOverState(game, graphicsDevice, content));
                }
                else
                {
                    game.ChangeState(new DisplayTextState(game, graphicsDevice, content));
                }
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
