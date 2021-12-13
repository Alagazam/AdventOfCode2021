using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day13Test
    {
        string input =
@"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

        [Fact]
        public void Day13a()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(17, Day13.Day13a(lines));
        }


        [Fact]
        public void Day13b()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(16, Day13.Day13b(lines));
        }

        public Day13Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
