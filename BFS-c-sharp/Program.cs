using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using BFS_c_sharp.Search;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            UserNode userOne = users[15];
            UserNode userTwo = users[9];

            Console.WriteLine($"User one is {userOne}");
            Console.WriteLine($"User two is {userTwo}");

            int distance = Distance.GetShortestDistanceBetweenUsers(userOne, userTwo);
            Console.WriteLine($"The shortest distance between {userOne.FirstName} and {userTwo.FirstName} is {distance}");
            ResetUsers(users);
            List<List<UserNode>> paths = ShortestPath.GetShortestPath(userOne, userTwo);

            Console.WriteLine($"The shortest distance between {userOne.FirstName} and {userTwo.FirstName} is:");
            foreach (List<UserNode> path in paths)
            {
                foreach (UserNode user in path)
                {
                    Console.WriteLine(user);
                }
            }
            ResetUsers(users);
            HashSet<UserNode> friends = Friends.GetFriendsOfFriends(userOne, 2);
            Console.WriteLine($"{userOne.FirstName}'s friends:");
            foreach (UserNode friend in friends)
            {
                Console.WriteLine(friend);
            }

            Console.ReadKey();
        }

        private static void ResetUsers(List<UserNode> users)
        {
            foreach (UserNode user in users)
            {
                user.Depth = -1;
                user.Parents = new List<UserNode>();
            }
        }
    }
}
