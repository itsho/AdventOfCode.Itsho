using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Itsho.Solutions
{
    public static class Day8Solution
    {
        /// <summary>
        /// what is the number of characters of code for string literals minus the number of characters in memory for the values of the strings in total for the entire file
        /// </summary>
        internal static void ParseStringPart1(string[] p_arrSource, out int p_intCodeLength, out int p_intStringInMemoryLength)
        {
            // code length, is actually simple Length
            p_intCodeLength = p_arrSource.Sum(s => s.Length);

            // to get memory length we use regex
            // we reduce two quotation marks from the begining and the end
            p_intStringInMemoryLength = p_arrSource.Sum(s => Regex.Unescape(s).Length - 2);
        }

        /// <summary>
        /// encode each code representation as a new string and find the number of characters of the new encoded representation, including the surrounding double quotes
        /// </summary>
        internal static void ParseStringPart2(string[] p_arrSource, out int p_intCodeLength, out int p_intStringWithCodeLength)
        {
            p_intCodeLength = p_arrSource.Sum(s => s.Length);
            p_intStringWithCodeLength = 0;
            foreach (var strLine in p_arrSource)
            {
                int intCount = 0;
                foreach (var chr in strLine)
                {
                    // "" encodes to "\"\"", an increase from 2 characters to 6.
                    // "abc" encodes to "\"abc\"", an increase from 5 characters to 9.
                    // "aaa\"aaa" encodes to "\"aaa\\\"aaa\"", an increase from 10 characters to 16.
                    // "\x27" encodes to "\"\\x27\"", an increase from 6 characters to 11.

                    // so, single (") is actually counted as two chars (\")
                    if (chr == '"' ||
                        // and, singe backslash (\\) is actually counted as two chars (\\)
                        chr == '\\')
                    {
                        intCount++;
                    }
                }
                // we DO calculate the two quotation marks from the begining and the end.
                p_intStringWithCodeLength += intCount + strLine.Length + 2;
            }
        }

        internal static void ParseSingleString(string p_strSource, out int p_intCodeLength, out int p_intStringLength)
        {
            p_intCodeLength = p_strSource.Length;

            string strParsed = p_strSource.Replace("\\", @"\")
                                          .Replace("\"", @"");

            p_intStringLength = strParsed.Length;
        }
    }
}
