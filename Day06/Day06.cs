using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day06
    {
        public static Int64 Day06a(string[] input, int days)
        {
            return CalcFish(input, days);
        }

        private static Int64 CalcFish(string[] input, int days)
        {
            Int64[] fish = new Int64[10];
            var fishes = input[0].Split(',');
            foreach (var i in fishes)
            {
                fish[Int64.Parse(i)]++;
            }
            foreach (var i in Enumerable.Range(0, days))
            {
                fish[9] = fish[0];
                fish[7] += fish[0];
                foreach (var timer in Enumerable.Range(0, fish.Count() - 1))
                {
                    fish[timer] = fish[timer + 1];
                }
                fish[9] = 0;
            }
            return fish.Sum();
        }

        public static Int64 Day06b(string[] input)
        {
            return CalcFish(input, 256);
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day06.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day06a : {0}   Time: {1}", Day06a(lines,80), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day06b : {0}   Time: {1}", Day06b(lines), sw.ElapsedMilliseconds);
        }
    }
}
