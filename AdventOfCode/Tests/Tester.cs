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

        internal static void TestDay3Part1()
        {
            //> delivers presents to 2 houses: one at the starting location, and one to the east.
            Assert.AreEqual(2, Day3Solution.GetHousesWithOnePresent(">"));
            // ^>v< delivers presents to 4 houses in a square, including twice to the house at his starting/ending location.
            Assert.AreEqual(4, Day3Solution.GetHousesWithOnePresent("^>v<"));
            //^v^v^v^v^v delivers a bunch of presents to some very lucky children at only 2 houses.
            Assert.AreEqual(2, Day3Solution.GetHousesWithOnePresent("^v^v^v^v^v"));
        }

        internal static void TestDay3Part2()
        {
            //^v delivers presents to 3 houses, because Santa goes north, and then Robo-Santa goes south.
            Assert.AreEqual(3, Day3Solution.GetHousesWithOnePresent("^v", true));
            //^>v< now delivers presents to 3 houses, and Santa and Robo-Santa end up back where they started.
            Assert.AreEqual(3, Day3Solution.GetHousesWithOnePresent("^>v<", true));
            //^v^v^v^v^v now delivers presents to 11 houses, with Santa going one direction and Robo-Santa going the other.
            Assert.AreEqual(11, Day3Solution.GetHousesWithOnePresent("^v^v^v^v^v", true));
        }

        internal static void TestDay4Part1()
        {
            // If your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes (000001dbbfa...), and it is the lowest such number to do so.
            Assert.AreEqual(609043, Day4Solution.GetMD5Answer("abcdef", 5));
            //If your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....
            Assert.AreEqual(1048970, Day4Solution.GetMD5Answer("pqrstuv", 5));
        }

        internal static void TestDay5Part1()
        {
            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("ugknbfddgicrmopn") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("aaa") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("jchzalrnumimnmhp") == 0);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("haegwjzuvuyypxyu") == 0);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("dvszwmarrgswjxmb") == 0);

            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("aeiouxx") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("aeixx") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("xazegovxx") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("aeiouaeiouaeiouxx") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart1("aeiouaeiouaeiuxx") == 1);
        }

        internal static void TestDay5Part2()
        {
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("xyxyefe") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("xyxy") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("aabcdefgaa") == 0);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("aabcdedgaa") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("qjhvhtzxzqqjkmpb") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("aaaodo") == 0);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("xxyxx") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("xxdydxx") == 1);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("uurcxstgmygtbstg") == 0);
            Assert.IsTrue(Day5Solution.CountNiceStringsPart2("ieodomkazucvgmuy") == 0);
        }

        internal static void TestDay6Part1()
        {
            Assert.AreEqual(1000000, Day6Solution.GetTurnedLights1("turn on 0,0 through 999,999"));
            Assert.AreEqual(1000, Day6Solution.GetTurnedLights1("toggle 0,0 through 999,0"));
            Assert.AreEqual(0, Day6Solution.GetTurnedLights1("turn off 499,499 through 500,500"));
            
        }

        internal static void TestDay6Part2()
        {
            Assert.AreEqual(1, Day6Solution.GetTurnedLights2("turn on 0,0 through 0,0"));
            Assert.AreEqual(1000000, Day6Solution.GetTurnedLights2("turn on 0,0 through 999,999"));
            Assert.AreEqual(2000000, Day6Solution.GetTurnedLights2("toggle 0,0 through 999,999"));
            Assert.AreEqual(2000, Day6Solution.GetTurnedLights2("toggle 0,0 through 999,0"));
            Assert.AreEqual(0, Day6Solution.GetTurnedLights2(@"turn on 0,0 through 0,999
turn off 0,0 through 0,999"));

            Assert.AreEqual(1000, Day6Solution.GetTurnedLights2(
@"turn on 0,0 through 1,999
turn off 0,0 through 0,999"));

            // first row =  1st row 1, 2nd row 1
            // second row = 1st row 0, 2nd row 1
            // third row = 1st row 2, 2nd row 3, 3rd row 2
            Assert.AreEqual(2*1000+3*1000+2*1000, Day6Solution.GetTurnedLights2(
@"turn on 0,0 through 1,999
turn off 0,0 through 0,999
toggle 0,0 through 2,999"));

        }
    }
}