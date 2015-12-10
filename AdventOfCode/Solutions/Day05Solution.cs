using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Itsho.Solutions
{
    public static class Day05Solution
    {
        private static readonly object lockThis = new object();

        public static int CountNiceStringsPart1(string p_strInput)
        {
            var arrStrings = p_strInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int intNiceCounter = 0;
            Parallel.ForEach(arrStrings, (p_strCurrInput) =>
            {
                if (IsNiceStringPart1(p_strCurrInput))
                {
                    lock (lockThis)
                    {
                        intNiceCounter++;
                    }
                }
            });
            return intNiceCounter;
        }

        public static int CountNiceStringsPart2(string p_strInput)
        {
            var arrStrings = p_strInput.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int intNiceCounter = 0;
            Parallel.ForEach(arrStrings, (p_strCurrInput) =>
            {
                if (IsNiceStringPart2(p_strCurrInput))
                {
                    lock (lockThis)
                    {
                        intNiceCounter++;
                    }
                }
            });
            return intNiceCounter;
        }

        private static bool IsNiceStringPart1(string p_strCurrInput)
        {
            if (p_strCurrInput.Length < 2)
            {
                throw new ArgumentException("string not long enough", "p_strCurrInput");
            }

            // start with the bad side to spare some time and since that the rule says "even if they are part of one of the other requirements."
            // check that it does NOT contains the strings
            var arrBadStrings = new string[] { "ab", "cd", "pq", "xy" };

            foreach (var badString in arrBadStrings)
            {
                if (p_strCurrInput.Contains(badString))
                {
                    return false;
                }
            }

            // count vowels
            int intCountVowels = p_strCurrInput.Count("aeiou".Contains);

            int intDoubleLetters = 0;

            // count double letters
            for (int intCurrChar = 1; intCurrChar < p_strCurrInput.Length; intCurrChar++)
            {
                if (p_strCurrInput[intCurrChar - 1] == p_strCurrInput[intCurrChar])
                {
                    intDoubleLetters++;
                }
            }

            // It contains at least three vowels (aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
            // It contains at least one letter that appears twice in a row, like xx, abcdde (dd), or aabbccdd (aa, bb, cc, or dd).
            if (intCountVowels >= 3 && intDoubleLetters >= 1)
            {
                return true;
            }

            return false;
        }

        private static bool IsNiceStringPart2(string p_strCurrInput)
        {
            if (p_strCurrInput.Length < 2)
            {
                throw new ArgumentException("string not long enough", "p_strCurrInput");
            }


            bool blnHasTwoLettersNoOverlap = false;
            // 1a. contains pair of any two letters with count 2
            for (int intCurrChar = 0;  intCurrChar < p_strCurrInput.Length - 2; intCurrChar++)
            {
                var strPair = p_strCurrInput[intCurrChar].ToString() +  p_strCurrInput[intCurrChar+1].ToString();

                // if this pair exists at least twice in this input, 
                // but it is not overlapping
                if (p_strCurrInput.Substring(intCurrChar + 2).Contains(strPair))
                {
                    blnHasTwoLettersNoOverlap = true;
                    Trace.WriteLine("two letters no overlap: '"+strPair +"'");
                    break;
                }
            }


            // 2. one letter repeat with exactly one letter in between (xyx, efe, aaa)
            bool blnOneLetterRepeatWithOneLetterBetween = false;
            for (int intCurrChar = 0; intCurrChar < p_strCurrInput.Length - 2; intCurrChar++)
            {
                var chrCurrent = p_strCurrInput[intCurrChar];
                if (chrCurrent == p_strCurrInput[intCurrChar + 2])
                {
                    blnOneLetterRepeatWithOneLetterBetween = true;
                    break;
                }
            }


            if (blnHasTwoLettersNoOverlap && blnOneLetterRepeatWithOneLetterBetween)
            {
                return true;
            }

            return false;
        }
    }
}