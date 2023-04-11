using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace C1gameProject
{
    public class InitialState : State
    {
        private SpriteBatch spriteBatch = Program.game.spriteBatch;

        public Button startButton;
        public InitialState(Game1 _game, GraphicsDevice _graphicsDevice, ContentManager _content)
            : base(_game, _graphicsDevice, _content)
        {
            MonopolyBoard.InitializeBoard(); 

            startButton = Initializer.CreateStartButton(content);
            startButton.click += Initializer.ToPTSGameButton;

            Program.game.players = new List<Player>();
            Program.game.players.Add(Program.game.player1);
            Program.game.players.Add(Program.game.player2);

            Program.game.text = "Lets start the game.";
            Program.game.player1Money = "2000$";
            Program.game.player2Money = "2000$";
        }

        public override void Update()
        {
            startButton.Update(gameTime);
        }

        public override void Draw()
        {
            startButton.Draw(gameTime, spriteBatch);
            foreach (var _players in Program.game.players)
                _players.Draw(spriteBatch);
        }

    }
}
