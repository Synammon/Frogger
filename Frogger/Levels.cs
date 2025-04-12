using Frogger.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public class Levels
    {
        public List<LevelDef> LevelDefs { get; set; } = new List<LevelDef>();
        public Levels() 
        {
            LevelDef level = new LevelDef();

            level.RowOne.Add(new CarDef() { TextureId = 0, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 3, Field.TileSize * 12), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowOne.Add(new CarDef() { TextureId = 0, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 6, Field.TileSize * 12), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowTwo.Add(new CarDef() { TextureId = 1, Direction = Direction.Right, Position = new Vector2(Field.TileSize * 3, Field.TileSize * 11), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowTwo.Add(new CarDef() { TextureId = 1, Direction = Direction.Right, Position = new Vector2(Field.TileSize * 7, Field.TileSize * 11), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowThree.Add(new CarDef() { TextureId = 2, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 6, Field.TileSize * 10), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowThree.Add(new CarDef() { TextureId = 2, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 9, Field.TileSize * 10), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowThree.Add(new CarDef() { TextureId = 2, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 11, Field.TileSize * 10), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowFour.Add(new CarDef() { TextureId = 3, Direction = Direction.Right, Position = new Vector2(Field.TileSize * 4, Field.TileSize * 9), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowFive.Add(new CarDef() { TextureId = 4, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 5, Field.TileSize * 8), Size = new(Field.TileSize * 3, Field.TileSize), Speed = 128 });
            level.RowSix.Add(new SnakeDef() { Size = new Point(Field.TileSize * 2, Field.TileSize), Direction = Direction.Left, Position = new Vector2(Field.TileSize * 12, Field.TileSize * 7), Speed = 96 });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 2, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 3, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 5, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 6, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 7, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 9, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 10, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 11, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 13, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 14, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 15, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowEight.Add(new LogDef() { Direction = Direction.Right, Speed = 128, Position = new Vector2(2 * Field.TileSize, Field.TileSize * 5), MidSections = 1 });
            level.RowEight.Add(new LogDef() { Direction = Direction.Right, Speed = 128, Position = new Vector2(7 * Field.TileSize, Field.TileSize * 5), MidSections = 1 });
            level.RowEight.Add(new LogDef() { Direction = Direction.Right, Speed = 128, Position = new Vector2(12 * Field.TileSize, Field.TileSize * 5), MidSections = 1 });
            level.RowNine.Add(new LogDef() { Direction = Direction.Right, Speed = 192, Position = new Vector2(2 * Field.TileSize, Field.TileSize * 4), MidSections = 3 });
            level.RowNine.Add(new LogDef() { Direction = Direction.Right, Speed = 192, Position = new Vector2(9 * Field.TileSize, Field.TileSize * 4), MidSections = 3 });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 2, Field.TileSize * 3), Speed = 69, IsDiver = false });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 3, Field.TileSize * 3), Speed = 96, IsDiver = false });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 5, Field.TileSize * 3), Speed = 96, IsDiver = true });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 6, Field.TileSize * 3), Speed = 96, IsDiver = true });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 8, Field.TileSize * 3), Speed = 96, IsDiver = false });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 9, Field.TileSize * 3), Speed = 96, IsDiver = false });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 11, Field.TileSize * 3), Speed = 96, IsDiver = true });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 12, Field.TileSize * 3), Speed = 96, IsDiver = true });
            level.RowEleven.Add(new LogDef() { Direction = Direction.Right, Speed = 96, Position = new Vector2(2 * Field.TileSize, Field.TileSize * 2), MidSections = 2 });
            level.RowEleven.Add(new LogDef() { Direction = Direction.Right, Speed = 96, Position = new Vector2(8 * Field.TileSize, Field.TileSize * 2), MidSections = 2 });
            level.RowEleven.Add(new LogDef() { Direction = Direction.Right, Speed = 96, Position = new Vector2(13 * Field.TileSize, Field.TileSize * 2), MidSections = 2 });

            LevelDefs.Add(level);

            level = new LevelDef();

            level.RowOne.Add(new CarDef() { TextureId = 0, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 3, Field.TileSize * 12), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowOne.Add(new CarDef() { TextureId = 0, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 6, Field.TileSize * 12), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowTwo.Add(new CarDef() { TextureId = 1, Direction = Direction.Right, Position = new Vector2(Field.TileSize * 3, Field.TileSize * 11), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowTwo.Add(new CarDef() { TextureId = 1, Direction = Direction.Right, Position = new Vector2(Field.TileSize * 7, Field.TileSize * 11), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowThree.Add(new CarDef() { TextureId = 2, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 6, Field.TileSize * 10), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowThree.Add(new CarDef() { TextureId = 2, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 9, Field.TileSize * 10), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowThree.Add(new CarDef() { TextureId = 2, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 11, Field.TileSize * 10), Size = new(Field.TileSize, Field.TileSize), Speed = 128 });
            level.RowFour.Add(new CarDef() { TextureId = 3, Direction = Direction.Right, Position = new Vector2(Field.TileSize * 4, Field.TileSize * 9), Size = new(Field.TileSize, Field.TileSize), Speed = 160 });
            level.RowFive.Add(new CarDef() { TextureId = 4, Direction = Direction.Left, Position = new Vector2(Field.TileSize * 5, Field.TileSize * 8), Size = new(Field.TileSize * 3, Field.TileSize), Speed = 128 });
            level.RowSix.Add(new SnakeDef() { Size = new Point(Field.TileSize * 2, Field.TileSize), Direction = Direction.Left, Position = new Vector2(Field.TileSize * 12, Field.TileSize * 7), Speed = 96});
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 2, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 3, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 5, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 6, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 7, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 9, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 10, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 11, Field.TileSize * 6), Speed = 64, IsDiver = false });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 13, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 14, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowSeven.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 15, Field.TileSize * 6), Speed = 64, IsDiver = true });
            level.RowEight.Add(new LogDef() { Direction = Direction.Right, Speed = 64, Position = new Vector2(2 * Field.TileSize, Field.TileSize * 5), MidSections = 1 });
            level.RowEight.Add(new LogDef() { Direction = Direction.Right, Speed = 64, Position = new Vector2(7 * Field.TileSize, Field.TileSize * 5), MidSections = 1 });
            level.RowEight.Add(new LogDef() { Direction = Direction.Right, Speed = 64, Position = new Vector2(12 * Field.TileSize, Field.TileSize * 5), MidSections = 1 });
            level.RowNine.Add(new LogDef() { Direction = Direction.Right, Speed = 96, Position = new Vector2(2 * Field.TileSize, Field.TileSize * 4), MidSections = 3 });
            level.RowNine.Add(new LogDef() { Direction = Direction.Right, Speed = 96, Position = new Vector2(9 * Field.TileSize, Field.TileSize * 4), MidSections = 3 });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 2, Field.TileSize * 3), Speed = 64, IsDiver = false });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 3, Field.TileSize * 3), Speed = 64, IsDiver = false });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 5, Field.TileSize * 3), Speed = 64, IsDiver = true });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 6, Field.TileSize * 3), Speed = 64, IsDiver = true });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 8, Field.TileSize * 3), Speed = 64, IsDiver = false });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 9, Field.TileSize * 3), Speed = 64, IsDiver = false });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 11, Field.TileSize * 3), Speed = 64, IsDiver = true });
            level.RowTen.Add(new TurtleDef() { Direction = Direction.Left, Size = new Point(Field.TileSize, Field.TileSize), Position = new Vector2(Field.TileSize * 12, Field.TileSize * 3), Speed = 64, IsDiver = true });
            level.RowEleven.Add(new LogDef() { Direction = Direction.Right, Speed = 64, Position = new Vector2(2 * Field.TileSize, Field.TileSize * 2), MidSections = 2 });
            level.RowEleven.Add(new LogDef() { Direction = Direction.Right, Speed = 64, Position = new Vector2(8 * Field.TileSize, Field.TileSize * 2), MidSections = 2 });
            level.RowEleven.Add(new LogDef() { Direction = Direction.Right, Speed = 64, Position = new Vector2(13 * Field.TileSize, Field.TileSize * 2), MidSections = 2 });

            LevelDefs.Add(level);
        }
    }
}
