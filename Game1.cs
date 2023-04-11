using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace C1gameProject
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public double Elapsed;

        private Texture2D monopolyBoard;

        public List<Player> players;
        public Player player1;
        public Player player2;

        private int velocity;
        private Rectangle TileDestination;
        public bool shouldPlayerMove;

        public Rectangle[] TileColliders;
        public SpriteFont font;

        public string text;
        public string player1Money;
        public string player2Money;

        private State currentState;
        private State nextState;
        public void ChangeState(State state)
        {
            nextState = state;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
        }

        protected override void Initialize()
        {
            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Font");
            monopolyBoard = Content.Load<Texture2D>("monopolyBoard");

            player1 = Initializer.CreatePlayer(Content, 1);
            player2 = Initializer.CreatePlayer(Content, 2);

            players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            TileColliders = Initializer.CreateTileColliders();
            velocity = 400;
            shouldPlayerMove = false;

            text = "Let's start the game.";
            player1Money = "2000$";
            player2Money = "2000$";

            currentState = new InitialState(this, graphics.GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Elapsed = (double)gameTime.ElapsedGameTime.TotalSeconds;
            if (nextState != null)
            {
                currentState = nextState;
                nextState = null;
            }

            currentState.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(monopolyBoard, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, new Vector2(300, 130), Color.Black);
            spriteBatch.DrawString(font, player1Money, new Vector2(220, 132), Color.Black);
            spriteBatch.DrawString(font, player2Money, new Vector2(220, 158), Color.Black);
            foreach (var _players in players)
                _players.Draw(spriteBatch);
            currentState.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }


        public void MovePlayer(int playerIndex, int currentPosition, int newPosition)
        {
            Player currentPlayer = players[playerIndex];
            TileDestination = TileColliders[newPosition];
            if (TileDestination.Contains(currentPlayer.sprite.rectangle))
            {
                shouldPlayerMove = false;
            }
            else
            {
                if (currentPlayer.sprite.rectangle.X < 40 && currentPlayer.sprite.rectangle.Y > 25)
                {
                    currentPlayer.sprite.rectangle.Y -= (int)(velocity * Program.game.Elapsed);
                }
                else if (currentPlayer.sprite.rectangle.Y <= 40 && currentPlayer.sprite.rectangle.X < 530)
                {
                    currentPlayer.sprite.rectangle.X += (int)(velocity * Program.game.Elapsed);
                }
                else if (currentPlayer.sprite.rectangle.X >= 400 && currentPlayer.sprite.rectangle.Y < 560)
                {
                    currentPlayer.sprite.rectangle.Y += (int)(velocity * Program.game.Elapsed);
                }
                else if (currentPlayer.sprite.rectangle.Y >= 479 && currentPlayer.sprite.rectangle.X >= 20)
                {
                    currentPlayer.sprite.rectangle.X -= (int)(velocity * Program.game.Elapsed);
                }
            }

            JsonSerializerOptions option = new JsonSerializerOptions() { WriteIndented = true };
            string playerAsJson = JsonSerializer.Serialize(currentPlayer, option);
            //string fileName = @"C:\Users\HP\Desktop\game.json";
            File.WriteAllText(fileName, playerAsJson);
        }
    }
}