using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day14
    {
        public static Int64 Day14a(string[] input)
        {
            var dict = new Dictionary<string, string>();
            foreach(var line in input)
            {
                var parts = line.Split(' ');
                if (parts.Length == 3)
                    dict.Add(parts[0], parts[2]);
            }

            var template = input[0];
            foreach (var n in Enumerable.Range(0, 10))
            {
                string output = "";
                for (var i = 0; i < template.Length-1; i++)
                {
                    output += template[i] + dict[template.Substring(i, 2)];
                }
                output += template[template.Length - 1];
                template = output;
            }

            var freq = new int['Z' - 'A'];
            foreach(var c in template)
            {
                freq[c - 'A']++;
            }
            var max = freq.Max();
            var min = freq.Where( n => n > 0).Min();

            return max - min;
        }

        public static Int64 Day14b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day14.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day14a : {0}   Time: {1}", Day14a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day14b : {0}   Time: {1}", Day14b(lines), sw.ElapsedMilliseconds);
        }
    }
}
