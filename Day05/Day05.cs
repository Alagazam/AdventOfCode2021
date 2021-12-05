using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public class Day05
    {
        struct Line
        {
            public int x0, y0, x1, y1;
            public Line(string s)
            {
                var rx = new Regex(@"(\d+),(\d+) -> (\d+),(\d+)");
                var match = rx.Match(s);
                var groups = match.Groups;
                x0 = Int32.Parse(groups[1].ToString());
                y0 = Int32.Parse(groups[2].ToString());
                x1 = Int32.Parse(groups[3].ToString());
                y1 = Int32.Parse(groups[4].ToString());
            }
        }

        public static Int64 Day05a(string[] input)
        {
            var lines = new List<Line>();
            var xmax = 0;
            var ymax = 0;
            foreach(var line in input)
            {
                var l= new Line(line);
                lines.Add(l);
                if (l.x0 > xmax) xmax = l.x0;
                if (l.y0 > ymax) ymax = l.y0;
                if (l.x1 > xmax) xmax = l.x1;
                if (l.y1 > ymax) ymax = l.y1;
            }
            var grid = new int[xmax+1, ymax+1];
            foreach(var line in lines)
            {
                if (line.x0 == line.x1)
                {
                    var s = Math.Sign(line.y1 - line.y0);
                    for (var y = line.y0; y != line.y1 + s; y += s)
                        grid[line.x0, y]++;
                }
                if (line.y0 == line.y1)
                {
                    var s = Math.Sign(line.x1 - line.x0);
                    for (var x = line.x0; x != line.x1 + s; x += s)
                        grid[x, line.y0]++;
                }
            }
            int count = 0;
            foreach (var v in grid)
                if (v > 1) count++;
            return count;
        }

        public static Int64 Day05b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day05.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day05a : {0}   Time: {1}", Day05a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day05b : {0}   Time: {1}", Day05b(lines), sw.ElapsedMilliseconds);
        }
    }
}
