﻿using System;

namespace Driver
{
    class Program
    {
        static void Main(string[] args)
        {
                var maze = new Maze.Maze(15, 7, 10);
                maze.Print();
        }
    }
}