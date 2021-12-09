using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day09
    {
        public static Int64 Day09a(string[] input)
        {
            int riskLevel = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for(int j = 0; j < input[i].Length; j++)
                {
                    if (i > 0 && input[i][j] >= input[i - 1][j]) continue;
                    if (i < input.Length - 1 && input[i][j] >= input[i + 1][j]) continue;
                    if (j > 0 && input[i][j] >= input[i][j - 1]) continue;
                    if (j < input[i].Length - 1 && input[i][j] >= input[i][j + 1]) continue;
                    riskLevel += input[i][j] - '0' + 1;
                }
            }
            return riskLevel;
        }

        public static Int64 Day09b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day09.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day09a : {0}   Time: {1}", Day09a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day09b : {0}   Time: {1}", Day09b(lines), sw.ElapsedMilliseconds);
        }
    }
}
