using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day12
    {
        static int paths = 0;
        static Stack<string> visited = new Stack<string>();
        static Dictionary<string, List<string>> nodes = new Dictionary<string, List<string>>();

        static bool visit(string n, bool smallCaveTwice = false)
        {
            visited.Push(n);
            if (n == "end")
            {
                paths++;
                foreach (var v in visited) Console.Write(v + "-");
                Console.WriteLine();
                visited.Pop();
                return true;
            }
            bool deadend = true;
            foreach (var l in nodes[n])
            {
                if (l == "start") continue;

                if (l == l.ToLower() && visited.Contains(l) && !smallCaveTwice) continue;

                if (smallCaveTwice && l == l.ToLower() && visited.Count( i => i == l) == 1)
                {
                    if (visit(l, false))
                        deadend = false;
                }
                else if (visit(l, smallCaveTwice))
                    deadend = false;
            }
            visited.Pop();
            return deadend;
        }

        public static Int64 Day12a(string[] input)
        {
            paths = 0;
            visited = new Stack<string>();
            nodes = new Dictionary<string, List<string>>();

            foreach (var link in input)
            {
                if (link == "") break;
                var l = link.Split('-');
                if (!nodes.ContainsKey(l[0])) nodes[l[0]] = new List<string>();
                if (!nodes.ContainsKey(l[1])) nodes[l[1]] = new List<string>();
                nodes[l[0]].Add(l[1]);
                nodes[l[1]].Add(l[0]);
            }
            visit("start");
            return paths;
        }

        public static Int64 Day12b(string[] input)
        {
            paths = 0;
            visited = new Stack<string>();
            nodes = new Dictionary<string, List<string>>();

            foreach (var link in input)
            {
                if (link == "") break;
                var l = link.Split('-');
                if (!nodes.ContainsKey(l[0])) nodes[l[0]] = new List<string>();
                if (!nodes.ContainsKey(l[1])) nodes[l[1]] = new List<string>();
                nodes[l[0]].Add(l[1]);
                nodes[l[1]].Add(l[0]);
            }
            visit("start", true);
            return paths;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day12.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day12a : {0}   Time: {1}", Day12a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day12b : {0}   Time: {1}", Day12b(lines), sw.ElapsedMilliseconds);
        }
    }
}
