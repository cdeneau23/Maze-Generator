using System;

namespace Driver
{
    class Program
    {
        static void Main(string[] args)
        {
                var maze = new Maze.Maze(15, 5, 10);
                maze.Print();
        }
    }
}