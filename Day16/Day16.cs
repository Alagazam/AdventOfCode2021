using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day16
    {
        public static UInt64 GetBits(string s, uint start, int num)
        {
            UInt64 bits = 0;
            for (int i = (int)start; i < start + num; i++)
            {
                int charIndex = i / 4;
                var c = s[charIndex];
                var b = Convert.ToUInt32("" + c, 16);
                b = b >> 3 - (i % 4);
                b &= 1;
                bits = bits << 1 | b;
            }

            return bits;
        }

        public static UInt64 DecodeLiteral(string s, ref uint index, ref UInt64 verSum)
        {
            var value = 0ul;
            bool last;
            do
            {
                last = (GetBits(s, index++, 1) == 0);
                value = (value << 4);
                value += GetBits(s, index, 4);
                index += 4;
            } while (!last);
            return value;
        }

        public static UInt64 DecodeOperator(string s, ref uint index, ref UInt64 verSum)
        {
            var value = 0ul;
            var lengthTypeId = GetBits(s, index++, 1);
            if (lengthTypeId == 0)
            {
                var length = GetBits(s, index, 15);
                index += 15;
                var start = index;
                while (index < start + length)
                {
                    Decode(s, ref index, ref verSum);
                }
            }
            else
            {
                var packets = GetBits(s, index, 11);
                index += 11;
                for (uint i = 0; i != packets; i++)
                {
                    Decode(s, ref index, ref verSum);
                }
            }
            return value;
        }

        public static UInt64 Decode(string s, ref uint index, ref UInt64 verSum)
        {
            var ver = GetBits(s, index, 3);
            verSum += ver;
            index += 3;
            var type = GetBits(s, index, 3);
            index += 3;
            if (type == 4)
            {
                var value = DecodeLiteral(s, ref index, ref verSum);
            }
            else
            {
                DecodeOperator(s, ref index, ref verSum);
            }
            return verSum;
        }


        public static UInt64 Day16a(string[] input)
        {
            var sum = 0ul;
            var index = 0u;
            var s = input[0];
            while (index < s.Length * 4 - 8)
            {
                Decode(s, ref index, ref sum);
            }

            return sum;
        }

        public static Int64 Day16b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day16.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day16a : {0}   Time: {1}", Day16a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day16b : {0}   Time: {1}", Day16b(lines), sw.ElapsedMilliseconds);
        }
    }
}
