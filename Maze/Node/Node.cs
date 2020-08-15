namespace Maze.Node
{
    public struct Node
    { 
        public int X { get; set; }
        public int Y { get; set; }
        public NodeWalls Walls { get; set; }
        public bool Visited { get; set; }
    }
}