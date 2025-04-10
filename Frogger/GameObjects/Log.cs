using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.GameObjects
{
    public class Log : DrawableGameComponent
    {
        private List<Texture2D> _textures;
        private Vector2 _position;
        private float _speed = 256f;
        private SpriteBatch _spriteBatch;
        private int _midSections;

        public int Size
        {
            get { return (_midSections + 1) * Field.TileSize; }
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)_position.X - ((_midSections + 1)* Field.TileSize), (int)_position.Y, (int)_textures[0].Width + (_midSections + 1) * Field.TileSize, Field.TileSize - 10);
            }
        }

        public Log(Game game, List<Texture2D> texture, Vector2 pos, int midSections, SpriteBatch sb)
            : base(game)
        {
            _textures = texture;
            _position = pos;
            _midSections = midSections;
            _spriteBatch = sb;
        }

        public override void Update(GameTime gameTime)
        {
            _position.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_position.X - Size > Game1.SCREEN_WIDTH)
            {
                _position.X = 0 - Field.TileSize;
            }
        }

        public override void Draw(GameTime gameTime)
        {

            _spriteBatch.Draw(_textures[0], new Rectangle((int)Position.X, (int)Position.Y, Field.TileSize, Field.TileSize - 10), Color.White);

            for (int i = 1; i <= _midSections; i++)
            {
                _spriteBatch.Draw(_textures[1], new Rectangle((int)_position.X - i * Field.TileSize, (int)_position.Y, Field.TileSize, Field.TileSize - 10), Color.White);
            }

            _spriteBatch.Draw(_textures[2], new Rectangle((int)_position.X - (_midSections + 1) * 64, (int)_position.Y, Field.TileSize, Field.TileSize - 10), Color.White);
        }
    }
}
