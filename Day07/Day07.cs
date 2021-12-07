using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day07
    {
        public static Int64 Day07a(string[] input)
        {
            var depths = Array.ConvertAll(input[0].Split(','), int.Parse);
            var maxDepth = depths.Max();

            var bestDepth = 0;
            var bestSum = int.MaxValue;
            foreach (var depth in Enumerable.Range(0, maxDepth))
            {
                var sum = depths.Sum(d => Math.Abs(d-depth));
                if (sum < bestSum)
                {
                    bestDepth = depth;
                    bestSum = sum;
                }
            }

            return bestSum;
        }

        public static Int64 Day07b(string[] input)
        {
            var depths = Array.ConvertAll(input[0].Split(','), int.Parse);
            var maxDepth = depths.Max();

            var bestDepth = 0;
            var bestSum = int.MaxValue;
            foreach (var depth in Enumerable.Range(0, maxDepth))
            {
                var sum = depths.Sum(d => Math.Abs(d - depth) * (Math.Abs(d - depth)+1) / 2);
                if (sum < bestSum)
                {
                    bestDepth = depth;
                    bestSum = sum;
                }
            }

            return bestSum;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day07.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day07a : {0}   Time: {1}", Day07a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day07b : {0}   Time: {1}", Day07b(lines), sw.ElapsedMilliseconds);
        }
    }
}
