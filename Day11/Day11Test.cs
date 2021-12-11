using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day11Test
    {
        string input =
@"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

        string inputSmall =
@"11111
19991
19191
19991
11111";

        [Fact]
        public void Day11a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(0, Day11.Day11a(lines, 1));
            Assert.Equal(35, Day11.Day11a(lines, 2));
            Assert.Equal(35 + 45, Day11.Day11a(lines, 3));
            Assert.Equal(35 + 45 + 16, Day11.Day11a(lines, 4));
            Assert.Equal(35 + 45 + 16 + 8, Day11.Day11a(lines, 5));
            Assert.Equal(35 + 45 + 16 + 8 + 1, Day11.Day11a(lines, 6));
            Assert.Equal(35 + 45 + 16 + 8 + 1 + 7, Day11.Day11a(lines, 7));
            Assert.Equal(35 + 45 + 16 + 8 + 1 + 7 + 24, Day11.Day11a(lines, 8));
            Assert.Equal(35 + 45 + 16 + 8 + 1 + 7 + 24 + 39, Day11.Day11a(lines, 9));

            Assert.Equal(204, Day11.Day11a(lines, 10));
            Assert.Equal(1656, Day11.Day11a(lines, 100));
        }
        [Fact]
        public void Day11aSmall()
        {
            var lines = inputSmall.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(9, Day11.Day11a(lines, 1));
            Assert.Equal(9, Day11.Day11a(lines, 2));
        }


        [Fact]
        public void Day11b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(195, Day11.Day11b(lines));
        }

        public Day11Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
