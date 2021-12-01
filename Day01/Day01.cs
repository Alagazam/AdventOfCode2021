using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day01
    {
        public static UInt64 Day01a(string[] input)
        {
            UInt64 last = 0;
            UInt64 inc = 0;
            foreach(var i in input)
            {
                var depth = UInt64.Parse(i);
                if (depth > last)
                {
                    inc++;
                }
                last = depth;
            }
            return inc-1;
        }

        public static UInt64 Day01b(string[] input)
        {
            UInt64 first = 0;
            UInt64 second= 0;
            UInt64 third = 0;

            UInt64 last = 0;
            UInt64 inc = 0;

            foreach (var i in input)
            {
                first = second;
                second = third;
                third = UInt64.Parse(i);
                var depth = first + second + third;
                
                if (depth > last)
                {
                    inc++;
                }
                last = depth;
            }
            return inc-3;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day01.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day01a : {0}   Time: {1}", Day01a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day01b : {0}   Time: {1}", Day01b(lines), sw.ElapsedMilliseconds);
        }
    }
}
