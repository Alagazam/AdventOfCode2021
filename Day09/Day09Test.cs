using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day09Test
    {
        string input =
@"2199943210
3987894921
9856789892
8767896789
9899965678";

        [Fact]
        public void Day09a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(15, Day09.Day09a(lines));
        }


        [Fact]
        public void Day09b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(0, Day09.Day09b(lines));
        }

        public Day09Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
