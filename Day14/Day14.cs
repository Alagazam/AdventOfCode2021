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
            var dict = new Dictionary<string, string>();
            foreach (var line in input)
            {
                var parts = line.Split(' ');
                if (parts.Length == 3)
                    dict.Add(parts[0], parts[2]);
            }
            var pairs = new Dictionary<string, Int64>();
            for (var i = 0; i < input[0].Length - 1; i++)
            {
                var s = input[0].Substring(i, 2);
                if (!pairs.ContainsKey(s)) pairs.Add(s, 0);
                pairs[s]++;
            }

            foreach (var n in Enumerable.Range(0, 40))
            {
                var newPairs = new Dictionary<string, Int64>();
                foreach (var p in pairs)
                {
                    var s1 = p.Key[0] + dict[p.Key];
                    var s2 = dict[p.Key] + p.Key[1];
                    if (!newPairs.ContainsKey(s1)) newPairs.Add(s1, 0);
                    if (!newPairs.ContainsKey(s2)) newPairs.Add(s2, 0);
                    newPairs[s1] += p.Value;
                    newPairs[s2] += p.Value;
                }
                pairs = newPairs;
            }

            var freq = new Int64['Z' - 'A'];
            foreach (var p in pairs)
            {
                freq[p.Key[0] - 'A']+=p.Value;
            }
            freq[input[0][^1] - 'A'] ++;
            var max = freq.Max();
            var min = freq.Where(n => n > 0).Min();

            return max - min;

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
