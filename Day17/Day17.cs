using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public class Day17
    {
        public static Int64 Calc(string[] input, ref int count)
        {
            var rx = new Regex(@".*x=(\d+)\.\.(\d+), y=(-\d+)\.\.(-\d+)");
            var match = rx.Match(input[0]);
            var groups = match.Groups;
            var txmin = Int32.Parse(groups[1].ToString());
            var txmax = Int32.Parse(groups[2].ToString());
            var tymin = Int32.Parse(groups[3].ToString());
            var tymax = Int32.Parse(groups[4].ToString());

            var ymax = 0;
            count = 0;
            for (var deltax = 1; deltax <= txmax; deltax++)
            {
                for (var deltay = tymin; deltay < 100; deltay++)
                {
                    var x = 0;
                    var y = 0;
                    var dx = deltax;
                    var dy = deltay;

                    var currentYmax = 0;
                    while (x < txmax && y > tymin)
                    {
                        x += dx;
                        y += dy;
                        if (y > currentYmax) currentYmax = y;
                        dx = (dx > 0 ? dx - 1 : 0);
                        if (dx == 0 && x < txmin) break;
                        dy--;
                        if (x>= txmin && x<= txmax &&
                            y >= tymin && y<= tymax)
                        {
                            count++;
                            if (currentYmax > ymax) ymax = currentYmax;
                            break;
                        }
                    }
                }
            }

            return ymax;
        }

        public static Int64 Day17a(string[] input)
        {
            int count = 0;
            return Calc(input, ref count);
        }


        public static Int64 Day17b(string[] input)
        {
            int count = 0;
            Calc(input, ref count);
            return count;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day17.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day17a : {0}   Time: {1}", Day17a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day17b : {0}   Time: {1}", Day17b(lines), sw.ElapsedMilliseconds);
        }
    }
}
