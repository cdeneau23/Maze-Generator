using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Extensions;
using Maze.Node;

namespace Maze
{ 
    public class Maze
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _numberOfRooms; // TODO: Figure out how to build and place rooms

        private Node.Node[,] _grid;
        private readonly Random _rand;

        public Maze(int width, int height, int rooms)
        {
            _width = width;
            _height = height;
            _numberOfRooms = rooms;
            _rand = new Random();
            
            GenerateNodeGrid();

            Carve(_rand.Next(_width), _rand.Next(_height));
        }
        private void GenerateNodeGrid()
        {
            _grid = new Node.Node[_width, _height];
            for (var x = 0; x < _width; x++)
            {
                for(var y = 0; y < _height; y++)
                {
                    var node = new Node.Node
                    {
                        X = x,
                        Y = y,
                        Visited = false,
                        Walls = NodeWalls.Initial
                    };

                    _grid[x, y] = node;
                }
            }
        }
        private void GenerateRooms()
        {
            //TODO: Create rooms and place them on the grid
        }
        private void Carve(int x, int y)
        {
            _grid[x, y].Visited = true;

            var randNeighbors = GetNeighbor(_grid[x, y])
                .OrderBy(node => _rand.Next())
                .Where(node => !_grid[node.Node.X, node.Node.Y].Visited);

            foreach(var node in randNeighbors)
            {
                _grid[x, y].Walls -= node.Wall;

                _grid[node.Node.X, node.Node.Y].Walls -= node.Wall.OppositeWall();

                Carve(node.Node.X, node.Node.Y);
            }
        }
        private List<NeighborNode> GetNeighbor(Node.Node node)
        {
            var nodes = new List<NeighborNode>();
            if (node.X > 0)
            {
                nodes.Add(new NeighborNode()
                {
                    Node = _grid[node.X-1, node.Y],
                    Wall = NodeWalls.Left
                });
            }
            if (node.X < _width - 1)
            {
                nodes.Add(new NeighborNode()
                {
                    Node = _grid[node.X + 1, node.Y],
                    Wall = NodeWalls.Right
                });
            }
            if (node.Y > 0)
            {
                nodes.Add(new NeighborNode()
                {
                    Node = _grid[node.X, node.Y - 1],
                    Wall = NodeWalls.Top
                });
            }
            if (node.Y < _height - 1)
            {
                nodes.Add(new NeighborNode()
                {
                    Node = _grid[node.X, node.Y + 1],
                    Wall = NodeWalls.Bottom
                });
            }

            return nodes;
        }
        public void Print()
        {
            var firstLine = string.Empty;
            for (var y = 0; y < _height; y++)
            {
                var sbTop = new StringBuilder();
                var sbMid = new StringBuilder();
                for (var x = 0; x < _width; x++)
                {
                    sbTop.Append(_grid[x, y].Walls.HasFlag(NodeWalls.Top) ? "*--" : "+  ");
                    sbMid.Append(_grid[x, y].Walls.HasFlag(NodeWalls.Left) ? "|  " : "   ");
                }
                if (firstLine == string.Empty)
                    firstLine = sbTop.ToString();
                Console.WriteLine(sbTop + "*");
                Console.WriteLine(sbMid + "|");
            }
            Console.WriteLine(firstLine + "+");
        }

    }
}
