using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Stack<int> leftSocks = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList()
                );

            Queue<int> rightSocks = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList()
                );

            int biggestPair = int.MinValue;
            List<int> pairs = new List<int>();
            int currLeftSock = leftSocks.Pop();
            int currRightSock = rightSocks.Dequeue();

            while (leftSocks.Count >= 0 && rightSocks.Count >= 0)
            {
                if (currLeftSock > currRightSock)
                {
                    pairs.Add(currLeftSock + currRightSock);
                }
                else if (currRightSock == currLeftSock)
                {
                    leftSocks.Push(currLeftSock + 1);
                }
                else if (currRightSock > currLeftSock)
                {
                    if (leftSocks.Count == 0)
                    {
                        break;
                    }
                    currLeftSock = leftSocks.Pop();
                    continue;
                }
                if (leftSocks.Count == 0 || rightSocks.Count == 0)
                {
                    break;
                }
                currLeftSock = leftSocks.Pop();
                currRightSock = rightSocks.Dequeue();
            }
            biggestPair = pairs
                .OrderByDescending(p => p)
                .ToList()
                .FirstOrDefault();
            Console.WriteLine(biggestPair);
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
