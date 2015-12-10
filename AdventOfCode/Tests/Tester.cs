using System;
using AdventOfCode.Itsho.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Itsho.Tests
{
    public static class Tester
    {
        public static void TestDay1Part2()
        {
            Assert.AreEqual(1, Day01Solution.FindBasement(")"));
            Assert.AreEqual(5, Day01Solution.FindBasement("()())"));
        }

        public static void TestDay2Part1()
        {
            Assert.AreEqual(58, Day02Solution.GetWrappingTotal("2x3x4"));
            Assert.AreEqual(43, Day02Solution.GetWrappingTotal("1x1x10"));
        }

        public static void TestDay2Part2()
        {
            Assert.AreEqual(34, Day02Solution.GetRibbon("2x3x4"));
            Assert.AreEqual(14, Day02Solution.GetRibbon("1x1x10"));
        }

        internal static void TestDay3Part1()
        {
            //> delivers presents to 2 houses: one at the starting location, and one to the east.
            Assert.AreEqual(2, Day03Solution.GetHousesWithOnePresent(">"));
            // ^>v< delivers presents to 4 houses in a square, including twice to the house at his starting/ending location.
            Assert.AreEqual(4, Day03Solution.GetHousesWithOnePresent("^>v<"));
            //^v^v^v^v^v delivers a bunch of presents to some very lucky children at only 2 houses.
            Assert.AreEqual(2, Day03Solution.GetHousesWithOnePresent("^v^v^v^v^v"));
        }

        internal static void TestDay3Part2()
        {
            //^v delivers presents to 3 houses, because Santa goes north, and then Robo-Santa goes south.
            Assert.AreEqual(3, Day03Solution.GetHousesWithOnePresent("^v", true));
            //^>v< now delivers presents to 3 houses, and Santa and Robo-Santa end up back where they started.
            Assert.AreEqual(3, Day03Solution.GetHousesWithOnePresent("^>v<", true));
            //^v^v^v^v^v now delivers presents to 11 houses, with Santa going one direction and Robo-Santa going the other.
            Assert.AreEqual(11, Day03Solution.GetHousesWithOnePresent("^v^v^v^v^v", true));
        }

        internal static void TestDay4Part1()
        {
            // If your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes (000001dbbfa...), and it is the lowest such number to do so.
            Assert.AreEqual(609043, Day04Solution.GetMD5Answer("abcdef", 5));
            //If your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....
            Assert.AreEqual(1048970, Day04Solution.GetMD5Answer("pqrstuv", 5));
        }

        internal static void TestDay5Part1()
        {
            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("ugknbfddgicrmopn") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("aaa") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("jchzalrnumimnmhp") == 0);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("haegwjzuvuyypxyu") == 0);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("dvszwmarrgswjxmb") == 0);

            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("aeiouxx") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("aeixx") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("xazegovxx") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("aeiouaeiouaeiouxx") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart1("aeiouaeiouaeiuxx") == 1);
        }

        internal static void TestDay5Part2()
        {
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("xyxyefe") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("xyxy") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("aabcdefgaa") == 0);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("aabcdedgaa") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("qjhvhtzxzqqjkmpb") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("aaaodo") == 0);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("xxyxx") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("xxdydxx") == 1);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("uurcxstgmygtbstg") == 0);
            Assert.IsTrue(Day05Solution.CountNiceStringsPart2("ieodomkazucvgmuy") == 0);
        }

        internal static void TestDay6Part1()
        {
            Assert.AreEqual(1000000, Day06Solution.GetTurnedLights1("turn on 0,0 through 999,999"));
            Assert.AreEqual(1000, Day06Solution.GetTurnedLights1("toggle 0,0 through 999,0"));
            Assert.AreEqual(0, Day06Solution.GetTurnedLights1("turn off 499,499 through 500,500"));
        }

        internal static void TestDay6Part2()
        {
            Assert.AreEqual(1, Day06Solution.GetTurnedLights2("turn on 0,0 through 0,0"));
            Assert.AreEqual(1000000, Day06Solution.GetTurnedLights2("turn on 0,0 through 999,999"));
            Assert.AreEqual(2000000, Day06Solution.GetTurnedLights2("toggle 0,0 through 999,999"));
            Assert.AreEqual(2000, Day06Solution.GetTurnedLights2("toggle 0,0 through 999,0"));
            Assert.AreEqual(0, Day06Solution.GetTurnedLights2(@"turn on 0,0 through 0,999
turn off 0,0 through 0,999"));

            Assert.AreEqual(1000, Day06Solution.GetTurnedLights2(
@"turn on 0,0 through 1,999
turn off 0,0 through 0,999"));

            // first row =  1st row 1, 2nd row 1
            // second row = 1st row 0, 2nd row 1
            // third row = 1st row 2, 2nd row 3, 3rd row 2
            Assert.AreEqual(2 * 1000 + 3 * 1000 + 2 * 1000, Day06Solution.GetTurnedLights2(
@"turn on 0,0 through 1,999
turn off 0,0 through 0,999
toggle 0,0 through 2,999"));
        }

        internal static void TestDay7Part1()
        {
            const string INPUT_TEST1 =
@"x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i
y -> z
123 -> x
456 -> y";

            Assert.AreEqual(72, Day07Solution.GetWireSignalResult("d", INPUT_TEST1));
            Assert.AreEqual(492, Day07Solution.GetWireSignalResult("f", INPUT_TEST1));
            Assert.AreEqual(114, Day07Solution.GetWireSignalResult("g", INPUT_TEST1));
            Assert.AreEqual(65412, Day07Solution.GetWireSignalResult("h", INPUT_TEST1));
            Assert.AreEqual(65079, Day07Solution.GetWireSignalResult("i", INPUT_TEST1));
            Assert.AreEqual(123, Day07Solution.GetWireSignalResult("x", INPUT_TEST1));
            Assert.AreEqual(456, Day07Solution.GetWireSignalResult("y", INPUT_TEST1));
            // wire to wire
            Assert.AreEqual(456, Day07Solution.GetWireSignalResult("z", INPUT_TEST1));
        }

        internal static void TestDay8Part1()
        {
            int intCodeLength, intStringLength;
            Day08Solution.ParseStringPart1(new string[]{ "\"\""}, out intCodeLength, out intStringLength);
            Assert.AreEqual(2, intCodeLength);
            Assert.AreEqual(0, intStringLength);

            Day08Solution.ParseStringPart1(new string[]{"\"abc\""}, out intCodeLength, out intStringLength);
            Assert.AreEqual(5, intCodeLength);
            Assert.AreEqual(3, intStringLength);
            // single \ should become \\
            // single " will become \"
            // single 
            Day08Solution.ParseStringPart1(new string[]{"\"aaa\\\"aaa\""}, out intCodeLength, out intStringLength);
            Assert.AreEqual(10, intCodeLength);
            Assert.AreEqual(7, intStringLength);

            Day08Solution.ParseStringPart1(new string[] { @"""\x27""" }, out intCodeLength, out intStringLength);
            Assert.AreEqual(6, intCodeLength);
            Assert.AreEqual(1, intStringLength);
        }

        internal static void TestDay9()
        {
            const string TEST_INPOUT =
                @"London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141";

            /*Dublin -> London -> Belfast = 982
London -> Dublin -> Belfast = 605
London -> Belfast -> Dublin = 659
Dublin -> Belfast -> London = 659
Belfast -> Dublin -> London = 605
Belfast -> London -> Dublin = 982 
              
             * */

            // The shortest of these is London -> Dublin -> Belfast = 605, and so the answer is 605 in this example.
            Assert.AreEqual(605, Day09Solution.GetRouteDistance(TEST_INPOUT.Split(new string[] { Environment.NewLine }, StringSplitOptions.None),true));

            // the longest route would be 982 via (for example) Dublin -> London -> Belfast
            Assert.AreEqual(982, Day09Solution.GetRouteDistance(TEST_INPOUT.Split(new string[] { Environment.NewLine }, StringSplitOptions.None),false));

        }

        public static void TestDay10()
        {
            Assert.AreEqual("11", Day10Solution.LookAndSay("1"));
            Assert.AreEqual("1211", Day10Solution.LookAndSay("21"));
            Assert.AreEqual("111221", Day10Solution.LookAndSay("1211"));
            Assert.AreEqual("312211", Day10Solution.LookAndSay("111221"));
            Assert.AreEqual("13112221", Day10Solution.LookAndSay("312211"));
            Assert.AreEqual("1113213211", Day10Solution.LookAndSay("13112221"));

            
        }

    }
}