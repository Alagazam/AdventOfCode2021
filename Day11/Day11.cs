using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day11
    {
        class Grid
        {
            public Grid(string[] input): this(input.Length, input[0].Length)
            {
                for (int i = 0; i != input.Length; i++)
                    for (int j = 0; j != input[i].Length; j++)
                        Set(i, j, input[i][j] - '0');
            }
            public Grid(int x, int y)
            {
                data = new int[x, y];
            }
            public void Set(int x, int y, int v)
            {
                data[x,y] = v;
            }

            public int Get(int x, int y)
            {
                return data[x, y];
            }

            public void inc(int x, int y)
            {
                data[x, y]++;
            }
            public void inc()
            {
                for (int i = 0; i != data.GetLength(0); i++)
                    for (int j = 0; j != data.GetLength(1); j++)
                        inc(i, j);
            }

            public void flash(int x, int y)
            {
                if (x > 0)
                {
                    if (y > 0 && data[x - 1, y - 1] != 10) data[x - 1, y - 1]++;
                    if (data[x - 1, y] != 10) data[x - 1, y]++;
                    if (y < data.GetLength(1) -1 && data[x - 1, y + 1] != 10) data[x - 1, y + 1]++;
                }
                if (y > 0 && data[x, y - 1] != 10) data[x, y - 1]++;
                data[x, y]++;
                if (y < data.GetLength(1) - 1 && data[x, y + 1] != 10) data[x, y + 1]++;
                if (x < data.GetLength(0) - 1)
                {
                    if (y > 0 && data[x + 1, y - 1] != 10) data[x + 1, y - 1]++;
                    if (data[x + 1, y] != 10) data[x + 1, y]++;
                    if (y < data.GetLength(1) - 1 && data[x + 1, y + 1] != 10) data[x + 1, y + 1]++;
                }
            }
            public int flash()
            {
                int count = 0;
                for (int i = 0; i != data.GetLength(0); i++)
                {
                    for (int j = 0; j != data.GetLength(1); j++)
                    {
                        if (Get(i, j) == 10)
                        {
                            count++;
                            flash(i, j);
                        }
                    }
                }
                return count;
            }

            public void clean()
            {
                for (int i = 0; i != data.GetLength(0); i++)
                    for (int j = 0; j != data.GetLength(1); j++)
                        if (Get(i, j) > 9) Set(i, j, 0);
            }

            int[,] data;
        }

        public static Int64 Day11a(string[] input, int steps)
        {
            var grid = new Grid(input);
            
            int count = 0;
            for (int step = 0; step != steps; step++)
            {
                grid.inc();

                bool flash = true;
                while (flash)
                {
                    flash = false;

                    var n = grid.flash();
                    if (n !=0)
                    { 
                        flash = true;
                        count+= n;
                    }
                }

                grid.clean();
            }

            return count;
        }

        public static Int64 Day11b(string[] input)
        {
            var grid = new Grid(input);

            int step = 0;
            for(; ;)
            {
                step++;
                grid.inc();
                int count = 0;
                bool flash = true;
                while (flash)
                {
                    flash = false;

                    var n = grid.flash();
                    if (n != 0)
                    {
                        flash = true;
                        count += n;
                    }
                }
                if (count == input.Length * input[0].Length) break;

                grid.clean();
            }

            return step;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day11.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day11a : {0}   Time: {1}", Day11a(lines, 100), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day11b : {0}   Time: {1}", Day11b(lines), sw.ElapsedMilliseconds);
        }
    }
}
