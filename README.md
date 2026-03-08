🧩 Rubik’s Cube Console App

This project is a programmatic Rubik’s Cube simulator built as a .NET 8 Console Application.
It allows rotation of all cube faces and displays the cube in an exploded view.

📁 Project Structure

Domain/ – contains Cube, Face, enums (TileColor, FaceType, RotationDirection)

Domain/Services/ – contains CubeService with Rotate() and PrintExplodedView()

Tests/ – contains NUnit tests (CubeRotationTests.cs)

Program.cs – entry point with interactive console interface

⚙️ Prerequisites

.NET 8 SDK

Any IDE supporting .NET (Visual Studio, VS Code, Rider)

🛠 Building the Project
Using .NET CLI:
cd RubikCube_TechPods
dotnet build
Using Visual Studio:

Open RubikCube_TechPods.sln

Build the solution (Ctrl+Shift+B)

▶️ Running the Program
Using .NET CLI:
dotnet run --project RubikCube_TechPods

The program will start in console mode and display the exploded view of the cube.
It also shows the available commands for rotating each face:

Commands:
F  - Front clockwise       F' - Front counter-clockwise
R  - Right clockwise       R' - Right counter-clockwise
L  - Left clockwise        L' - Left counter-clockwise
U  - Up clockwise          U' - Up counter-clockwise
D  - Down clockwise        D' - Down counter-clockwise
B  - Back clockwise        B' - Back counter-clockwise
exit - Quit

💡 Enter a command and the cube will update immediately and print the new exploded view.

🧪 Running Tests

The project uses NUnit for unit testing. To run tests:

dotnet test

The tests include:

🔄 Rotating a face 4 times returns to the initial state

↔️ Clockwise + counter-clockwise rotation returns to initial state

🔀 A sequence of rotations matches expected cube behavior

🎨 All tiles have valid colors

📌 Notes

The cube starts in a solved state:

Front: Green   Right: Red   Up: White
Back: Blue     Left: Orange Down: Yellow

The solution focuses on clean code, testability, and maintainability

❌ No UI is implemented; the console interface demonstrates the rotations clearly
