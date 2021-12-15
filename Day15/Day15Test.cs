using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day15Test
    {
        string input =
@"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";

        [Fact]
        public void Day15a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(40, Day15.Day15a(lines));
        }


        [Fact]
        public void Day15b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(315, Day15.Day15b(lines));
        }

        public Day15Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
