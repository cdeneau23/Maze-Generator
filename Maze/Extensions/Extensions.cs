using Maze.Node;

namespace Maze.Extensions
{
    public static class Extensions
    {
        public static NodeWalls OppositeWall(this NodeWalls orig)
        {
            return (NodeWalls)(((int)orig >> 2) | ((int)orig << 2)) & NodeWalls.Initial;
        }

        public static bool HasWall(this NodeWalls nodeWalls, NodeWalls flag)
        {
            return ((int)nodeWalls & (int)flag) != 0;
        }
    }
}