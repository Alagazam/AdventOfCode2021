using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day16
    {
        static int Depth = 0;
        public static Int64 GetBits(string s, int start, int num)
        {
            Int64 bits = 0;
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

        public static Int64 DecodeLiteral(string s, ref int index, ref Int64 verSum)
        {
            var value = 0l;
            bool last;
            do
            {
                last = (GetBits(s, index++, 1) == 0);
                value = (value << 4);
                value += GetBits(s, index, 4);
                index += 4;
            } while (!last);
            //Console.WriteLine("{1} literal {0}", value, new string('\t', Depth));
            return value;
        }

        public static string Op(Int64 type)
        {
            switch (type)
            {
                case 0:
                    return "+";
                case 1:
                    return "*";
                case 2:
                    return "Min";
                case 3:
                    return "Max";
                case 5:
                    return ">";
                case 6:
                    return "<";
                case 7:
                    return "==";
            }
            return "Unknown";

        }
        public static Int64 Calc(Int64 type, IEnumerable<Int64> values)
        {
            switch (type)
            {
            case 0:
                return values.Sum();
            case 1:
                var p = 1l;
                foreach (var v in values) p = p * v;
                return p;
            case 2:
                return values.Min();
            case 3:
                return values.Max();
            case 5:
                return (values.First() > values.Last() ? 1 : 0);
            case 6:
                return (values.First() < values.Last() ? 1 : 0);
            case 7:
                return (values.First() == values.Last() ? 1 : 0);
            }
            return 0;
        }

        public static Int64 DecodeOperator(string s, ref int index, ref Int64 verSum, Int64 type)
        {
            var lengthTypeId = GetBits(s, index++, 1);
            var subPackets = new List<Int64>();
            if (lengthTypeId == 0)
            {
                var length = GetBits(s, index, 15);
                index += 15;
                //Console.WriteLine("{1} Op: {0} : {2} bits", Op(type), new string('\t', Depth), length);
                var start = index;
                while (index < start + length)
                {
                    var v = Decode(s, ref index, ref verSum);
                    subPackets.Add(v);
                }
            }
            else
            {
                var packets = GetBits(s, index, 11);
                index += 11;
                //Console.WriteLine("{1} Op: {0} : {2} packets", Op(type), new string('\t', Depth), packets);
                for (uint i = 0; i != packets; i++)
                {
                    var v = Decode(s, ref index, ref verSum);
                    subPackets.Add(v);
                }
            }
            var value = Calc(type, subPackets);

            //Console.WriteLine("{1} Op: {0} : Res {2}", Op(type), new string('\t', Depth), value);
            return value;
        }

        public static Int64 Decode(string s, ref int index, ref Int64 verSum)
        {
            Depth++;
            var ver = GetBits(s, index, 3);
            verSum += ver;
            index += 3;
            var type = GetBits(s, index, 3);
            index += 3;
            //Console.WriteLine("{2} Ver: {0} : Type {1}", ver, type, new string('\t', Depth));
            var value = 0l;
            if (type == 4)
            {
                value = DecodeLiteral(s, ref index, ref verSum);
            }
            else
            {
                value = DecodeOperator(s, ref index, ref verSum, type);
            }
            Depth--;
            return value;
        }


        public static Int64 Day16a(string[] input)
        {
            var sum = 0l;
            var index = 0;
            var s = input[0];

            Decode(s, ref index, ref sum);

            return sum;
        }

        public static Int64 Day16b(string[] input)
        {
            var sum = 0l;
            var index = 0;
            var s = input[0];

            return Decode(s, ref index, ref sum);
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
