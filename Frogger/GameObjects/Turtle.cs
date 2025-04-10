using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.GameObjects
{
    public enum TurtleState
    {
        Floating,
        Diving,
        Swimming,
        Rising
    }   
    public class Turtle : DrawableGameComponent
    {
        private List<Texture2D> _textures;
        private Vector2 _position;
        private float _speed = 48f;
        private SpriteBatch _spriteBatch;
        private bool _isDiver;

        public TurtleState TurtleState { get; set; }
        public TimeSpan DiveTime { get; set; }
        
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, Field.TileSize, Field.TileSize);
            }
        }

        public Turtle(Game game, List<Texture2D> textures, Vector2 pos, SpriteBatch sb, bool isDiver)
            : base(game)
        {
            _textures = textures;
            _position = pos;
            _spriteBatch = sb;
            TurtleState = TurtleState.Floating;
            _isDiver = isDiver;

            if (isDiver)
            {
                DiveTime = TimeSpan.FromSeconds(2);
                TurtleState = TurtleState.Diving;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (_isDiver)
            { 
                if (TurtleState == TurtleState.Floating)
                {
                    DiveTime -= gameTime.ElapsedGameTime;

                    if (DiveTime <= TimeSpan.Zero)
                    {
                        TurtleState = TurtleState.Diving;
                        DiveTime = TimeSpan.FromSeconds(1);
                    }
                }
                else if (TurtleState == TurtleState.Diving)
                {
                    DiveTime -= gameTime.ElapsedGameTime;
                    if (DiveTime <= TimeSpan.Zero)
                    {
                        TurtleState = TurtleState.Swimming;
                        DiveTime = TimeSpan.FromSeconds(1);
                    }
                }
                else if (TurtleState == TurtleState.Swimming)
                {
                    DiveTime -= gameTime.ElapsedGameTime;
                    if (DiveTime <= TimeSpan.Zero)
                    {
                        TurtleState = TurtleState.Rising;
                        DiveTime = TimeSpan.FromSeconds(1);
                    }
                }
                else if (TurtleState == TurtleState.Rising)
                {
                    DiveTime -= gameTime.ElapsedGameTime;
                    if (DiveTime <= TimeSpan.Zero)
                    {
                        TurtleState = TurtleState.Floating;
                        DiveTime = TimeSpan.FromSeconds(2);
                    }
                }
            }

            _position.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_position.X + Field.TileSize < 0)
            {
                _position.X = Game1.SCREEN_WIDTH;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (TurtleState == TurtleState.Floating)
            {
                _spriteBatch.Draw(_textures[0], new Rectangle((int)_position.X, (int)_position.Y, Field.TileSize, Field.TileSize), Color.White);
            }
            else if (TurtleState == TurtleState.Diving)
            {
                _spriteBatch.Draw(_textures[1], new Rectangle((int)_position.X, (int)_position.Y, Field.TileSize, Field.TileSize), Color.White);
            }
            else if (TurtleState == TurtleState.Rising)
            {
                _spriteBatch.Draw(_textures[1], new Rectangle((int)_position.X, (int)_position.Y, Field.TileSize, Field.TileSize), Color.White);
            }
        }
    }
}
