using System;

namespace GameOfLife
{
    class Program
    {
        static int width;
        static int height;
        static int generations;

        static void Main(string[] args)
        {
            Library.Game game = null;
            while (true)
            {
                try
                {
                    Console.WriteLine("Welcome to Shawn's Game of Life.");
                    Console.WriteLine("Enter your game parameters (use a width and height that will fit in your screen - typically 100 x 45):");
                    Console.WriteLine("Width       : ");
                    Console.WriteLine("Height      : ");
                    Console.WriteLine("Generations : ");
                    Console.SetCursorPosition(14, 2);
                    width = Int32.Parse(Console.ReadLine());
                    Console.SetCursorPosition(14, 3);
                    height = Int32.Parse(Console.ReadLine());
                    Console.SetCursorPosition(14, 4);
                    generations = Int32.Parse(Console.ReadLine());
                    
                    Console.SetWindowSize(width, height);
                    Console.SetBufferSize(width, height);
                    Console.WriteLine("Initializing game board...");
                    break; //break while loop since width and height are good.
                }
                catch (Exception)
                {
                    //the width and heigh don't fit in the screen
                    Console.Clear();
                    //re-run the while loop
                }
            }

            Console.Clear();
            Console.CursorVisible = false;

            game = new Library.Game(width, height, generations);
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
                    Console.Write(cell.Alive ? "X" : " ");
                }
        }
    }
}
