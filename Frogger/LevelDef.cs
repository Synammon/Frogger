using Frogger.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class LevelDef
    {
        public IList<CarDef> RowOne { get; set; }
        public IList<CarDef> RowTwo { get; set; }
        public IList<CarDef> RowThree { get; set; }
        public IList<CarDef> RowFour { get; set; }
        public IList<CarDef> RowFive { get; set; }
        public IList<SnakeDef> RowSix { get; set; }
        public IList<TurtleDef> RowSeven { get; set; }
        public IList<LogDef> RowEight { get; set; }
        public IList<LogDef> RowNine { get; set; }
        public IList<TurtleDef> RowTen { get; set; }
        public IList<LogDef> RowEleven { get; set; }

        public LevelDef()
        {
            RowOne = new List<CarDef>();
            RowTwo = new List<CarDef>();
            RowThree = new List<CarDef>();
            RowFour = new List<CarDef>();
            RowFive = new List<CarDef>();
            RowSix = new List<SnakeDef>();
            RowSeven = new List<TurtleDef>();
            RowEight = new List<LogDef>();
            RowNine = new List<LogDef>();
            RowTen = new List<TurtleDef>();
            RowEleven = new List<LogDef>();
        }
    }
}
