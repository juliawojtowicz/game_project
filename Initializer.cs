using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace C1gameProject
{
    public static class Initializer
    {
        public static Button CreateStartButton(ContentManager content)
        {
            Texture2D startButton = content.Load<Texture2D>("StartButton");

            var startGameButton = new Button(startButton)
            {
                position = new Vector2(220, 300)
            };

            return startGameButton;
        }
        public static void ToPTSGameButton(object sender, EventArgs e)
        {
            State.game.ChangeState(new PlayerTurnState(State.game, State.graphicsDevice, State.content));
        }


        public static Button CreateRollButton(ContentManager content)
        {
            Texture2D rollDiceButton = content.Load<Texture2D>("diceButton");

            var diceGameButton = new Button(rollDiceButton)
            {
                position = new Vector2(240, 360)
            };

            return diceGameButton;
        }
        public static void ToPRSGameButton(object sender, EventArgs e)
        {
            State.game.ChangeState(new PlayerRollState(State.game, State.graphicsDevice, State.content));
        }

        public static Button CreateBuyButton(ContentManager content)
        {
            Texture2D buyButton = content.Load<Texture2D>("buyButton");

            var buyGameButton = new Button(buyButton)
            {
                position = new Vector2(150, 370)
            };

            return buyGameButton;
        }
        public static void ToBUYameButton(object sender, EventArgs e)
        {
            State.game.ChangeState(new PlayerBuyState(State.game, State.graphicsDevice, State.content));
        }
        public static void ToETSGameButton(object sender, EventArgs e)
        {
            State.game.ChangeState(new EndTurnState(State.game, State.graphicsDevice, State.content));
        }

        public static Button CreateEndTurnButton(ContentManager content)
        {
            Texture2D endButton = content.Load<Texture2D>("nextTurnButton");

            var endTurnButton = new Button(endButton)
            {
                position = new Vector2(140, 420)
            };

            return endTurnButton;
        }


        public static Button CreateGameOver(ContentManager content)
        {
            Texture2D rollDiceButton = content.Load<Texture2D>("QuitButton");

            var diceGameButton = new Button(rollDiceButton)
            {
                position = new Vector2(220, 360)
            };

            return diceGameButton;
        }
        public static void ExitGameButton(object sender, EventArgs e)
        {
            Program.game.Exit();
        }

        public static Button CreateNewGame(ContentManager content)
        {
            Texture2D rollDiceButton = content.Load<Texture2D>("newGameButton");

            var diceGameButton = new Button(rollDiceButton)
            {
                position = new Vector2(220, 300)
            };

            return diceGameButton;
        }
        public static void ToISGameButton(object sender, EventArgs e)
        {
            State.game.ChangeState(new InitialState(State.game, State.graphicsDevice, State.content));
        }


        public static Player CreatePlayer(ContentManager content, int index)
        {
            Texture2D texture = content.Load<Texture2D>("player" + index.ToString());
            Rectangle playerRectangle = new Rectangle(12 + index * 30, 550, 28, 28);
            Sprite sprite = new Sprite(playerRectangle, texture);
            Player player = new Player(sprite, index);
            return player;
        }

        public static Rectangle[] CreateTileColliders()
        {
            Rectangle[] tileColliders = new Rectangle[20];

            tileColliders[0] = new Rectangle(0, 480, 120, 120);
            tileColliders[1] = new Rectangle(0, 360, 120, 100);
            tileColliders[2] = new Rectangle(0, 270, 120, 100);
            tileColliders[3] = new Rectangle(0, 180, 120, 100);
            tileColliders[4] = new Rectangle(0, 90, 120, 100);
            tileColliders[5] = new Rectangle(0, -30, 120, 120);
            tileColliders[6] = new Rectangle(150, 0, 100, 120);
            tileColliders[7] = new Rectangle(240, 0, 100, 120);
            tileColliders[8] = new Rectangle(330, 0, 100, 120);
            tileColliders[9] = new Rectangle(420, 0, 100, 120);
            tileColliders[10] = new Rectangle(510, 0, 120, 120);
            tileColliders[11] = new Rectangle(480, 150, 120, 100);
            tileColliders[12] = new Rectangle(480, 240, 120, 100);
            tileColliders[13] = new Rectangle(480, 330, 120, 100);
            tileColliders[14] = new Rectangle(480, 420, 120, 100);
            tileColliders[15] = new Rectangle(450, 480, 120, 120);
            tileColliders[16] = new Rectangle(360, 480, 100, 120);
            tileColliders[17] = new Rectangle(270, 480, 100, 120);
            tileColliders[18] = new Rectangle(180, 480, 100, 120);
            tileColliders[19] = new Rectangle(90, 480, 100, 120);

            return tileColliders;
        }
    }
}
