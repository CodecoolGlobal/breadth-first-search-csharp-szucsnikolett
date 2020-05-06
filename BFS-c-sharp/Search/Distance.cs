using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFS_c_sharp.Model;

namespace BFS_c_sharp.Search
{
    class Distance
    {
        public static int GetShortestDistanceBetweenUsers(UserNode start, UserNode end)
        {
            HashSet<UserNode> visited = new HashSet<UserNode>();
            Queue<UserNode> queue = new Queue<UserNode>();

            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                UserNode currentUser = queue.Dequeue();

                if (currentUser == end)
                {
                    return currentUser.Depth;
                }

                foreach (UserNode neighbour in currentUser.Friends)
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        neighbour.Depth = currentUser.Depth + 1;
                        queue.Enqueue(neighbour);
                    }
                }
            }
            return -1;
        }
    }
}
