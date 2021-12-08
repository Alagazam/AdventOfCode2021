using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day08
    {
        public static Int64 Day08a(string[] input)
        {
            int count = 0;
            foreach(var i in input)
            {
                var digits = i.Split(' ');
                foreach(var d in digits[11..])
                {
                    if (d.Length == 2 || d.Length == 3 || d.Length == 4 || d.Length == 7)
                        count++;
                }
            }
            return count;
        }

        public static string segDiff(string a, string b)
        {
            var diff = a.Except(b);
            return new string(diff.ToArray());
        }

        public static Int64 Day08b(string[] input)
        {
            int sum = 0;
            foreach (var i in input)
            {
                var patterns = new string[10];
                var digits = i.Split(' ');
                // First find 1,4,7,8
                foreach (var d in digits[0..10])
                {
                    if (d.Length == 2) patterns[1] = d;
                    else if (d.Length == 3) patterns[7] = d;
                    else if (d.Length == 4) patterns[4] = d;
                    else if (d.Length == 7) patterns[8] = d;
                }
                foreach (var d in digits[0..10])
                {
                    // 069 is 6 segs
                    if (d.Length == 6)
                    {
                        var diff1 = segDiff(patterns[1], d);
                        var diff4 = segDiff(patterns[4], d);
                        // 6 is missing one of segs in 1
                        if (diff1.Length == 1) patterns[6] = d;
                        // 9 is missing all segs in 4
                        else if (diff4.Length == 0) patterns[9] = d;
                        // it's a 0
                        else patterns[0] = d;
                    }
                }
                foreach (var d in digits[0..10])
                {
                    // 235 is 5 segs
                    if (d.Length == 5)
                    {
                        var diff9 = segDiff(d, patterns[9]);
                        var diff6 = segDiff(patterns[6], d);
                        // 2 is missing ond of segs in 9
                        if (diff9.Length == 1) patterns[2] = d;
                        // 6 is missing one segs in 5
                        else if (diff6.Length == 1) patterns[5] = d;
                        else patterns[3] = d;
                    }
                }
                var number = 0;
                foreach (var d in digits[11..])
                {
                    var index = 0;
                    foreach (var p in patterns)
                    {
                        var common = d.Intersect(p).Count();
                        if (common == d.Length && common == p.Length)
                        {
                            number = number * 10 + index;
                            break;
                        }
                        index++;
                    }
                }
                sum += number;
            }
            return sum;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day08.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day08a : {0}   Time: {1}", Day08a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day08b : {0}   Time: {1}", Day08b(lines), sw.ElapsedMilliseconds);
        }
    }
}
