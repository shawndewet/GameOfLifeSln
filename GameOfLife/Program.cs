using System;

namespace GameOfLife
{
    class Program
    {
        static int width;
        static int height;

        static void Main(string[] args)
        {
            var generations = 0;
            Console.WriteLine("Welcome to Shawn's Game of Life.");
            Console.WriteLine("Enter your game parameters:");
            Console.WriteLine("Width       : ");
            Console.WriteLine("Height      : ");
            Console.WriteLine("Generations : ");
            Console.CursorTop = 0;
            Console.SetCursorPosition(14, 2);
            width = Int32.Parse(Console.ReadLine());
            Console.SetCursorPosition(14, 3);
            height = Int32.Parse(Console.ReadLine());
            Console.SetCursorPosition(14, 4);
            generations = Int32.Parse(Console.ReadLine());

            var game = new Library.Game(width, height, generations);

            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            game.Start(PaintUI);

            Console.ReadLine();
        }

        static void PaintUI(Library.Cell[,] grid)
        {
            for (int c = 1; c <= width; c++)
                for (int r = 1; r <= height; r++)
                {
                    var x = c - 1;
                    var y = r - 1;
                    Console.SetCursorPosition(x, y);
                    var cell = grid[x, y];
                    Console.Write(cell.Alive ? "X" : ".");
                }
        }
    }
}
