using System;

namespace Assets.Scripts.Pathfinding
{
    public class PathEventArgs : EventArgs
    {
        public Path Path;

        public PathEventArgs(Path path)
        {
            Path = path;
        }
    }
}