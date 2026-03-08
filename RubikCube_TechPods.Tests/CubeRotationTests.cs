using NUnit.Framework;
using RubikCube_TechPods.Domain;
using RubikCube_TechPods.Domain.Enums;
using RubiksCube_TechPods.Domain;
using RubiksCube_TechPods.Domain.Services;

namespace RubiksCube_TechPods.Tests
{
    [TestFixture]
    public class CubeRotationTests
    {
        [Test]
        public void FourFrontRotations_ShouldReturnToInitialState()
        {
            var cube = new Cube();
            var service = new CubeService(cube);

            var initial = cube.Clone();

            for (int i = 0; i < 4; i++)
                service.Rotate(FaceType.Front, RotationDirection.Clockwise);

            Assert.IsTrue(cube.Equals(initial), "Cube should return to initial state after 4 Front CW rotations.");
        }

        [Test]
        public void FrontClockwiseThenCounterClockwise_ShouldReturnToInitialState()
        {
            var cube = new Cube();
            var service = new CubeService(cube);

            var initial = cube.Clone();

            service.Rotate(FaceType.Front, RotationDirection.Clockwise);
            service.Rotate(FaceType.Front, RotationDirection.CounterClockwise);

            Assert.IsTrue(cube.Equals(initial), "Cube should return to initial state after Front CW + CCW rotation.");
        }

        [Test]
        public void SampleSequence_ShouldNotBreakCube()
        {
            var cube = new Cube();
            var service = new CubeService(cube);

            service.Rotate(FaceType.Front, RotationDirection.Clockwise);
            service.Rotate(FaceType.Right, RotationDirection.CounterClockwise);
            service.Rotate(FaceType.Up, RotationDirection.Clockwise);
            service.Rotate(FaceType.Back, RotationDirection.CounterClockwise);
            service.Rotate(FaceType.Left, RotationDirection.Clockwise);
            service.Rotate(FaceType.Down, RotationDirection.CounterClockwise);

            foreach (var tile in cube.GetAllTiles())
            {
                Assert.IsTrue(Enum.IsDefined(typeof(TileColor), tile), "Tile must have a valid color.");
            }
        }

        [Test]
        [TestCase(FaceType.Front)]
        [TestCase(FaceType.Back)]
        [TestCase(FaceType.Left)]
        [TestCase(FaceType.Right)]
        [TestCase(FaceType.Up)]
        [TestCase(FaceType.Down)]
        public void RotateFace_CWThenCCW_ShouldReturnToInitial(FaceType face)
        {
            var cube = new Cube();
            var service = new CubeService(cube);

            var initial = cube.Clone();

            service.Rotate(face, RotationDirection.Clockwise);
            service.Rotate(face, RotationDirection.CounterClockwise);

            Assert.IsTrue(cube.Equals(initial), $"Cube should return to initial state after rotating {face} CW+CCW.");
        }
    }
}