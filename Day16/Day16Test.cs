using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day16Test
    {
        string input00 = @"D2FE28";
        string input01 = @"38006F45291200";
        string input02 = @"EE00D40C823060";
        string input1 = @"8A004A801A8002F478";
        string input2 = @"620080001611562C8802118E34";
        string input3 = @"C0015000016115A2E0802F182340";
        string input4 = @"A0016C880162017C3686B18A3D4780";

        [Fact]
        public void GetBits()
        {
            Assert.Equal(6u, Day16.GetBits("D2FE28", 0, 3));
            Assert.Equal(4u, Day16.GetBits("D2FE28", 3, 3));
            Assert.Equal(1u, Day16.GetBits("D2FE28", 6, 1));
            Assert.Equal(7u, Day16.GetBits("D2FE28", 7, 4));

            Assert.Equal(27u, Day16.GetBits("38006F45291200", 7, 15));
        }

        [Fact]
        public void Day16a00()
        {
            var lines = input00.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(6u, Day16.Day16a(lines));
        }

        [Fact]
        public void Day16a01()
        {

            var lines = input01.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(1u + 6u + 2u, Day16.Day16a(lines));
        }

        [Fact]
        public void Day16a02()
        {

            var lines = input02.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(7u + 2u + 4u + 1u, Day16.Day16a(lines));
        }

        [Fact]
        public void Day16a()
        {

            var lines = input1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(16u, Day16.Day16a(lines));

            lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(12u, Day16.Day16a(lines));

            lines = input3.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(23u, Day16.Day16a(lines));

            lines = input4.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(31u, Day16.Day16a(lines));
        }


        [Fact]
        public void Day16b()
        {
            //var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            //Assert.Equal(0, Day16.Day16b(lines));
        }

        public Day16Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
