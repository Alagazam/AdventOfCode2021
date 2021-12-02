using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day02Test
    {
        string input =
@"forward 5
down 5
forward 8
up 3
down 8
forward 2";

        [Fact]
        public void Day02a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(150u, Day02.Day02a(lines));
        }


        [Fact]
        public void Day02b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(900u, Day02.Day02b(lines));
        }

        public Day02Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
