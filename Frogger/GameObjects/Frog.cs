using Microsoft.Xna.Framework;  
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.GameObjects
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Frog : DrawableGameComponent
    {
        public const int PixelsPerMove = 64;

        private Texture2D _texture;
        private static Vector2 _position;
        private float _speed = 256f;
        private SpriteBatch _spriteBatch;
        public Direction Direction { get; private set; }
        public static bool Moving { get; private set; }

        public static Rectangle BoundingBox { get { return new Rectangle((int)_position.X, (int)_position.Y, Field.TileSize, Field.TileSize); } }
        public static Vector2 Position { get { return _position; } set { _position = value; } }
        public static int PixelsMoved { get; set; }

        public Frog(Game game, Texture2D texture, Vector2 pos, SpriteBatch sb) 
            : base(game)
        {
            _texture = texture;
            _position = pos;
            _spriteBatch = sb;
        }

        public void Reset()
        {
            _position = new Vector2(Game1.SCREEN_WIDTH / 2 - 32, Game1.SCREEN_HEIGHT - 128);
            Moving = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (!Moving)
            {
                if (Xin.CheckKeyPressed(Keys.Up))
                {
                    Direction = Direction.Up;
                    Moving = true;
                    PixelsMoved = 0;
                }
                else if (Xin.CheckKeyPressed(Keys.Down))
                {
                    Direction = Direction.Down;
                    Moving = true;
                    PixelsMoved = 0;
                }
                else if (Xin.CheckKeyPressed(Keys.Left))
                {
                    Direction = Direction.Left;
                    Moving = true;
                    PixelsMoved = 0;
                }
                else if (Xin.CheckKeyPressed(Keys.Right))
                {
                    Direction = Direction.Right;
                    Moving = true;
                    PixelsMoved = 0;    
                }
            }
            else
            {
                switch (Direction)
                {
                    case Direction.Up:
                        _position.Y -= (int)(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                        PixelsMoved += (int)(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                        break;
                    case Direction.Down:
                        _position.Y += (int)(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                        PixelsMoved += (int)(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                        break;
                    case Direction.Left:
                        _position.X -= (int)(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                        PixelsMoved += (int)(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                        break;
                    case Direction.Right:
                        _position.X += (int)(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                        PixelsMoved += (int)(_speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
                        break;
                }

                if (PixelsMoved % 64 == 0)
                {
                    Moving = false;
                    PixelsMoved = 0;
                }
            }

            if (_position.X + Field.TileSize <= 0)
            {
                Reset();
                Game1.Lives--;                
            }
            else if (_position.X >= Game1.SCREEN_WIDTH)
            {
                Reset();
                Game1.Lives--;
            }
        }

        public override void Draw(GameTime gameTime)            
        {
            _spriteBatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, 64, 64), Color.White);
        }
    }
}
