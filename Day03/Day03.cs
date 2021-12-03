using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day03
    {
        private static int[] CountBits(IEnumerable<string> input)
        {
            int[] bits = new int[input.First().Length];

            foreach (var i in input)
            {
                var bitNo = 0;
                foreach (var bit in i)
                {
                    if (bit == '1')
                        bits[bitNo]++;
                    bitNo++;
                }
            }
            return bits;
        }

        public static Int64 Day03a(string[] input)
        {
            var bits = CountBits(input);

            var gamma = 0;
            var epsilon = 0;
            foreach (var bitCount in bits)
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

            return gamma * epsilon;
        }

        public static Int64 Day03b(string[] input)
        {
            var oxyList = input.ToList();
            var co2List = input.ToList();

            var step = 0;
            while (oxyList.Count > 1)
            {
                var bits = CountBits(oxyList);
                var filterBit = '0';
                if (bits[step] < oxyList.Count / 2.0)
                    filterBit = '1';
                oxyList.RemoveAll(i => i[step] == filterBit);
                step++;
            }
            step = 0;
            while (co2List.Count > 1)
            {
                var bits = CountBits(co2List);
                var filterBit = '0';
                if (bits[step] >= co2List.Count / 2.0)
                    filterBit = '1';
                co2List.RemoveAll(i => i[step] == filterBit);
                step++;
            }
            var oxyRate = Convert.ToInt32(oxyList.First(), 2);
            var co2Rate = Convert.ToInt32(co2List.First(), 2);

            return oxyRate * co2Rate;
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
