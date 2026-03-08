using RubikCube_TechPods.Domain;
using RubikCube_TechPods.Domain.Enums;
using RubiksCube_TechPods.Domain;
using RubiksCube_TechPods.Domain.Services;

var cube = new Cube();
var cubeService = new CubeService(cube);

while (true)
{
    Console.Clear();

    // Header с командите – винаги се вижда горе
    Console.WriteLine("Rubik's Cube Console");
    Console.WriteLine("Commands:");
    Console.WriteLine("F  - Front clockwise | F' - Front counter-clockwise");
    Console.WriteLine("R  - Right clockwise | R' - Right counter-clockwise");
    Console.WriteLine("L  - Left clockwise  | L' - Left counter-clockwise");
    Console.WriteLine("U  - Up clockwise    | U' - Up counter-clockwise");
    Console.WriteLine("D  - Down clockwise  | D' - Down counter-clockwise");
    Console.WriteLine("B  - Back clockwise  | B' - Back counter-clockwise");
    Console.WriteLine("Type 'exit' to quit.\n");

    // Визуализиране на куба
    cubeService.PrintExplodedView();

    Console.Write("\nEnter rotation: ");
    var input = Console.ReadLine()?.Trim().ToUpper();

    if (string.IsNullOrEmpty(input)) continue;
    if (input == "EXIT") break;

    FaceType face;
    RotationDirection dir = RotationDirection.Clockwise;

    switch (input)
    {
        case "F": face = FaceType.Front; break;
        case "F'": face = FaceType.Front; dir = RotationDirection.CounterClockwise; break;
        case "B": face = FaceType.Back; break;
        case "B'": face = FaceType.Back; dir = RotationDirection.CounterClockwise; break;
        case "L": face = FaceType.Left; break;
        case "L'": face = FaceType.Left; dir = RotationDirection.CounterClockwise; break;
        case "R": face = FaceType.Right; break;
        case "R'": face = FaceType.Right; dir = RotationDirection.CounterClockwise; break;
        case "U": face = FaceType.Up; break;
        case "U'": face = FaceType.Up; dir = RotationDirection.CounterClockwise; break;
        case "D": face = FaceType.Down; break;
        case "D'": face = FaceType.Down; dir = RotationDirection.CounterClockwise; break;
        default:
            Console.WriteLine("Invalid command. Press Enter to continue...");
            Console.ReadLine();
            continue;
    }

    cubeService.Rotate(face, dir);
}