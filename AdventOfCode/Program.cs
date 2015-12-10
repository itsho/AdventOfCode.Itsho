using AdventOfCode.Itsho.RiddleSources;
using AdventOfCode.Itsho.Solutions;
using AdventOfCode.Itsho.Tests;
using System;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode.Itsho
{
    internal class Program
    {
        private const string HOMEPAGE = "http://adventofcode.com/";

        private static void Main(string[] args)
        {
            // Hebrew instructions for day 1: http://pastebin.com/2MeAkKZ3

            /*
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

            Tester.TestDay4Part1();
             
            ConsoleWriteLineTimed("Starts with 5 zeros: ", () => Day4Solution.GetMD5Answer(RiddleSource.DAY4_RIDDLE, 5).ToString());
            ConsoleWriteLineTimed("Starts with 6 zeros: ", () => Day4Solution.GetMD5Answer(RiddleSource.DAY4_RIDDLE, 6).ToString());
           
            Console.WriteLine("------ Day 5 ------");

            Tester.TestDay5Part1();
            ConsoleWriteLineTimed("Total nice strings: ", () => Day5Solution.CountNiceStringsPart1(RiddleSource.DAY5_RIDDLE).ToString());
            Tester.TestDay5Part2();
            ConsoleWriteLineTimed("Total nice strings: ", () => Day5Solution.CountNiceStringsPart2(RiddleSource.DAY5_RIDDLE).ToString());
            

            Console.WriteLine("------ Day 6 ------");

            Tester.TestDay6Part1();
            ConsoleWriteLineTimed("Total lit lights: ", () => Day6Solution.GetTurnedLights1(RiddleSource.DAY6_RIDDLE).ToString());

            Tester.TestDay6Part2();
            ConsoleWriteLineTimed("Total brightness: ", () => Day6Solution.GetTurnedLights2(RiddleSource.DAY6_RIDDLE).ToString());
            Console.WriteLine("------ Day 7 ------");
            
            Tester.TestDay7Part1();
            ConsoleWriteLineTimed("wire a signal: ", () => Day7Solution.GetWireSignalResult("a",RiddleSource.DAY7_RIDDLE).ToString());
            ConsoleWriteLineTimed("wire a new signal: ", () => Day7Solution.GetWireSignalResult("a", RiddleSource.DAY7_RIDDLE, true).ToString());
            
            
            Console.WriteLine("------ Day 8 ------");
            Tester.TestDay8Part1();
            ConsoleWriteLineTimed("Total code characters minus memory characters: ", () =>
            {
                int intCodeLen, intStringLen;
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY8.txt"); // make sure no extra 'newline' is in the end
                Day8Solution.ParseStringPart1(lstRows, out intCodeLen, out intStringLen);

                // number of characters of code for string literals minus the number of characters in memory  
                return (intCodeLen - intStringLen).ToString();
            });

            ConsoleWriteLineTimed("Total code characters minus memory characters: ", () =>
            {
                int intCodeLen, intStringWithCodeLength;
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY8.txt"); // make sure no extra 'newline' is in the end
                Day8Solution.ParseStringPart2(lstRows, out intCodeLen, out intStringWithCodeLength);

                // characters to represent the newly encoded strings  MINUS the number of characters of code 
                return (intStringWithCodeLength - intCodeLen).ToString();
            });
           
            
            
            Console.WriteLine("------ Day 9 ------");
            Tester.TestDay9();
            ConsoleWriteLineTimed("Shortest route: ", () =>
            {
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY9.txt");
                return Day09Solution.GetRouteDistance(lstRows,true).ToString();
            });

            ConsoleWriteLineTimed("Longest route: ", () =>
            {
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY9.txt");
                return Day09Solution.GetRouteDistance(lstRows, false).ToString();
            });

             * */
            Console.WriteLine("------ Day 10 ------");
            Tester.TestDay10();
            ConsoleWriteLineTimed("Length of 40 times: ", () =>
            {
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY10.txt");

                return Day10Solution.LookAndSay(lstRows[0],40).Length.ToString();
            });

            ConsoleWriteLineTimed("Length of 50 times: ", () =>
            {
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY10.txt");

                return Day10Solution.LookAndSay(lstRows[0], 50).Length.ToString();
            });

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