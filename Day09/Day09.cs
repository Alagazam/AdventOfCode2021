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
            var lowpoints = new List<int[]>();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (i > 0 && input[i][j] >= input[i - 1][j]) continue;
                    if (i < input.Length - 1 && input[i][j] >= input[i + 1][j]) continue;
                    if (j > 0 && input[i][j] >= input[i][j - 1]) continue;
                    if (j < input[i].Length - 1 && input[i][j] >= input[i][j + 1]) continue;
                    
                    lowpoints.Add(new int[] { i, j, 0 });
                }
            }

            var temp = new char[input.Length][];
            for (int i= 0; i != input.Length; i++) temp[i] = input[i].ToCharArray();

            foreach (var l in lowpoints)
            {
                var s = new Stack<int[]>();
                s.Push(new int[] { l[0], l[1] });

                while (s.Count > 0)
                {
                    var pos = s.Pop();
                    var i = pos[0];
                    var j = pos[1];
                    if (temp[i][j] != ' ')
                    {
                        temp[i][j] = ' ';
                        l[2]++;
                    }
                    if (i > 0 && temp[i - 1][j] != '9' && temp[i - 1][j] != ' ') s.Push(new int[] { i - 1, j });
                    if (i < input.Length - 1 && temp[i + 1][j] != '9' && temp[i + 1][j] != ' ') s.Push(new int[] { i + 1, j });
                    if (j > 0 && temp[i][j -1] != '9' && temp[i][j - 1] != ' ') s.Push(new int[] { i, j - 1 });
                    if (j < input[i].Length - 1 && temp[i][j + 1] != '9' && temp[i][j + 1] != ' ') s.Push(new int[] { i, j + 1 });
                }
            }
            lowpoints.Sort((a, b) => Math.Sign(b[2] - a[2]));
            return lowpoints[0][2] * lowpoints[1][2] * lowpoints[2][2];
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
