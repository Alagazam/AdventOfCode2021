using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day21
    {
        static int diceVal(int dice) { return dice % 100 + 1; }
        public static Int64 Day21a(string[] input)
        {
            var diceRoll = 0;
            var player1pos = Int32.Parse(input[0].Split(' ')[4]) - 1;
            var player1score = 0;
            var player2pos = Int32.Parse(input[1].Split(' ')[4]) - 1;
            var player2score = 0;

            var res = 0;
            while (true)
            {
                player1pos = (player1pos + diceVal(diceRoll) + diceVal(diceRoll+1) + diceVal(diceRoll+2) ) % 10;
                player1score += player1pos + 1;
                diceRoll += 3;
                if (player1score >= 1000)
                {
                    res = player2score * diceRoll;
                    break;
                }
                player2pos = (player2pos + diceVal(diceRoll) + diceVal(diceRoll + 1) + diceVal(diceRoll + 2)) % 10;
                player2score += player2pos + 1;
                diceRoll += 3;
                if (player2score >= 1000)
                {
                    res = player1score * diceRoll;
                    break;
                }
            }

            return res;
        }

        public static Int64 Day21b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day21.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day21a : {0}   Time: {1}", Day21a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day21b : {0}   Time: {1}", Day21b(lines), sw.ElapsedMilliseconds);
        }
    }
}
