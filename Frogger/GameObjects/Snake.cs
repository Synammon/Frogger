using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.GameObjects
{
    public class Snake : DrawableGameComponent
    {
        private Texture2D _leftTexture;
        private Texture2D _rightTexture;
        private Vector2 _position;
        private float _speed = 64f;
        private Direction _direction;
        private SpriteBatch _spriteBatch;
        private Point _size = new Point(128, 64);

        public Point Size { get { return _size; } set { _size = value; } }
        public Vector2 Position { get { return _position; } set { _position = value; } }
        public Direction Direction => _direction;
        public Rectangle BoundingBox => new Rectangle((int)_position.X, (int)_position.Y, _size.X, _size.Y);
        public float Speed { get { return _speed; } set { _speed = value; } }

        public Snake(Game game, Texture2D leftTexture, Texture2D rightTexture, Vector2 position, Direction direction, Point size, SpriteBatch spriteBatch) : base(game)
        {
            _leftTexture = leftTexture;
            _rightTexture = rightTexture;
            _position = position;
            _spriteBatch = spriteBatch;
            _direction = direction;
            _size = size;
        }

        public override void Update(GameTime gameTime)
        {
            if (Direction == Direction.Left)
            {
                _position.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (Direction == Direction.Right)
            {
                _position.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (_position.X <= 0 && Direction == Direction.Left)
            {
                _direction = Direction.Right;
            }
            if (_position.X + Size.X > Game1.SCREEN_WIDTH && Direction == Direction.Right)
            {
                _direction = Direction.Left;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (_direction == Direction.Left)
                _spriteBatch.Draw(_leftTexture, new Rectangle((int)_position.X, (int)_position.Y, _size.X, _size.Y), null, Color.White); 
            else
                _spriteBatch.Draw(_rightTexture, new Rectangle((int)_position.X + _size.X, (int)_position.Y, _size.X, _size.Y), null, Color.White);

        }
    }
}
