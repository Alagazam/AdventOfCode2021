using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day07Test
    {
        string input =
@"16,1,2,0,4,2,7,1,2,14";

        [Fact]
        public void Day07a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(37, Day07.Day07a(lines));
        }


        [Fact]
        public void Day07b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(168, Day07.Day07b(lines));
        }

        public Day07Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
