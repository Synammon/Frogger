using Frogger.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Frogger
{
    public class Game1 : Game
    {
        public const int SCREEN_WIDTH = 960;
        public const int SCREEN_HEIGHT = 960;
        public static int Score { get; set; } = 0;
        public static int Lives { get; set; } = 0;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Frog Frog { get; private set; }
        public static Field Field { get; private set; }
        public static SpriteFont GameFont { get; private set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            _graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;

            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Components.Add(new Xin(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Frog = new Frog(this, Content.Load<Texture2D>("frog"), new Vector2(SCREEN_WIDTH / 2 - 32, SCREEN_HEIGHT - 128), _spriteBatch);
            List<Texture2D> cars = new List<Texture2D>()
            {
                Content.Load<Texture2D>("car1"),
                Content.Load<Texture2D>("car2"),
                Content.Load<Texture2D>("car3"),
                Content.Load<Texture2D>("car4"),
                Content.Load<Texture2D>("car5"),
            };

            List<Texture2D> logs = new List<Texture2D>()
            {
                Content.Load<Texture2D>("Log1"),
                Content.Load<Texture2D>("Log2"),
                Content.Load<Texture2D>("Log3"),
            };

            List<Texture2D> turtles = new List<Texture2D>()
            {
                Content.Load<Texture2D>("Turtle1"),
                Content.Load<Texture2D>("Turtle2"),
            };

            Field = new Field(this, Content.Load<Texture2D>("grass"), Content.Load<Texture2D>("water"), Content.Load<Texture2D>("homes"), Content.Load<Texture2D>("FrogHome"), cars, logs, turtles, _spriteBatch);
            Field.Initialize(this);

            GameFont = Content.Load<SpriteFont>("GameFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (Lives == 0)
            {
                if (Xin.CheckKeyPressed(Keys.R))
                {
                    Lives = 3;
                    Score = 0;
                    Frog.Reset();
                    Field.Initialize(this);
                }
            }
            else
            {
                Field.Update(gameTime);
                Frog.Update(gameTime);
            }

            Window.Title = "Frogger - Score: " + Score + " Lives: " + Lives;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            base.Draw(gameTime);

            if (Lives > 0)
            {
                Field.Draw(gameTime);
                Frog.Draw(gameTime);
            }
            else
            {
                // Draw game over screen
                _spriteBatch.DrawString(GameFont, "Game Over", new Vector2(SCREEN_WIDTH / 2 - 50, SCREEN_HEIGHT / 2 - 20), Color.White);
                _spriteBatch.DrawString(GameFont, "Press R to Restart", new Vector2(SCREEN_WIDTH / 2 - 80, SCREEN_HEIGHT / 2 + 20), Color.White);
            }

            _spriteBatch.End();
        }
    }
}
