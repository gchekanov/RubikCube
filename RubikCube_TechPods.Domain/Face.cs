using RubikCube_TechPods.Domain.Enums;

namespace RubikCube_TechPods.Domain
{
    public class Face
    {
        public TileColor[,] Tiles { get; private set; } = new TileColor[3, 3];

        public Face(TileColor color)
        {
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    Tiles[r, c] = color;
        }

        public void CopyTilesFrom(Face other)
        {
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    this.Tiles[r, c] = other.Tiles[r, c];
        }

        public Face Clone()
        {
            var newFace = new Face(Tiles[0, 0]);
            newFace.CopyTilesFrom(this);
            return newFace;
        }

        public void RotateClockwise()
        {
            var temp = new TileColor[3, 3];
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    temp[c, 2 - r] = Tiles[r, c];
            Tiles = temp;
        }

        public void RotateCounterClockwise()
        {
            var temp = new TileColor[3, 3];
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    temp[2 - c, r] = Tiles[r, c];
            Tiles = temp;
        }

        public bool Equals(Face other)
        {
            if (other == null) return false;
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (Tiles[r, c] != other.Tiles[r, c])
                        return false;
            return true;
        }

    }
}
