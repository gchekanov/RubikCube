using RubikCube_TechPods.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikCube_TechPods.Domain
{
    public class Cube
    {
        public Face Up { get; }
        public Face Down { get; }
        public Face Left { get; }
        public Face Right { get; }
        public Face Front { get; }
        public Face Back { get; }

        public Cube()
        {
            Up = new Face(TileColor.White);
            Down = new Face(TileColor.Yellow);
            Front = new Face(TileColor.Green);
            Back = new Face(TileColor.Blue);
            Left = new Face(TileColor.Orange);
            Right = new Face(TileColor.Red);
        }
        public Cube Clone()
        {
            var clone = new Cube();

            clone.Up.CopyTilesFrom(this.Up);
            clone.Down.CopyTilesFrom(this.Down);
            clone.Front.CopyTilesFrom(this.Front);
            clone.Back.CopyTilesFrom(this.Back);
            clone.Left.CopyTilesFrom(this.Left);
            clone.Right.CopyTilesFrom(this.Right);

            return clone;
        }

        public bool Equals(Cube other)
        {
            if (other == null) return false;

            return Up.Equals(other.Up)
                && Down.Equals(other.Down)
                && Front.Equals(other.Front)
                && Back.Equals(other.Back)
                && Left.Equals(other.Left)
                && Right.Equals(other.Right);
        }

        public IEnumerable<TileColor> GetAllTiles()
        {
            foreach (var face in new[] { Up, Down, Front, Back, Left, Right })
                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 3; c++)
                        yield return face.Tiles[r, c];
        }

    }
}
