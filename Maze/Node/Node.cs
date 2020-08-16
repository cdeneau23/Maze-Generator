using System;

namespace Maze.Node
{
    public class Node
    { 
        public int X { get; set; }
        public int Y { get; set; }
        public NodeWalls Walls { get; set; }
        public bool Visited { get; set; }

        public void RemoveWall(NodeWalls wall)
        {
            Walls -= wall;
        }

        public void RemoveAllWalls()
        {
            Walls = NodeWalls.None;
        }
        public void DrawNode()
        {
            Console.Write("");
        }
    }
}