using System;
using Xunit;
using Xunit.Abstractions;

namespace AoC2020
{
    public class Day12Test
    {
        string input0 =
@"start-b
b-end";
        string input01 =
@"start-A
A-end";
        string input02 =
@"start-A
A-b
A-end";
        string input03 =
@"start-a
a-b
a-end";
        string input04 =
@"start-a
start-b
b-end
a-end";
        string input05 =
@"start-a
start-b
b-c
b-end
a-end";
        string input06 =
@"start-a
start-B
B-c
B-end
a-end";
        string input07 =
@"start-A
start-b
A-b
A-end
b-end";
        string input08 =
@"start-A
A-b
A-c
A-end";

        string input =
@"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

        string input2 =
@"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

        string input3 =
@"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

        [Fact]
        public void Day12a0()
        {
            var lines = input0.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(1, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a01()
        {
            var lines = input01.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(1, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a02()
        {
            var lines = input02.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(2, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a03()
        {
            var lines = input03.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(1, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a04()
        {
            var lines = input04.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(2, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a05()
        {
            var lines = input05.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(2, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a06()
        {
            var lines = input06.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(3, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a07()
        {
            var lines = input07.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(5, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a08()
        {
            var lines = input08.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(5, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(10, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a2()
        {
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(19, Day12.Day12a(lines));
        }
        [Fact]
        public void Day12a3()
        {
            var lines = input3.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(226, Day12.Day12a(lines));
        }


        [Fact]
        public void Day12b()
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(36, Day12.Day12b(lines));
        }
        [Fact]
        public void Day12b2()
        {
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(103, Day12.Day12b(lines));
        }
        [Fact]
        public void Day12b3()
        {
            var lines = input3.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(3509, Day12.Day12b(lines));
        }

        public Day12Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
