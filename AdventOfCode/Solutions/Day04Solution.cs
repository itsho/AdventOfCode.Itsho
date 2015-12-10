using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Itsho.Solutions
{
    public static class Day04Solution
    {
        internal static int GetMD5Answer(string p_strInput, int p_intZeroCount)
        {
            // brute force to find result. no other way
            var lstNumbers = Enumerable.Range(0, 10000000).ToArray();


            int intFoundAnswer = 0;
            Parallel.ForEach(lstNumbers, (p_intCurrNumber, p_state) =>
            {
                string strToHash = p_strInput + p_intCurrNumber.ToString();

                string strMD5 = CalculateMD5Hash(strToHash);

                if (strMD5.StartsWith(0.ToString("D" + p_intZeroCount)))
                {
                    intFoundAnswer = p_intCurrNumber;
                    // break all threads
                    p_state.Break();
                }
            });

            return intFoundAnswer;
        }

        // http://blogs.msdn.com/b/csharpfaq/archive/2006/10/09/how-do-i-calculate-a-md5-hash-from-a-string_3f00_.aspx
        private static string CalculateMD5Hash(string p_strInput)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(p_strInput);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}