using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFS_c_sharp.Model;

namespace BFS_c_sharp.Search
{
    class ShortestPath
    {
        public static List<List<UserNode>> GetShortestPath(UserNode start, UserNode end)
        {
            HashSet<UserNode> visited = new HashSet<UserNode>();
            Queue<UserNode> queue = new Queue<UserNode>();
            int currentDepth = 0;
            visited.Add(start);
            queue.Enqueue(start);
            start.Depth = currentDepth;

            while (queue.Count > 0)
            {
                UserNode currentUser = queue.Dequeue();
                currentDepth++;
                if (currentUser == end)
                {
                    break;
                }

                foreach (UserNode neighbour in currentUser.Friends)
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        queue.Enqueue(neighbour);
                        neighbour.Parents.Add(currentUser);
                        neighbour.Depth = currentDepth;
                    }
                }
            }
            if (end.Parents.Count == 0)
            {
                return null;
            }
            var shortestPaths = new List<List<UserNode>>();
            var currentPath = new List<UserNode>();
            shortestPaths.Add(currentPath);
            TraceBack(shortestPaths, currentPath, start, end);

            return shortestPaths;
        }

        private static void TraceBack(List<List<UserNode>> paths, List<UserNode> currentPath, UserNode start, UserNode currentNode)
        {
            for (int i = 0; i < currentNode.Parents.Count; i++)
            {
                var currentParent = currentNode.Parents[i];
                if (currentParent.Depth < currentNode.Depth)
                {
                    if (currentParent == start)
                    {
                        return;
                    }

                    if (i == 0)
                    {
                        currentPath.Add(currentParent);
                        TraceBack(paths, currentPath, start, currentParent);
                    }
                    else
                    {
                        var newPath = new List<UserNode>
                        {
                            currentParent
                        };
                        paths.Add(newPath);
                        TraceBack(paths, newPath, start, currentParent);
                    }
                }
            }
        }
    }
}
