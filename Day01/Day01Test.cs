using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day01Test
    {
        string input =
@"199
200
208
210
200
207
240
269
260
263";

        [Fact]
        public void Day01a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(7u, Day01.Day01a(lines));
        }


        [Fact]
        public void Day01b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(5u, Day01.Day01b(lines));
        }

        public Day01Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
