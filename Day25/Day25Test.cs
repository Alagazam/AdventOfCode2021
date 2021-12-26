using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day25Test
    {
        string input =
@"v...>>.vv>
.vv>>.vv..
>>.>v>...v
>>v>>.>.v.
v>v.vv.v..
>.>>..v...
.vv..>.>v.
v.v..>>v.v
....v..v.>";

        [Fact]
        public void Day25a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(58, Day25.Day25a(lines));
        }


        public Day25Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
