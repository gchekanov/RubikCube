using RubikCube_TechPods.Domain;
using RubikCube_TechPods.Domain.Enums;

namespace RubiksCube_TechPods.Domain.Services;

public class CubeService
{
    private readonly Cube _cube;

    public CubeService(Cube cube)
    {
        _cube = cube;
    }

    public void Rotate(FaceType face, RotationDirection direction)
    {
        switch (face)
        {
            case FaceType.Front: RotateFront(direction); break;
            case FaceType.Back: RotateBack(direction); break;
            case FaceType.Left: RotateLeft(direction); break;
            case FaceType.Right: RotateRight(direction); break;
            case FaceType.Up: RotateUp(direction); break;
            case FaceType.Down: RotateDown(direction); break;
        }
    }

    #region Rotations

    private void RotateFront(RotationDirection direction)
    {
        if (direction == RotationDirection.Clockwise)
            _cube.Front.RotateClockwise();
        else
            _cube.Front.RotateCounterClockwise();

        if (direction == RotationDirection.Clockwise)
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Up.Tiles[2, i];

            for (int i = 0; i < 3; i++) _cube.Up.Tiles[2, i] = _cube.Left.Tiles[2 - i, 2];
            for (int i = 0; i < 3; i++) _cube.Left.Tiles[i, 2] = _cube.Down.Tiles[0, i];
            for (int i = 0; i < 3; i++) _cube.Down.Tiles[0, i] = _cube.Right.Tiles[2 - i, 0];
            for (int i = 0; i < 3; i++) _cube.Right.Tiles[i, 0] = temp[i];
        }
        else
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Up.Tiles[2, i];

