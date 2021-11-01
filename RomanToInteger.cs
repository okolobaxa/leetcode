using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/roman-to-integer/
    public class RomanToIntegerProblem
    {
        [Fact]
        public void RomanToIntegerTest1()
        {
            var s = "III";

            var result = RomanToInteger2(s);

            Assert.Equal(3, result);
        }

        [Fact]
        public void RomanToIntegerTest2()
        {
            var s = "IV";

            var result = RomanToInteger2(s);

            Assert.Equal(4, result);
        }

        [Fact]
        public void RomanToIntegerTest3()
        {
            var s = "IX";

            var result = RomanToInteger2(s);

            Assert.Equal(9, result);
        }

        [Fact]
        public void RomanToIntegerTest4()
        {
            var s = "LVIII";

            var result = RomanToInteger2(s);

            Assert.Equal(58, result);
        }

        [Fact]
        public void RomanToIntegerTest5()
        {
            var s = "MCMXCIV";

            var result = RomanToInteger2(s);

            Assert.Equal(1994, result);
        }

        [Fact]
        public void RomanToIntegerTest6()
        {
            var s = "MCMLXXXIV";

            var result = RomanToInteger2(s);

            Assert.Equal(1984, result);
        }

        [Fact]
        public void RomanToIntegerTest7()
        {
            var s = "MCXI";

            var result = RomanToInteger2(s);

            Assert.Equal(1111, result);
        }

        public int RomanToInteger2(string s)
        {
            if (s.Length == 1) return Convert(s[0]);

            ushort number = 0;

            for (byte i = 0; i < s.Length - 1; i++)
            {
                var current = Convert(s[i]);
                var next =  Convert(s[i + 1]);

                if (current >= next)
                {
                    number += current;
                }
                else
                {
                    number -= current;
                }
            }

            number += Convert(s[s.Length - 1]);

            return number;
        }

        private ushort Convert(char c)
        {
            ushort sum = c switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };

            return sum;
        }

        private bool TryConvert(char c1, char c2, out ushort sum)
        {
            sum = c1 switch
            {
                'I' when c2 == 'V' => 4,
                'I' when c2 == 'X' => 9,
                'X' when c2 == 'L' => 40,
                'X' when c2 == 'C' => 90,
                'C' when c2 == 'D' => 400,
                'C' when c2 == 'M' => 900,
                _ => 0
            };

            return sum > 0;
        }
    }
}
