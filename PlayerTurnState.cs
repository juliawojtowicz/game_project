using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace C1gameProject
{
    public class PlayerTurnState : State
    {
        private SpriteBatch spriteBatch = Program.game.spriteBatch;

        public Button rollButton;
        public Button endTurnButton;
        public List<Button> buttons;
        public PlayerTurnState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
            : base(_game, _graphicsDevice, _content)
        {

            Program.game.text = $"Player { MonopolyBoard.CurrentPlayerIndex + 1}'s turn. \nPlease roll!";

            rollButton = Initializer.CreateRollButton(content);
            endTurnButton = Initializer.CreateEndTurnButton(content);
            rollButton.click += Initializer.ToPRSGameButton;
            endTurnButton.click += Initializer.ToETSGameButton;
            buttons = new List<Button>() { rollButton, endTurnButton };

            Program.game.shouldPlayerMove = true;
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