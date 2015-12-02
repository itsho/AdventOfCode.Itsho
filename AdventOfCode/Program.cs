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
            Tester.TestDay1Part2();
            Console.WriteLine("Enter basement is in position: " + Day1Solution.FindBasement(RiddleSource.DAY1_RIDDLE));

            Tester.TestDay2Part1();
            Console.WriteLine("wrapping paper needed: " + Day2Solution.GetWrappingTotal(RiddleSource.DAY2_RIDDLE));

            Tester.TestDay2Part2();
            Console.WriteLine("wrapping paper needed: " + Day2Solution.GetRibbon(RiddleSource.DAY2_RIDDLE));


            Console.ReadKey();
        }
    }
}