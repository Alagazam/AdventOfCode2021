using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day10
    {
        public static Int64 Day10a(string[] input)
        {
            int score = 0;
            foreach (var row in input)
            {
                var s = new Stack<char>();
                bool corrupted = false;

                foreach(var c in row)
                {
                    switch (c)
                    {
                        case '(':
                        case '[':
                        case '{':
                        case '<':
                            s.Push(c);
                            break;
                        case ')':
                            if (s.Peek() == '(') s.Pop();
                            else { score += 3; corrupted = true; }
                            break;
                        case ']':
                            if (s.Peek() == '[') s.Pop();
                            else { score += 57; corrupted = true; }
                            break;
                        case '}':
                            if (s.Peek() == '{') s.Pop();
                            else { score += 1197; corrupted = true; }
                            break;
                        case '>':
                            if (s.Peek() == '<') s.Pop();
                            else { score += 25137; corrupted = true; }
                            break;
                    }

                    if (corrupted) break;
                }

            }
            return score;
        }

        public static Int64 Day10b(string[] input)
        {
            var scores = new List<Int64>();
            foreach (var row in input)
            {
                var s = new Stack<char>();
                bool corrupted = false;

                foreach (var c in row)
                {
                    switch (c)
                    {
                        case '(':
                        case '[':
                        case '{':
                        case '<':
                            s.Push(c);
                            break;
                        case ')':
                            if (s.Peek() == '(') s.Pop();
                            else corrupted = true;
                            break;
                        case ']':
                            if (s.Peek() == '[') s.Pop();
                            else corrupted = true;
                            break;
                        case '}':
                            if (s.Peek() == '{') s.Pop();
                            else corrupted = true;
                            break;
                        case '>':
                            if (s.Peek() == '<') s.Pop();
                            else corrupted = true;
                            break;
                    }

                    if (corrupted) break;
                }
                if (!corrupted)
                {
                    Int64 score = 0;
                    while (s.Count > 0)
                    {
                        var c = s.Pop();
                        switch (c)
                        {
                            case '(':
                                score = score * 5 + 1; break;
                            case '[':
                                score = score * 5 + 2; break;
                            case '{':
                                score = score * 5 + 3; break;
                            case '<':
                                score = score * 5 + 4; break;
                        }
                    }
                    scores.Add(score);
                }
            }
            scores.Sort();
            return scores[scores.Count/2];
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day10.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day10a : {0}   Time: {1}", Day10a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day10b : {0}   Time: {1}", Day10b(lines), sw.ElapsedMilliseconds);
        }
    }
}
