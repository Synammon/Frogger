using Frogger.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class CarDef
    {
        public int TextureId { get; set; }
        public Vector2 Position { get; set; } = new();
        public Direction Direction { get; set; }
        public int Speed { get; set; }
        public Point Size { get; set; } = new();
    }
}
