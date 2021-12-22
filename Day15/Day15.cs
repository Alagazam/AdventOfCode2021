using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day15
    {
        struct Pair
        {
            public Pair(int xx, int yy) { x = xx; y = yy; }
            public int x;
            public int y;
            public static Pair operator +(Pair a, Pair b) { return new Pair(a.x + b.x, a.y + b.y); }
            public bool isValid(int xmax, int ymax) { return x >= 0 && x <= xmax && y >= 0 && y <= ymax; }
        }
        static int h(Pair a, Pair b) {  return Math.Abs(a.x - b.x + a.y - b.y); } // manhattan distance from a to b

        static List<Pair> directions= new List<Pair> { new Pair(0,1), new Pair(1,0), new Pair(0,-1), new Pair(-1,0) };

        public static int A_Star(int[,] grid)
        {
            var xmax = grid.GetLength(0) - 1;
            var ymax = grid.GetLength(1) - 1;
            var start = new Pair(0, 0);
            var end = new Pair(xmax, ymax);

            var openQueue = new PriorityQueue<Pair, int>();
            openQueue.Enqueue( start, 0 );
            var openSet = new Dictionary<Pair, int>();
            openSet[start] = 0;

            var cameFrom = new Dictionary<Pair, Pair>();

            var gScore = new Dictionary<Pair, int>();
            gScore[start] = 0;

            var fScore = new Dictionary<Pair, int>();
            fScore[start] = h(start, end);  

            while (openQueue.Count > 0)
            {
                var current = openQueue.Dequeue();
                if (current.Equals(end))
                {
                    break;
                }
                foreach(var dir in directions)
                {
                    var neighbor = current + dir;
                    if (!neighbor.isValid(xmax, ymax)) continue;

                    var tentative_gScore = gScore[current] + grid[neighbor.x, neighbor.y];
                    if (!gScore.ContainsKey(neighbor) || tentative_gScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentative_gScore;
                        fScore[neighbor] = tentative_gScore + h(neighbor, end);
                        if (!openSet.ContainsKey(neighbor))
                        {
                            openSet[neighbor] = 0;
                            openQueue.Enqueue(neighbor, fScore[neighbor]);
                        }
                    }
                }
            }
            return fScore[end];
        }

        public static Int64 Day15a(string[] input)
        {
            var grid = new int[input.Length, input[0].Length];
            int y = 0;
            foreach (var row in input)
            {
                int x = 0;
                foreach (var c in row)
                {
                    grid[x, y] = c - '0';
                    x++;
                }
                y++;
            }

            return A_Star(grid);
            return 0;
        }

        public static Int64 Day15b(string[] input)
        {
            var xSize = input[0].Length;
            var ySize = input.Length;
            var grid = new int[xSize * 5, ySize * 5];
            int y = 0;
            foreach (var row in input)
            {
                int x = 0;
                foreach (var c in row)
                {
                    foreach (var ytile in Enumerable.Range(0, 5))
                        foreach (var xtile in Enumerable.Range(0, 5))
                        {
                            grid[x + xtile * xSize, y + ytile * ySize] = (c - '1' + xtile + ytile) % 9 + 1 ;
                        }
                    x++;
                }
                y++;
            }

            return A_Star(grid);
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day15.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day15a : {0}   Time: {1}", Day15a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day15b : {0}   Time: {1}", Day15b(lines), sw.ElapsedMilliseconds);
        }
    }
}