            for (int i = 0; i < 3; i++) _cube.Up.Tiles[2, i] = _cube.Right.Tiles[i, 0];
            for (int i = 0; i < 3; i++) _cube.Right.Tiles[i, 0] = _cube.Down.Tiles[0, 2 - i];
            for (int i = 0; i < 3; i++) _cube.Down.Tiles[0, i] = _cube.Left.Tiles[i, 2];
            for (int i = 0; i < 3; i++) _cube.Left.Tiles[i, 2] = temp[2 - i];
        }
    }

    private void RotateBack(RotationDirection direction)
    {
        if (direction == RotationDirection.Clockwise)
            _cube.Back.RotateClockwise();
        else
            _cube.Back.RotateCounterClockwise();

        if (direction == RotationDirection.Clockwise)
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Up.Tiles[0, i];

            for (int i = 0; i < 3; i++) _cube.Up.Tiles[0, i] = _cube.Right.Tiles[i, 2];
            for (int i = 0; i < 3; i++) _cube.Right.Tiles[i, 2] = _cube.Down.Tiles[2, 2 - i];
            for (int i = 0; i < 3; i++) _cube.Down.Tiles[2, i] = _cube.Left.Tiles[i, 0];
            for (int i = 0; i < 3; i++) _cube.Left.Tiles[i, 0] = temp[2 - i];
        }
        else
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Up.Tiles[0, i];

            for (int i = 0; i < 3; i++) _cube.Up.Tiles[0, i] = _cube.Left.Tiles[2 - i, 0];
            for (int i = 0; i < 3; i++) _cube.Left.Tiles[i, 0] = _cube.Down.Tiles[2, i];
            for (int i = 0; i < 3; i++) _cube.Down.Tiles[2, i] = _cube.Right.Tiles[2 - i, 2];
            for (int i = 0; i < 3; i++) _cube.Right.Tiles[i, 2] = temp[i];
        }
    }

    private void RotateLeft(RotationDirection direction)
    {
        if (direction == RotationDirection.Clockwise)
            _cube.Left.RotateClockwise();
        else
            _cube.Left.RotateCounterClockwise();

        if (direction == RotationDirection.Clockwise)
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Up.Tiles[i, 0];

            for (int i = 0; i < 3; i++) _cube.Up.Tiles[i, 0] = _cube.Back.Tiles[2 - i, 2];
            for (int i = 0; i < 3; i++) _cube.Back.Tiles[i, 2] = _cube.Down.Tiles[i, 0];
            for (int i = 0; i < 3; i++) _cube.Down.Tiles[i, 0] = _cube.Front.Tiles[i, 0];
            for (int i = 0; i < 3; i++) _cube.Front.Tiles[i, 0] = temp[i];
        }
        else
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Up.Tiles[i, 0];

            for (int i = 0; i < 3; i++) _cube.Up.Tiles[i, 0] = _cube.Front.Tiles[i, 0];
            for (int i = 0; i < 3; i++) _cube.Front.Tiles[i, 0] = _cube.Down.Tiles[i, 0];
            for (int i = 0; i < 3; i++) _cube.Down.Tiles[i, 0] = _cube.Back.Tiles[2 - i, 2];
            for (int i = 0; i < 3; i++) _cube.Back.Tiles[i, 2] = temp[2 - i];
        }
    }

    private void RotateRight(RotationDirection direction)
    {
        if (direction == RotationDirection.Clockwise)
            _cube.Right.RotateClockwise();
        else
            _cube.Right.RotateCounterClockwise();

        if (direction == RotationDirection.Clockwise)
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Up.Tiles[i, 2];

            for (int i = 0; i < 3; i++) _cube.Up.Tiles[i, 2] = _cube.Front.Tiles[i, 2];
            for (int i = 0; i < 3; i++) _cube.Front.Tiles[i, 2] = _cube.Down.Tiles[i, 2];
            for (int i = 0; i < 3; i++) _cube.Down.Tiles[i, 2] = _cube.Back.Tiles[2 - i, 0];
            for (int i = 0; i < 3; i++) _cube.Back.Tiles[i, 0] = temp[2 - i];
        }
        else
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Up.Tiles[i, 2];

            for (int i = 0; i < 3; i++) _cube.Up.Tiles[i, 2] = _cube.Back.Tiles[2 - i, 0];
            for (int i = 0; i < 3; i++) _cube.Back.Tiles[i, 0] = _cube.Down.Tiles[i, 2];
            for (int i = 0; i < 3; i++) _cube.Down.Tiles[i, 2] = _cube.Front.Tiles[i, 2];
            for (int i = 0; i < 3; i++) _cube.Front.Tiles[i, 2] = temp[i];
        }
    }

    private void RotateUp(RotationDirection direction)
    {
        if (direction == RotationDirection.Clockwise)
            _cube.Up.RotateClockwise();
        else
            _cube.Up.RotateCounterClockwise();

        if (direction == RotationDirection.Clockwise)
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Back.Tiles[0, i];

            for (int i = 0; i < 3; i++) _cube.Back.Tiles[0, i] = _cube.Right.Tiles[0, i];
            for (int i = 0; i < 3; i++) _cube.Right.Tiles[0, i] = _cube.Front.Tiles[0, i];
            for (int i = 0; i < 3; i++) _cube.Front.Tiles[0, i] = _cube.Left.Tiles[0, i];
            for (int i = 0; i < 3; i++) _cube.Left.Tiles[0, i] = temp[i];
        }
        else
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Back.Tiles[0, i];

            for (int i = 0; i < 3; i++) _cube.Back.Tiles[0, i] = _cube.Left.Tiles[0, i];
            for (int i = 0; i < 3; i++) _cube.Left.Tiles[0, i] = _cube.Front.Tiles[0, i];
            for (int i = 0; i < 3; i++) _cube.Front.Tiles[0, i] = _cube.Right.Tiles[0, i];
            for (int i = 0; i < 3; i++) _cube.Right.Tiles[0, i] = temp[i];
        }
    }

    private void RotateDown(RotationDirection direction)
    {
        if (direction == RotationDirection.Clockwise)
            _cube.Down.RotateClockwise();
        else
            _cube.Down.RotateCounterClockwise();

        if (direction == RotationDirection.Clockwise)
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Back.Tiles[2, i];

            for (int i = 0; i < 3; i++) _cube.Back.Tiles[2, i] = _cube.Left.Tiles[2, i];
            for (int i = 0; i < 3; i++) _cube.Left.Tiles[2, i] = _cube.Front.Tiles[2, i];
            for (int i = 0; i < 3; i++) _cube.Front.Tiles[2, i] = _cube.Right.Tiles[2, i];
            for (int i = 0; i < 3; i++) _cube.Right.Tiles[2, i] = temp[i];
        }
        else
        {
            TileColor[] temp = new TileColor[3];
            for (int i = 0; i < 3; i++) temp[i] = _cube.Back.Tiles[2, i];

            for (int i = 0; i < 3; i++) _cube.Back.Tiles[2, i] = _cube.Right.Tiles[2, i];
            for (int i = 0; i < 3; i++) _cube.Right.Tiles[2, i] = _cube.Front.Tiles[2, i];
            for (int i = 0; i < 3; i++) _cube.Front.Tiles[2, i] = _cube.Left.Tiles[2, i];
            for (int i = 0; i < 3; i++) _cube.Left.Tiles[2, i] = temp[i];
        }
    }

    #endregion

    public void PrintExplodedView()
    {
        void PrintFace(Face f)
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                    Console.Write($"{f.Tiles[r, c].ToString()[0]} ");
                Console.WriteLine();
            }
        }

        // Up
        for (int r = 0; r < 3; r++)
        {
            Console.Write("      ");
            for (int c = 0; c < 3; c++)
                Console.Write($"{_cube.Up.Tiles[r, c].ToString()[0]} ");
            Console.WriteLine();
        }
        Console.WriteLine();

        // Middle: Left Front Right Back
        for (int r = 0; r < 3; r++)
        {
            foreach (var f in new[] { _cube.Left, _cube.Front, _cube.Right, _cube.Back })
            {
                for (int c = 0; c < 3; c++)
                    Console.Write($"{f.Tiles[r, c].ToString()[0]} ");
                Console.Write("  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Down
        for (int r = 0; r < 3; r++)
        {
            Console.Write("      ");
            for (int c = 0; c < 3; c++)
                Console.Write($"{_cube.Down.Tiles[r, c].ToString()[0]} ");
            Console.WriteLine();
        }
    }
}