using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day06Test
    {
        string input =
@"3,4,3,1,2";

        [Fact]
        public void Day06a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(26, Day06.Day06a(lines, 18));

            Assert.Equal(5934, Day06.Day06a(lines, 80));
        }


        [Fact]
        public void Day06b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(26984457539, Day06.Day06b(lines));
        }

        public Day06Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
