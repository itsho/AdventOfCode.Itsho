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
            ConsoleWriteLineTimed("Enter basement is in position: " ,()=>Day01Solution.FindBasement(File.ReadAllLines(@"RiddleSources\DAY01.txt")[0]).ToString());

            Console.WriteLine("------ Day 2 ------");

            Tester.TestDay2Part1();
            var arrDay2Input = File.ReadAllLines(@"RiddleSources\DAY02.txt");
            ConsoleWriteLineTimed("wrapping paper needed: ", () => Day02Solution.GetWrappingTotal(arrDay2Input).ToString());

            Tester.TestDay2Part2();
            ConsoleWriteLineTimed("Ribbon needed: ", () => Day02Solution.GetRibbon(arrDay2Input).ToString());

            Console.WriteLine("------ Day 3 ------");

            Tester.TestDay3Part1();
            var arrDay3Input = File.ReadAllLines(@"RiddleSources\DAY03.txt")[0];
            ConsoleWriteLineTimed("Houses received at least one present: ", () => Day03Solution.GetHousesWithOnePresent(arrDay3Input).ToString());

            Tester.TestDay3Part2();
            ConsoleWriteLineTimed("Houses received at least one present with robo-santa: ", () => Day03Solution.GetHousesWithOnePresent(arrDay3Input, true).ToString());

            Console.WriteLine("------ Day 4 ------");

            Tester.TestDay4Part1();
            var arrDay4Input = File.ReadAllLines(@"RiddleSources\DAY04.txt")[0];
            ConsoleWriteLineTimed("Starts with 5 zeros: ", () => Day04Solution.GetMD5Answer(arrDay4Input, 5).ToString());
            ConsoleWriteLineTimed("Starts with 6 zeros: ", () => Day04Solution.GetMD5Answer(arrDay4Input, 6).ToString());

            Console.WriteLine("------ Day 5 ------");

            Tester.TestDay5Part1();
            var arrDay5Input = File.ReadAllLines(@"RiddleSources\DAY05.txt");
            ConsoleWriteLineTimed("Total nice strings: ", () => Day05Solution.CountNiceStringsPart1(arrDay5Input).ToString());
            Tester.TestDay5Part2();
            ConsoleWriteLineTimed("Total nice strings: ", () => Day05Solution.CountNiceStringsPart2(arrDay5Input).ToString());

            Console.WriteLine("------ Day 6 ------");

            Tester.TestDay6Part1();
            var arrDay6Input = File.ReadAllLines(@"RiddleSources\DAY06.txt");
            ConsoleWriteLineTimed("Total lit lights: ", () => Day06Solution.GetTurnedLights1(arrDay6Input).ToString());

            Tester.TestDay6Part2();
            ConsoleWriteLineTimed("Total brightness: ", () => Day06Solution.GetTurnedLights2(arrDay6Input).ToString());
            Console.WriteLine("------ Day 7 ------");

            Tester.TestDay7Part1();
            var arrDay7Input = File.ReadAllLines(@"RiddleSources\DAY07.txt");
            ConsoleWriteLineTimed("wire a signal: ", () => Day07Solution.GetWireSignalResult("a", arrDay7Input).ToString());
            ConsoleWriteLineTimed("wire a new signal: ", () => Day07Solution.GetWireSignalResult("a", arrDay7Input, true).ToString());

            Console.WriteLine("------ Day 8 ------");
            Tester.TestDay8Part1();
            ConsoleWriteLineTimed("Total code characters minus memory characters: ", () =>
            {
                int intCodeLen, intStringLen;
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY08.txt"); // make sure no extra 'newline' is in the end
                Day08Solution.ParseStringPart1(lstRows, out intCodeLen, out intStringLen);

                // number of characters of code for string literals minus the number of characters in memory
                return (intCodeLen - intStringLen).ToString();
            });

            ConsoleWriteLineTimed("Total code characters minus memory characters: ", () =>
            {
                int intCodeLen, intStringWithCodeLength;
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY08.txt"); // make sure no extra 'newline' is in the end
                Day08Solution.ParseStringPart2(lstRows, out intCodeLen, out intStringWithCodeLength);

                // characters to represent the newly encoded strings  MINUS the number of characters of code
                return (intStringWithCodeLength - intCodeLen).ToString();
            });

            Console.WriteLine("------ Day 9 ------");
            Tester.TestDay9();
            ConsoleWriteLineTimed("Shortest route: ", () =>
            {
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY09.txt");
                return Day09Solution.GetRouteDistance(lstRows,true).ToString();
            });

            ConsoleWriteLineTimed("Longest route: ", () =>
            {
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY09.txt");
                return Day09Solution.GetRouteDistance(lstRows, false).ToString();
            });

    
            Console.WriteLine("------ Day 10 ------");
            Tester.TestDay10();
            ConsoleWriteLineTimed("Length of 40 times: ", () =>
            {
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY10.txt");

                return Day10Solution.LookAndSay(lstRows[0], 40).Length.ToString();
            });

            ConsoleWriteLineTimed("Length of 50 times: ", () =>
            {
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY10.txt");

                return Day10Solution.LookAndSay(lstRows[0], 50).Length.ToString();
            });
            */


            Console.WriteLine("------ Day 11 ------");
            Tester.TestDay11();
            ConsoleWriteLineTimed("Next password: ", () =>
            {
                var lstRows = File.ReadAllLines(@"RiddleSources\DAY11.txt");

                return Day11Solution.GetNextPassword(lstRows[0]);
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
            Console.WriteLine(p_strTitle + strResult + "\t (" + sw.Elapsed.ToString() + ")");
        }
    }
}