using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.GameObjects
{
    public class Car : DrawableGameComponent
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed = 128f;
        private Direction _direction;
        private SpriteBatch _spriteBatch;
        private Point _size = new Point(64, 64);

        public Point Size { get { return _size; } set { _size = value; } }
        public Vector2 Position { get { return _position; } set { _position = value; } }
        public Direction Direction => _direction;
        public Rectangle BoundingBox => new Rectangle((int)_position.X, (int)_position.Y, _size.X, _size.Y);
        public float Speed { get { return _speed; } set { _speed = value; } }

        public Car(Game game, Texture2D texture, Vector2 position, Direction direction, Point size, int Speed, SpriteBatch spriteBatch) : base(game)
        {
            _texture = texture;
            _position = position;
            _spriteBatch = spriteBatch;
            _direction = direction;
            _size = size;
            _speed = Speed;
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
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, _size.X, _size.Y), Color.White);
        }
    }
}
