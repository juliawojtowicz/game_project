using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace C1gameProject
{
    public class GameOverState : State
    {
        private SpriteBatch spriteBatch = Program.game.spriteBatch;

        public Button startNewGame;
        public Button quitGame;
        public List<Button> buttons;

        public GameOverState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
            : base(_game, _graphicsDevice, _content)
        {
            startNewGame = Initializer.CreateNewGame(content);
            quitGame = Initializer.CreateGameOver(content);
            startNewGame.click += Initializer.ToISGameButton;
            quitGame.click += Initializer.ExitGameButton;
            buttons = new List<Button>() { startNewGame, quitGame };

            Program.game.text = $"Player {MonopolyBoard.CurrentPlayerIndex + 1} lost with {MonopolyBoard.players[MonopolyBoard.CurrentPlayerIndex].currentAmountOfMoney}$." +
                $"\nPlayer {MonopolyBoard.CurrentPlayerIndex + 1} was \non {MonopolyBoard.allTiles[MonopolyBoard.players[MonopolyBoard.CurrentPlayerIndex].currentPosition].name}";
        }

        public override void Update()
        {
            Program.game.MovePlayer(0, MonopolyBoard.players[0].currentPosition, 0);
            Program.game.MovePlayer(1, MonopolyBoard.players[1].currentPosition, 0);

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

