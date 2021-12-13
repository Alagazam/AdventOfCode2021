using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day13
    {
        public static Int64 Fold(string[] input, bool breakAfterFirst)
        {
            var xmax = 0;
            var ymax = 0;

            foreach (var day in input)
            {
                var coords = day.Split(',');
                if (coords.Length == 1) break;

                var x = int.Parse(coords[0]); if (x > xmax) xmax = x;
                var y = int.Parse(coords[1]); if (y > ymax) ymax = y;
            }
            var grid = new int[xmax + 1 , ymax + 1];
            foreach (var day in input)
            {
                if (day == "") continue;
                var coords = day.Split(',');
                if (coords.Length == 2)
                {
                    var x = int.Parse(coords[0]);
                    var y = int.Parse(coords[1]);
                    grid[x, y] = 1;
                }
                else
                {
                    var p = day.Split('=');
                    var fold = int.Parse(p[1]);
                    if (p[0].EndsWith('y'))
                    {
                        for (int y = 1; y != ymax - fold + 1 ; y++)
                        {
                            foreach (var x in Enumerable.Range(0, xmax + 1 ) )
                                if (grid[x, fold + y] == 1) grid[x, fold - y] = 1;
                        }
                        ymax = fold - 1;
                    }
                    if (p[0].EndsWith('x'))
                    {
                        for (int x = 1; x != xmax - fold + 1 ; x++)
                        {
                            foreach (var y in Enumerable.Range(0, ymax + 1))
                                if (grid[fold + x, y] == 1) grid[fold - x, y] = 1;
                        }
                        xmax = fold - 1;
                    }
                    if (breakAfterFirst) break;
                }
            }

            int count = 0;
            foreach (var y in Enumerable.Range(0, ymax + 1))
            {
                foreach (var x in Enumerable.Range(0, xmax + 1))
                {
                    count += grid[x, y];
                    if (!breakAfterFirst) Console.Write(grid[x, y] == 1 ? '#' : '.');
                }
                if (!breakAfterFirst) Console.WriteLine();
            }

            return count;
        }

        public static Int64 Day13a(string[] input)
        {
            return Fold(input, true);
        }
            public static Int64 Day13b(string[] input)
        {
            return Fold(input, false); ;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day13.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day13a : {0}   Time: {1}", Day13a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day13b : {0}   Time: {1}", Day13b(lines), sw.ElapsedMilliseconds);
        }
    }
}
