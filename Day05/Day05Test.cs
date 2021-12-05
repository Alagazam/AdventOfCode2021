using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day05Test
    {
        string input =
@"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

        [Fact]
        public void Day05a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(5, Day05.Day05a(lines));
        }


        [Fact]
        public void Day05b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(12, Day05.Day05b(lines));
        }

        public Day05Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
