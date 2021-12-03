using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day03Test
    {
        string input =
@"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

        [Fact]
        public void Day03a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(198, Day03.Day03a(lines));
        }


        [Fact]
        public void Day03b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(230, Day03.Day03b(lines));
        }

        public Day03Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
