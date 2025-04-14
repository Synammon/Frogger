using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        private Texture2D _snakeLeftTexture;
        private Texture2D _snakeRightTexture;
        private List<Car> _cars;
        private List<Log> _logs;
        private List<Turtle> _turtles;
        private List<Snake> _snakes;
        private List<Texture2D> _carTextures;
        private List<Texture2D> _logTextures;
        private List<Texture2D> _turtleTextures;
        private SpriteBatch _spriteBatch;
        private List<Rectangle> _homeAreas;
        private List<bool> _homeOccupied = new List<bool> { false, false, false, false, false };
        private Levels _levels = new();
        private int _currentLevel;
        private TimeSpan FieldTimer;
        private TimeSpan _nextTimer;
        private bool _frogReset = false;
        private Game _game;

        public bool FrogReset
        {
            get { return _frogReset; }
            set { _frogReset = value; }
        }

        public Rectangle WaterArea
        {
            get
            {
                return new Rectangle(0, 2 * TileSize, Game1.SCREEN_WIDTH, 5 * TileSize);
            }
        }

        public Field(Game game, Texture2D grass, Texture2D water, Texture2D homes, Texture2D frogHome, List<Texture2D> carTextures, List<Texture2D> logTextures, List<Texture2D> turtleTextures, Texture2D snakeLeftTexture, Texture2D snakeRightTexture, SpriteBatch spriteBatch)
        {
            _game = game;
            _grass = grass;
            _water = water;
            _homes = homes;
            _snakeLeftTexture = snakeLeftTexture;
            _snakeRightTexture = snakeRightTexture;
            _cars = new List<Car>();
            _logs = new List<Log>();
            _turtles = new List<Turtle>();
            _snakes = new List<Snake>();
            _homeAreas = new List<Rectangle>();
            _frogHome = frogHome;
            _spriteBatch = spriteBatch;
            _carTextures = carTextures;
            _logTextures = logTextures;
            _turtleTextures = turtleTextures;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                IncludeFields = true
            };

            string json = JsonSerializer.Serialize(_levels, options);
            string fileName = "..\\..\\..\\Content\\Levels.json";
            File.WriteAllText(fileName, json);

            fileName = "Content\\Levels.json";
            json = File.ReadAllText(fileName);
            _levels = JsonSerializer.Deserialize<Levels>(json, options);
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

            GenerateLevel();            
        }

        public void GenerateLevel()
        {
            _cars.Clear();

            foreach (CarDef car in _levels.LevelDefs[_currentLevel].RowOne)
            {
                _cars.Add(new Car(_game, _carTextures[car.TextureId], new Vector2(car.Position.X, car.Position.Y), car.Direction, car.Size, car.Speed, _spriteBatch));
            }

            foreach (CarDef car in _levels.LevelDefs[_currentLevel].RowTwo)
            {
                _cars.Add(new Car(_game, _carTextures[car.TextureId], new Vector2(car.Position.X, car.Position.Y), car.Direction, car.Size, car.Speed, _spriteBatch));
            }

            foreach (CarDef car in _levels.LevelDefs[_currentLevel].RowThree)
            {
                _cars.Add(new Car(_game, _carTextures[car.TextureId], new Vector2(car.Position.X, car.Position.Y), car.Direction, car.Size, car.Speed, _spriteBatch));
            }

            foreach (CarDef car in _levels.LevelDefs[_currentLevel].RowFour)
            {
                _cars.Add(new Car(_game, _carTextures[car.TextureId], new Vector2(car.Position.X, car.Position.Y), car.Direction, car.Size, car.Speed, _spriteBatch));
            }

            foreach (CarDef car in _levels.LevelDefs[_currentLevel].RowFive)
            {
                _cars.Add(new Car(_game, _carTextures[car.TextureId], new Vector2(car.Position.X, car.Position.Y), car.Direction, car.Size, car.Speed, _spriteBatch));
            }

            _logs.Clear();

            foreach (LogDef log in _levels.LevelDefs[_currentLevel].RowEight)
            {
                _logs.Add(new Log(_game, _logTextures, new Vector2(log.Position.X, log.Position.Y), log.MidSections, log.Speed, _spriteBatch));
            }

            foreach (LogDef log in _levels.LevelDefs[_currentLevel].RowNine)
            {
                _logs.Add(new Log(_game, _logTextures, new Vector2(log.Position.X, log.Position.Y), log.MidSections, log.Speed, _spriteBatch));
            }

            foreach (LogDef log in _levels.LevelDefs[_currentLevel].RowEleven)
            {
                _logs.Add(new Log(_game, _logTextures, new Vector2(log.Position.X, log.Position.Y), log.MidSections, log.Speed, _spriteBatch));
            }

            _turtles.Clear();

            foreach (TurtleDef turtle in _levels.LevelDefs[_currentLevel].RowSeven)
            {
                _turtles.Add(new Turtle(_game, _turtleTextures, new Vector2(turtle.Position.X, turtle.Position.Y), _spriteBatch, turtle.IsDiver));
            }

            foreach (TurtleDef turtle in _levels.LevelDefs[_currentLevel].RowTen)
            {
                _turtles.Add(new Turtle(_game, _turtleTextures, new Vector2(turtle.Position.X, turtle.Position.Y), _spriteBatch, turtle.IsDiver));
            }

            _snakes.Clear();

            foreach (SnakeDef snake in _levels.LevelDefs[_currentLevel].RowSix)
            {
                _snakes.Add(new Snake(_game, _snakeLeftTexture, _snakeRightTexture, snake.Position, snake.Direction, snake.Size, _spriteBatch));
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!_frogReset)
            {
                FieldTimer -= gameTime.ElapsedGameTime;
            }

            _nextTimer -= gameTime.ElapsedGameTime;

            if (_nextTimer.TotalSeconds <= 0 && _frogReset)
            {
                _nextTimer = TimeSpan.FromSeconds(4f);
                Game1.Frog.Reset();
                _frogReset = false;
            }

            if (FieldTimer.TotalSeconds <= 0)
            {
                _frogReset = true;
                _nextTimer = TimeSpan.FromSeconds(4f);
                FieldTimer = TimeSpan.FromSeconds(60f);
                Game1.Lives--;
            }

            for (int i = 0; i < _homeAreas.Count; i++)
            {
                if (_homeAreas[i].Intersects(Frog.BoundingBox) && !_homeOccupied[i] && !_frogReset)
                {
                    _frogReset = true;
                    _nextTimer = TimeSpan.FromSeconds(4f);
                    Game1.Score += 100;

                    for (int j = 0; j < (int)FieldTimer.TotalSeconds; j++)
                    {
                        Game1.Score += 10;
                    }

                    _homeOccupied[i] = true;
                    FieldTimer = TimeSpan.FromSeconds(60f);
                }
                else if (_homeAreas[i].Intersects(Frog.BoundingBox) && _homeOccupied[i] && !_frogReset)
                {
                    _frogReset = true;
                    _nextTimer = TimeSpan.FromSeconds(4f);
                    Game1.Lives--;
                    FieldTimer = TimeSpan.FromSeconds(60f);
                }
            }

            if (!_homeOccupied.Contains(false) && !_frogReset)
            {
                _currentLevel++;
                _frogReset = true;
                _nextTimer = TimeSpan.FromSeconds(4f);
                FieldTimer = TimeSpan.FromSeconds(60f);
                if (_currentLevel >= _levels.LevelDefs.Count)
                {
                    _currentLevel = 0;
                }
                GenerateLevel();
                _homeOccupied.Clear();
                for (int i = 0; i < 5; i++)
                {
                    _homeOccupied.Add(false);
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

                if (car.BoundingBox.Intersects(Frog.BoundingBox) && !_frogReset)
                {
                    _frogReset = true;
                    _nextTimer = TimeSpan.FromSeconds(4f);
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

            foreach (var snake in _snakes)
            {
                snake.Update(gameTime);
                if (snake.BoundingBox.Intersects(Frog.BoundingBox) && !_frogReset)
                {
                    _frogReset = true;
                    _nextTimer = TimeSpan.FromSeconds(4f);
                    Game1.Lives--;
                    FieldTimer = TimeSpan.FromSeconds(60f);
                }
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
                if (!onLog && !_frogReset)
                {
                    _frogReset = true;
                    _nextTimer = TimeSpan.FromSeconds(4f);
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

            foreach (var snake in _snakes)
            {
                snake.Draw(gameTime);
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
