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
        public void Day16b1()
        {
            var lines = "C200B40A82".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(3l, Day16.Day16b(lines));

            lines = "C2007410".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(2l, Day16.Day16b(lines));

            lines = "C200F40A83504".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(6l, Day16.Day16b(lines));
        }
        [Fact]
        public void Day16b2()
        {
            var lines = "04005AC33890".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(54l, Day16.Day16b(lines));

            lines = "C6007410".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(2l, Day16.Day16b(lines));

            lines = "C600F40A83504".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(6l, Day16.Day16b(lines));
        }
        [Fact]
        public void Day16b3()
        {
            var lines = "880086C3E88112".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(7l, Day16.Day16b(lines));

            lines = "CA007410".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(2l, Day16.Day16b(lines));

            lines = "CA00F40A83504".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(1l, Day16.Day16b(lines));
        }
        [Fact]
        public void Day16b4()
        {
            var lines = "CE00C43D881120".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(9l, Day16.Day16b(lines));

            lines = "CE007410".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(2l, Day16.Day16b(lines));

            lines = "CE00F40A83504".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(3l, Day16.Day16b(lines));
        }
        [Fact]
        public void Day16b5()
        {
            var lines = "D8005AC2A8F0".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(1l, Day16.Day16b(lines));
        }
        [Fact]
        public void Day16b6()
        {
            var lines = "F600BC2D8F".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(0l, Day16.Day16b(lines));
        }
        [Fact]
        public void Day16b7()
        {
            var lines = "9C005AC2F8F0".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(0l, Day16.Day16b(lines));
        }
        [Fact]
        public void Day16b8()
        {
            var lines = "9C0141080250320F1802104A08".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(1l, Day16.Day16b(lines));
        }

        public Day16Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
