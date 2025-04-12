using Frogger.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class LogDef
    {
        public Vector2 Position { get; set; } = new();
        public Direction Direction { get; set; }
        public int Speed { get; set; }
        public int MidSections { get; set; }
    }
}
