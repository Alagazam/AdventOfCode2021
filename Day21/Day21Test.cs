using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day21Test
    {
        string input =
@"Player 1 starting position: 4
Player 2 starting position: 8";

        [Fact]
        public void Day21a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(739785, Day21.Day21a(lines));
        }


        [Fact]
        public void Day21b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(0, Day21.Day21b(lines));
        }

        public Day21Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
