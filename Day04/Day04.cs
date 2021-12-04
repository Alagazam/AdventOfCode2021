using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2020
{
    public class Day04
    {
        class board
        {
            public board()
            {
            }
            public board(string[] input, int line)
            {
                foreach (int x in Enumerable.Range(0, 5))
                {
                    var row = input[line + x];
                    foreach (int y in Enumerable.Range(0, 5))
                    {
                        numbers[x, y] = Int32.Parse(row.Substring(y*3,2));
                    }
                }
            }
            public void draw(int d)
            {
                foreach (int x in Enumerable.Range(0, 5))
                {
                    foreach (int y in Enumerable.Range(0, 5))
                    {
                        if (numbers[x, y] == d)
                            numbers[x, y] = -1;
                    }
                }
            }
            public bool check()
            {
                // Check rows
                bool win = true;
                foreach (int i in Enumerable.Range(0, 5))
                {
                    win = true;
                    foreach (int j in Enumerable.Range(0, 5))
                    {
                        if (numbers[i, j] != -1)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win) return true;
                }
                win = true;
                foreach (int i in Enumerable.Range(0, 5))
                {
                    win = true;
                    foreach (int j in Enumerable.Range(0, 5))
                    {
                        if (numbers[j, i] != -1)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win) return true;
                }
                //win = true;
                //foreach (int i in Enumerable.Range(0, 5))
                //{
                //    if (numbers[i, i] != -1)
                //    {
                //        win = false;
                //        break;
                //    }
                //}
                //if (win) return true;
                //win = true;
                //foreach (int i in Enumerable.Range(0, 5))
                //{
                //    if (numbers[i, 4-i] != -1)
                //    {
                //        win = false;
                //        break;
                //    }
                //}
                //if (win) return true;

                return false;
            }
            public int sum()
            {
                int sum = 0;
                foreach (var n in numbers)
                {
                    if (n != -1) sum += n;
                }
                return sum;
            }

            int[,] numbers = new int[5, 5];
        }

        public static Int64 Day04a(string[] input)
        {
            var draw = input[0].Split(',');
            var boards = new List<board>();

            var row = 2;
            while (row < input.Length)
            {
                boards.Add(new board(input, row));
                row += 6;
            }
            bool win = false;
            int round = 0;
            board bWin = new board();
            while (!win)
            {
                foreach(var b in boards)
                {
                    b.draw(Int32.Parse(draw[round]));
                    win = b.check();
                    if (win)
                    {
                        bWin = b;
                        break;
                    }
                }
                round++;
            }
            return bWin.sum()* Int32.Parse(draw[round-1]);
        }

        public static Int64 Day04b(string[] input)
        {
            var draw = input[0].Split(',');
            var boards = new List<board>();

            var row = 2;
            while (row < input.Length)
            {
                boards.Add(new board(input, row));
                row += 6;
            }
            int round = 0;
            board bWin = new board();
            while (boards.Count>1)
            {
                var wins = new List<board>();

                foreach (var b in boards)
                {
                    b.draw(Int32.Parse(draw[round]));
                }
                boards.RemoveAll(b => b.check());

                round++;
            }
            boards.First().draw(Int32.Parse(draw[round]));
            return boards.First().sum() * Int32.Parse(draw[round]);
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day04.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day04a : {0}   Time: {1}", Day04a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day04b : {0}   Time: {1}", Day04b(lines), sw.ElapsedMilliseconds);
        }
    }
}
