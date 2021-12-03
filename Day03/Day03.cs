using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day03
    {
        public static Int64 Day03a(string[] input)
        {
            List<int> bits = new List<int>(input[0].Length);
            foreach(var i in input[0]) bits.Add(0);

            foreach (var i in input)
            {
                var bitNo = 0;
                foreach(var bit in i)
                {
                    if (bit == '0')
                        bits[bitNo]++;
                    bitNo++;
                }
            }

            var gamma = 0;
            var epsilon = 0;
            foreach(var bitCount in bits)
            {
                gamma = gamma * 2;
                epsilon = epsilon * 2;
                if (bitCount > input.Length / 2)
                {
                    gamma++;
                }
                else
                {
                    epsilon++;
                }
            }

            return gamma*epsilon;
        }

        public static Int64 Day03b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day03.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day03a : {0}   Time: {1}", Day03a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day03b : {0}   Time: {1}", Day03b(lines), sw.ElapsedMilliseconds);
        }
    }
}
