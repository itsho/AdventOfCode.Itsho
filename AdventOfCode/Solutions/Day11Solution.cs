using System.Collections.Generic;

namespace AdventOfCode.Itsho.Solutions
{
    public static class Day11Solution
    {
        private static List<char> m_lstBadChars = new List<char>();

        static Day11Solution()
        {
            m_lstBadChars.Add('i');
            m_lstBadChars.Add('o');
            m_lstBadChars.Add('l');
        }

        internal static string GetNextPassword(string p_strCurrentPassword)
        {
            string strIncreased = IncreaseAndValidate(p_strCurrentPassword);

            return strIncreased;
        }

        private static string IncreaseAndValidate(string p_strCurrentPassword)
        {
            var arrResult = p_strCurrentPassword.ToCharArray();

            bool blnIsValid = Validate(arrResult);

            int intCurrChar = p_strCurrentPassword.Length - 1;

            while (!blnIsValid)
            {
                //for (int intCurrChar = p_strCurrentPassword.Length-1; intCurrChar > 0; intCurrChar--)

                // get last char
                var lastChar = arrResult[intCurrChar];

                // Increase by one
                lastChar++;

                while (m_lstBadChars.Contains(lastChar))
                {
                    lastChar++;
                }

                // if overflow
                if (lastChar > 'z')
                {
                    //make it a again, 
                    lastChar = 'a';
                    arrResult[intCurrChar] = lastChar;

                    //go to previous charindex
                    intCurrChar--;
                }
                else
                {
                    // set new char
                    arrResult[intCurrChar] = lastChar;
                }

                blnIsValid = Validate(arrResult);
            }


            if (blnIsValid)
            {
                return string.Join(string.Empty, arrResult);
            }
            return string.Empty;
        }

        internal static bool Validate(char[] p_arrResult)
        {
            // Passwords may not contain the letters i, o, or l, as these letters can be mistaken for other characters and are therefore confusing.
            for (int intCurrChar = 0; intCurrChar < p_arrResult.Length - 2; intCurrChar++)
            {
                if (m_lstBadChars.Contains(p_arrResult[intCurrChar]))
                {
                    return false;
                }
            }

            // include one increasing straight of at least three letters, like abc, bcd, cde, and so on, up to xyz. They cannot skip letters; abd doesn't count
            bool blnHasStraightSequance = false;

            //Passwords must contain at least two different, non-overlapping pairs of letters, like aa, bb, or zz.
            bool blnHasPairSequance = false;

            for (int intCurrChar = 0; intCurrChar < p_arrResult.Length - 2; intCurrChar++)
            {
                if (!blnHasStraightSequance)
                {
                    if (p_arrResult[intCurrChar] + 1 == p_arrResult[intCurrChar + 1] &&
                        p_arrResult[intCurrChar] + 2 == p_arrResult[intCurrChar + 2])
                    {
                        blnHasStraightSequance = true;
                    }
                }

                if (!blnHasPairSequance)
                {
                    if (p_arrResult[intCurrChar] == p_arrResult[intCurrChar + 1])
                    {
                        blnHasPairSequance = true;
                    }
                }
            }

            return (blnHasPairSequance && blnHasStraightSequance);
        }
    }
}