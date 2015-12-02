using AdventOfCode.Itsho.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Itsho.Tests
{
    public static class Tester
    {
        public static void TestDay1Part2()
        {
            Assert.AreEqual(1, Day1Solution.FindBasement(")"));
            Assert.AreEqual(5, Day1Solution.FindBasement("()())"));
        }

        public static void TestDay2Part1()
        {
            Assert.AreEqual(58, Day2Solution.GetWrappingTotal("2x3x4"));
            Assert.AreEqual(43, Day2Solution.GetWrappingTotal("1x1x10"));
        }

        public static void TestDay2Part2()
        {
            Assert.AreEqual(34, Day2Solution.GetRibbon("2x3x4"));
            Assert.AreEqual(14, Day2Solution.GetRibbon("1x1x10"));
        }
    }
}