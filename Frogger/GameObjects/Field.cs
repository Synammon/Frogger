using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.GameObjects
{
    public class Field
    {
        public const int TileSize = 64;
        private Texture2D _grass;
        private Texture2D _water;
        private Texture2D _homes;
        private Texture2D _frogHome;
        private List<Car> _cars;
        private List<Log> _logs;
        private List<Turtle> _turtles;
        private List<Texture2D> _carTextures;
        private List<Texture2D> _logTextures;
        private List<Texture2D> _turtleTextures;
        private SpriteBatch _spriteBatch;
        private List<Rectangle> _homeAreas;
        private List<bool> _homeOccupied = new List<bool> { false, false, false, false, false };

        private TimeSpan FieldTimer;

        public Rectangle WaterArea
        {
            get
            {
                return new Rectangle(0, 2 * TileSize, Game1.SCREEN_WIDTH, 5 * TileSize);
            }
        }

        public Field(Game game, Texture2D grass, Texture2D water, Texture2D homes, Texture2D frogHome, List<Texture2D> carTextures, List<Texture2D> logTextures, List<Texture2D> turtleTextures,SpriteBatch spriteBatch)
        {
            _grass = grass;
            _water = water;
            _homes = homes;
            _cars = new List<Car>();
            _logs = new List<Log>();
            _turtles = new List<Turtle>();
            _homeAreas = new List<Rectangle>();
            _frogHome = frogHome;
            _spriteBatch = spriteBatch;
            _carTextures = carTextures;
            _logTextures = logTextures;
            _turtleTextures = turtleTextures;
        }

        public void Initialize(Game game)
        {
            FieldTimer = TimeSpan.FromSeconds(60f);

            _homeAreas.Clear();
            _homeAreas.Add(new Rectangle(TileSize, TileSize, TileSize, TileSize));
            _homeAreas.Add(new Rectangle(4 * TileSize, TileSize, TileSize, TileSize));
            _homeAreas.Add(new Rectangle(7 * TileSize, TileSize, TileSize, TileSize));
            _homeAreas.Add(new Rectangle(10 * TileSize, TileSize, TileSize, TileSize));
            _homeAreas.Add(new Rectangle(13 * TileSize, TileSize, TileSize, TileSize));

            for (int i = 0; i < _homeOccupied.Count; i++)
            {
                _homeOccupied[i] = false;
            }

            _cars.Clear();
            _cars.Add(new Car(game, _carTextures[0], new Vector2(Game1.SCREEN_WIDTH - TileSize, 12 * TileSize), Direction.Left, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[1], new Vector2(0, 11 * TileSize), Direction.Right, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[2], new Vector2(Game1.SCREEN_WIDTH - TileSize, 10 * TileSize), Direction.Left, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[3], new Vector2(0, 9 * TileSize), Direction.Right, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[4], new Vector2(Game1.SCREEN_WIDTH - TileSize * 3, 8 * TileSize), Direction.Left, new Point(TileSize * 3, TileSize), _spriteBatch));

            _cars.Add(new Car(game, _carTextures[0], new Vector2(Game1.SCREEN_WIDTH - TileSize * 3, 12 * TileSize), Direction.Left, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[1], new Vector2(0 + TileSize * 4, 11 * TileSize), Direction.Right, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[2], new Vector2(Game1.SCREEN_WIDTH - TileSize * 3, 10 * TileSize), Direction.Left, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[3], new Vector2(0 + TileSize * 10, 9 * TileSize), Direction.Right, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[4], new Vector2(Game1.SCREEN_WIDTH - TileSize * 3 * 3, 8 * TileSize), Direction.Left, new Point(TileSize * 3, TileSize), _spriteBatch));

            _cars.Add(new Car(game, _carTextures[0], new Vector2(Game1.SCREEN_WIDTH - TileSize * 2 * 4, 12 * TileSize), Direction.Left, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[1], new Vector2(0 + TileSize * 9, 11 * TileSize), Direction.Right, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[2], new Vector2(Game1.SCREEN_WIDTH - TileSize * 7, 10 * TileSize), Direction.Left, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[3], new Vector2(0 + TileSize * 5, 9 * TileSize), Direction.Right, new Point(TileSize, TileSize), _spriteBatch));
            _cars.Add(new Car(game, _carTextures[4], new Vector2(Game1.SCREEN_WIDTH - TileSize * 3 * 2, 8 * TileSize), Direction.Left, new Point(TileSize * 3, TileSize), _spriteBatch));

            _logs.Clear();
            _logs.Add(new Log(game, _logTextures, new Vector2(0, 2 * TileSize), 1, _spriteBatch));
            _logs[0].Speed = 128f;
            _logs.Add(new Log(game, _logTextures, new Vector2(TileSize * 5, 2 * TileSize), 1, _spriteBatch));
            _logs[1].Speed = 128f;
            _logs.Add(new Log(game, _logTextures, new Vector2(TileSize * 10, 2 * TileSize), 1, _spriteBatch));
            _logs[2].Speed = 128f;

            _logs.Add(new Log(game, _logTextures, new Vector2(0, 4 * TileSize), 4, _spriteBatch));
            _logs[3].Speed = 160f;
            _logs.Add(new Log(game, _logTextures, new Vector2(TileSize * 9, 4 * TileSize), 4, _spriteBatch));
            _logs[4].Speed = 160f;

            _logs.Add(new Log(game, _logTextures, new Vector2(0, 5 * TileSize), 2, _spriteBatch));
            _logs[5].Speed = 96f;
            _logs.Add(new Log(game, _logTextures, new Vector2(TileSize * 6, 5 * TileSize), 2, _spriteBatch));
            _logs[6].Speed = 96f;
            _logs.Add(new Log(game, _logTextures, new Vector2(TileSize * 12, 5 * TileSize), 2, _spriteBatch));
            _logs[7].Speed = 96f;

            _turtles.Clear();
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(2 * TileSize, 6 * TileSize), _spriteBatch, true));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(3 * TileSize, 6 * TileSize), _spriteBatch, true));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(4 * TileSize, 6 * TileSize), _spriteBatch, true));

            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(6 * TileSize, 6 * TileSize), _spriteBatch, false));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(7 * TileSize, 6 * TileSize), _spriteBatch, false));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(8 * TileSize, 6 * TileSize), _spriteBatch, false));

            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(10 * TileSize, 6 * TileSize), _spriteBatch, true));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(11 * TileSize, 6 * TileSize), _spriteBatch, true));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(12 * TileSize, 6 * TileSize), _spriteBatch, true));

            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(14 * TileSize, 6 * TileSize), _spriteBatch, false));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(15 * TileSize, 6 * TileSize), _spriteBatch, false));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(16 * TileSize, 6 * TileSize), _spriteBatch, false));

            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(3 * TileSize, 3 * TileSize), _spriteBatch, false));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(4 * TileSize, 3 * TileSize), _spriteBatch, false));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(5 * TileSize, 3 * TileSize), _spriteBatch, false));

            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(8 * TileSize, 3 * TileSize), _spriteBatch, true));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(9 * TileSize, 3 * TileSize), _spriteBatch, true));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(10 * TileSize, 3 * TileSize), _spriteBatch, true));

            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(13 * TileSize, 3 * TileSize), _spriteBatch, false));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(14 * TileSize, 3 * TileSize), _spriteBatch, false));
            _turtles.Add(new Turtle(game, _turtleTextures, new Vector2(15 * TileSize, 3 * TileSize), _spriteBatch, false));
        }

        public void Update(GameTime gameTime)
        {
            FieldTimer -= gameTime.ElapsedGameTime;

            if (FieldTimer.TotalSeconds <= 0)
            {
                Game1.Frog.Reset();
                FieldTimer = TimeSpan.FromSeconds(60f);
                Game1.Lives--;
            }

            for (int i = 0; i < _homeAreas.Count; i++)
            {
                if (_homeAreas[i].Intersects(Frog.BoundingBox) && !_homeOccupied[i])
                {
                    Game1.Frog.Reset();
                    Game1.Score += 100;

                    for (int j = 0; j < (int)FieldTimer.TotalSeconds; j++)
                    {
                        Game1.Score += 20;
                    }

                    _homeOccupied[i] = true;
                    FieldTimer = TimeSpan.FromSeconds(60f);
                }
                else if (_homeAreas[i].Intersects(Frog.BoundingBox) && _homeOccupied[i])
                {
                    Game1.Frog.Reset();
                    Game1.Lives--;
                    FieldTimer = TimeSpan.FromSeconds(60f);
                }
            }

            foreach (var car in _cars)
            {
                car.Update(gameTime);

                if (car.Direction == Direction.Left)
                {
                    if (car.Position.X < car.Size.X * -1)
                    {
                        car.Position = new Vector2(Game1.SCREEN_WIDTH, car.Position.Y);
                    }
                }
                else if (car.Direction == Direction.Right)
                {
                    if (car.Position.X > Game1.SCREEN_WIDTH)
                    {
                        car.Position = new Vector2(car.Size.X * -1, car.Position.Y);
                    }
                }

                if (car.BoundingBox.Intersects(Frog.BoundingBox))
                {
                    Game1.Frog.Reset();
                    Game1.Lives--;
                    FieldTimer = TimeSpan.FromSeconds(60f);
                }
            }

            foreach (var log in _logs)
            {
                log.Update(gameTime);
            }

            foreach (var turtle in _turtles)
            {
                turtle.Update(gameTime);
            }

            if (Frog.BoundingBox.Intersects(WaterArea))// && !Frog.Moving)
            {
                bool onLog = false;
                foreach (var log in _logs)
                {
                    if (log.BoundingBox.Intersects(Frog.BoundingBox))
                    {
                        onLog = true;
                        Frog.Position = new Vector2(Frog.Position.X + log.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds, Frog.Position.Y);
                        break;
                    }
                }
                if (!onLog)
                {
                    foreach (var turtle in _turtles)
                    {
                        if (turtle.BoundingBox.Intersects(Frog.BoundingBox) && turtle.TurtleState == TurtleState.Floating)
                        {
                            onLog = true;
                            Frog.Position = new Vector2(Frog.Position.X - turtle.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds, Frog.Position.Y);
                            break;
                        }
                    }
                }
                if (!onLog)
                {
                    Game1.Frog.Reset();
                    FieldTimer = TimeSpan.FromSeconds(60f);
                    Game1.Lives--;
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            for (int i = 0; i < 16; i++)
            {
                _spriteBatch.Draw(_grass, new Rectangle(i * TileSize, 13 * TileSize, TileSize, TileSize), Color.White);
                _spriteBatch.Draw(_grass, new Rectangle(i * TileSize, 7 * TileSize, TileSize, TileSize), Color.White);

                for (int j = 1; j < 7; j++)
                {
                    _spriteBatch.Draw(_water, new Rectangle(i * TileSize, j * TileSize, TileSize, TileSize), Color.White);
                }
            }

            _spriteBatch.Draw(_homes, new Rectangle(0, TileSize, Game1.SCREEN_WIDTH, TileSize), Color.White);
            foreach (var car in _cars)
            {
                car.Draw(gameTime);
            }

            foreach (var log in _logs)
            {
                log.Draw(gameTime);
            }

            foreach (var turtle in _turtles)
            {
                turtle.Draw(gameTime);
            }

            for (int i = 0; i < _homeOccupied.Count; i++)
            {
                if (_homeOccupied[i])
                {
                    _spriteBatch.Draw(_frogHome, _homeAreas[i], Color.White);
                }
            }
        }
    }
}
