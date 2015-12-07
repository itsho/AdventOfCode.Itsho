using AdventOfCode.Itsho.RiddleSources;
using AdventOfCode.Itsho.Solutions;
using AdventOfCode.Itsho.Tests;
using System;
using System.Diagnostics;

namespace AdventOfCode.Itsho
{
    internal class Program
    {
        private const string HOMEPAGE = "http://adventofcode.com/";

        private static void Main(string[] args)
        {
            // Hebrew instructions for day 1: http://pastebin.com/2MeAkKZ3

            Console.WriteLine("------ Day 1 ------");
            Tester.TestDay1Part2();
            ConsoleWriteLineTimed("Enter basement is in position: " ,()=>Day1Solution.FindBasement(RiddleSource.DAY1_RIDDLE).ToString());

            Console.WriteLine("------ Day 2 ------");

            Tester.TestDay2Part1();
            ConsoleWriteLineTimed("wrapping paper needed: ", () => Day2Solution.GetWrappingTotal(RiddleSource.DAY2_RIDDLE).ToString());

            Tester.TestDay2Part2();
            ConsoleWriteLineTimed("Ribbon needed: ", () => Day2Solution.GetRibbon(RiddleSource.DAY2_RIDDLE).ToString());

            Console.WriteLine("------ Day 3 ------");

            Tester.TestDay3Part1();
            ConsoleWriteLineTimed("Houses received at least one present: ", () => Day3Solution.GetHousesWithOnePresent(RiddleSource.DAY3_RIDDLE).ToString());

            Tester.TestDay3Part2();
            ConsoleWriteLineTimed("Houses received at least one present with robo-santa: ", () => Day3Solution.GetHousesWithOnePresent(RiddleSource.DAY3_RIDDLE, true).ToString());
            
            Console.WriteLine("------ Day 4 ------");

            ConsoleWriteLineTimed("Starts with 5 zeros :", () => Day4Solution.GetMD5Answer(RiddleSource.DAY4_RIDDLE, 5).ToString());
            ConsoleWriteLineTimed("Starts with 6 zeros :", () => Day4Solution.GetMD5Answer(RiddleSource.DAY4_RIDDLE, 6).ToString());
            
            Console.WriteLine("------ Day 5 ------");

            


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();


        }

        private static void ConsoleWriteLineTimed(string p_strTitle, Func<string> p_actionToRun)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string strResult = p_actionToRun();
            sw.Stop();
            Console.WriteLine(p_strTitle + strResult + "\t (" + sw.Elapsed.ToString()+")");
        }
    }
}