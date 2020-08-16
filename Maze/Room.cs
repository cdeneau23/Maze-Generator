using System;
using System.Collections.Generic;
using Maze.Node;

namespace Maze
{
    public class Room
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public List<Node.Node> Nodes { get; set; }
        public bool IsValid { get; set; } = true;

        public Room()
        {
            RoomWidth = 2;
            RoomHeight = 2;
            Nodes = new List<Node.Node>();
        }

        public void PlaceRoom(Node.Node[,] grid, Random rand)
        {
            var maxX = grid.GetLength(0) - 2;
            var maxY = grid.GetLength(1) - 2;
            
            // Pick a random spot in the grid
            var x = rand.Next(maxX);
            var y = rand.Next(maxY);

            for (var i = x; i < x + RoomWidth; i++)
            {
                for (var j = y; j < y + RoomHeight; j++)
                {
                    var n = grid[i, j];
                    if (n.Visited)
                    {
                        ResetNodes();
                        return;
                    }
                    n.Visited = true;
                    n.RemoveAllWalls();
                    Nodes.Add(n);
                }
            }
        }

        private void ResetNodes()
        {
            foreach (var n in Nodes)
            {
                n.Visited = false;
                n.Walls = NodeWalls.Initial;
            }

            IsValid = false;
        }
    }
}