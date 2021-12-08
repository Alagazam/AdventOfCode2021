using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day08Test
    {
        string input =
@"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce
";

        [Fact]
        public void Day08a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(26, Day08.Day08a(lines));
        }


        string input2 =
@"acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";

        [Fact]
        public void Day08b_small()
        {
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(5353, Day08.Day08b(lines));
        }

        [Fact]
        public void Day08b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(61229, Day08.Day08b(lines));
        }

        public Day08Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
