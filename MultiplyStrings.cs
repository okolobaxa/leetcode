using System;
using System.Linq;
using System.Text;
using Xunit;

namespace leetcode
{
    /// https://leetcode.com/problems/multiply-strings/
    public class MultiplyStringsProblem
    {
        [Fact]
        public void MultiplyStringsTest1()
        {
            var result = Multiply("2", "3");

            Assert.Equal("6", result);
        }

        [Fact]
        public void MultiplyStringsTest2()
        {
            var result = Multiply("123", "456");

            Assert.Equal("56088", result);
        }

        [Fact]
        public void MultiplyStringsTest3()
        {
            var result = Multiply("173", "157");

            Assert.Equal("27161", result);
        }

        [Fact]
        public void MultiplyStringsTest4()
        {
            var result = Multiply("123", "45");

            Assert.Equal("5535", result);
        }

        [Fact]
        public void MultiplyStringsTest5()
        {
            var result = Multiply("999", "999");

            Assert.Equal("998001", result);
        }

        [Fact]
        public void MultiplyStringsTest6()
        {
            var result = Multiply("1999", "99");

            Assert.Equal("197901", result);
        }

        [Fact]
        public void MultiplyStringsTest7()
        {
            var result = Multiply("436", "101");

            Assert.Equal("44036", result);
        }

        [Fact]
        public void MultiplyStringsTest8()
        {
            var result = Multiply("436", "100");

            Assert.Equal("43600", result);
        }

        [Fact]
        public void MultiplyStringsTest9()
        {
            var result = Multiply("123456789", "987654321");

            Assert.Equal("121932631112635269", result);
        }

        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }

            if (num1 == "1")
            {
                return num2;
            }

            if (num2 == "1")
            {
                return num1;
            }

            if (num2.Length > num1.Length)
            {
                (num1, num2) = (num2, num1);
            }

            var sumLines = new string[num2.Length];

            var resultStringBuilder = new StringBuilder();

            for (int pos = 0; pos < num2.Length; pos++)
            {
                resultStringBuilder.Clear();

                var prevTens = 0;

                for (int i = 0; i < num1.Length; i++)
                {
                    var n1 = num1[num1.Length - 1 - i] - '0';
                    var n2 = num2[num2.Length - 1 - pos] - '0';

                    var product = n1 * n2;

                    prevTens = Math.DivRem(product + prevTens, 10, out var ones);
                    resultStringBuilder.Insert(0, ones);
                }

                if (prevTens > 0)
                {
                    resultStringBuilder.Insert(0, prevTens);
                }

                sumLines[pos] = resultStringBuilder.ToString();
            }

            return Add(sumLines);
        }

        public string Add(string[] sumLines)
        {
            var overlallLength = sumLines.Max(x => x.Length) + sumLines.Length - 1;
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < sumLines.Length; i++)
            {
                sumLines[i] = sumLines[i].PadRight(sumLines[i].Length + i, '0');
                sumLines[i] = sumLines[i].PadLeft(overlallLength, '0');
            }

            int prevTens = 0, positionSum = 0;

            for (int position = overlallLength; position > 0; position--)
            {
                for (int i = 0; i < sumLines.Length; i++)
                {
                    positionSum += sumLines[i][position - 1] - '0';
                }

                prevTens = Math.DivRem(positionSum + prevTens, 10, out var ones);

                stringBuilder.Insert(0, ones);
                positionSum = 0;
            }

            if (prevTens > 0)
            {
                stringBuilder.Insert(0, prevTens);
            }

            return stringBuilder.ToString().TrimStart('0');
        }
    }
}
