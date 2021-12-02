using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day02
    {
        public static UInt64 Day02a(string[] input)
        {
            UInt64 x = 0;
            UInt64 d = 0;

            foreach (var c in input)
            {
                if (c.StartsWith("up"))
                {
                    d -= UInt64.Parse(c.Substring(3));
                }
                if (c.StartsWith("down"))
                {
                    d += UInt64.Parse(c.Substring(5));
                }
                if (c.StartsWith("forward"))
                {
                    x += UInt64.Parse(c.Substring(8));
                }

            }
            return x*d;
        }

        public static UInt64 Day02b(string[] input)
        {
            UInt64 x = 0;
            UInt64 d = 0;
            UInt64 aim = 0;

            foreach (var c in input)
            {
                if (c.StartsWith("up"))
                {
                    aim -= UInt64.Parse(c.Substring(3));
                }
                if (c.StartsWith("down"))
                {
                    aim += UInt64.Parse(c.Substring(5));
                }
                if (c.StartsWith("forward"))
                {
                    var fw = UInt64.Parse(c.Substring(8));
                    d += aim * fw;
                    x += fw;
                }

            }
            return x * d;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day02.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day02a : {0}   Time: {1}", Day02a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day02b : {0}   Time: {1}", Day02b(lines), sw.ElapsedMilliseconds);
        }
    }
}
