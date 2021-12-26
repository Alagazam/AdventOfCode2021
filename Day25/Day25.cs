using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day25
    {
        public static void printgrid(char[,] grid)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                    Console.Write(grid[x, y]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static Int64 Day25a(string[] input)
        {
            var grid = new char[input[0].Length + 1, input.Length + 1];
            for (int y = 0; y < input.Length; y++)
                for (int x = 0; x < input[0].Length; x++)
                    grid[x, y] = input[y % input.Length][x % input[0].Length];

            bool move = true;
            int round = 0;
            while (move)
            {
                round++;
                move = false;

                for (int y = 0; y < input.Length; y++)
                {
                    grid[input[0].Length, y] = grid[0, y];
                }
                for (int y = 0; y < input.Length; y++)
                {
                    for (int x = 0; x < input[0].Length; x++)
                    {
                        if (grid[x, y] == '>' && grid[x + 1, y] == '.')
                        {
                            grid[x, y] = '.';
                            grid[(x + 1) % input[0].Length, y] = '>';
                            x++;
                            move = true;
                        }
                    }
                }
                for (int y = 0; y < input.Length; y++)
                {
                    grid[input[0].Length, y] = ' ';
                }

                for (int x = 0; x < input[0].Length; x++)
                {
                    grid[x, input.Length] = grid[x, 0];
                }
                for (int x = 0; x < input[0].Length; x++)
                {
                    for (int y = 0; y < input.Length; y++)
                {
                        if (grid[x, y] == 'v' && grid[x, y + 1] == '.')
                        {
                            grid[x, y] = '.';
                            grid[x, (y + 1) % input.Length] = 'v';
                            y++;
                            move = true;
                        }
                    }
                }
                for (int x = 0; x < input[0].Length; x++)
                {
                    grid[x, input.Length] = ' ';
                }
                //printgrid(grid);
            }
            return round;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day25.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day25a : {0}   Time: {1}", Day25a(lines), sw.ElapsedMilliseconds);
        }
    }
}
