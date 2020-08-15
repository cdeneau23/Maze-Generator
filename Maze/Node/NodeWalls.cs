using System;

namespace Maze.Node
{
    [Flags]
    public enum NodeWalls
    {
        
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8,
        Initial = Top | Right | Bottom | Left,
    }
}