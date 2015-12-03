using System;
using AdventOfCode.Itsho.RiddleSources;
using AdventOfCode.Itsho.Solutions;
using AdventOfCode.Itsho.Tests;

namespace AdventOfCode.Itsho
{
    internal class Program
    {
        private const string HOMEPAGE = "http://adventofcode.com/";

     

        private static void Main(string[] args)
        {
            Console.WriteLine("------ Day 1 ------");
            Tester.TestDay1Part2();
            Console.WriteLine("Enter basement is in position: " + Day1Solution.FindBasement(RiddleSource.DAY1_RIDDLE));

            Console.WriteLine("------ Day 2 ------");

            Tester.TestDay2Part1();
            Console.WriteLine("wrapping paper needed: " + Day2Solution.GetWrappingTotal(RiddleSource.DAY2_RIDDLE));

            Tester.TestDay2Part2();
            Console.WriteLine("Ribbon needed: " + Day2Solution.GetRibbon(RiddleSource.DAY2_RIDDLE));

            Console.WriteLine("------ Day 3 ------");

            Tester.TestDay3Part1();
            Console.WriteLine("Houses received at least one present: " + Day3Solution.GetHousesWithOnePresent(RiddleSource.DAY3_RIDDLE));

            Tester.TestDay3Part2();
            Console.WriteLine("Houses received at least one present with robo-santa: " + Day3Solution.GetHousesWithOnePresent(RiddleSource.DAY3_RIDDLE,true));


            Console.ReadKey();
        }
    }
}