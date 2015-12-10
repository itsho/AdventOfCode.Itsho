using System;
using System.Text;

namespace AdventOfCode.Itsho.Solutions
{
    /// <summary>
    /// main trick is to use REF to avoid creating new strings all the time :-)
    /// </summary>
    public static class Day10Solution
    {

        public static string LookAndSay(string p_strInput, int p_intTotalTimes)
        {
            var lastResult = LookAndSay(p_strInput);

            var stbResult = new StringBuilder();
            for (int intIndex = 0; intIndex < p_intTotalTimes-1; intIndex++)
            {
                lastResult = (LookAndSay(lastResult));
            }

            return lastResult;
        }
        internal static string LookAndSay(string p_strInput)
        {
            var stbResult = new StringBuilder();
            for (int intCurrChar = 0; intCurrChar < p_strInput.Length; /*do nothing to increment*/)
            {
                int intCounterOfCurrChar = CountTillNextDiffChar(p_strInput[intCurrChar], ref p_strInput, intCurrChar + 1);

                stbResult.Append(intCounterOfCurrChar);
                stbResult.Append(p_strInput[intCurrChar]);

                // skip to the next charecter
                intCurrChar += intCounterOfCurrChar;
            }
            return stbResult.ToString();
        }

        // simple change - use ref to get way faster solution :-)
        private static int CountTillNextDiffChar(char p_chrCurrentChar, ref string p_strStringToEnd, int p_intStartLocation)
        {
            int intTotalOfCurrentChar = 1;

            // we start from the next char
            for (int intCurrChar = p_intStartLocation; intCurrChar < p_strStringToEnd.Length; intCurrChar++)
            {
                if (p_strStringToEnd[intCurrChar] == p_chrCurrentChar)
                {
                    intTotalOfCurrentChar++;
                }
                else
                {
                    return intTotalOfCurrentChar;
                }
            }
            return intTotalOfCurrentChar;
        }
    }
}