using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day14Test
    {
        string input =
@"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

        [Fact]
        public void Day14a()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(1588, Day14.Day14a(lines));
        }


        [Fact]
        public void Day14b()
        {
            var lines = input.Split(Environment.NewLine);

            Assert.Equal(0, Day14.Day14b(lines));
        }

        public Day14Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
