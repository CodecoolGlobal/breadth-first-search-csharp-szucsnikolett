using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFS_c_sharp.Model;

namespace BFS_c_sharp.Search
{
    class Friends
    {
        public static HashSet<UserNode> GetFriendsOfFriends(UserNode user, int depth)
        {
            HashSet<UserNode> visited = new HashSet<UserNode>();
            Queue<UserNode> queue = new Queue<UserNode>();

            visited.Add(user);
            queue.Enqueue(user);
            user.Depth = 0;

            while (queue.Count > 0)
            {
                UserNode currentUser = queue.Dequeue();
                if (currentUser.Depth > depth)
                {
                    visited.Remove(user);
                    return visited;
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
            visited.Remove(user);
            return visited;
        }
    }
}
