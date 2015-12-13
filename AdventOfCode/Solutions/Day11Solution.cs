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

            bool blnIsValid = false;//Validate(arrResult);

            int intCurrChar = p_strCurrentPassword.Length - 1;

            while (!blnIsValid && intCurrChar > 0)
            {
                // Increase by one
                arrResult[intCurrChar]++;

                // if one of the chars are bad
                while (m_lstBadChars.Contains(arrResult[intCurrChar]))
                {
                    // go to next char
                    arrResult[intCurrChar]++;

                    // and reset all chars to the end to 'a'
                    //because you eventually skip all the passwords that start with XXi..., since 'i' is not allowed.
                    ResetCharsToEnd(intCurrChar + 1, arrResult);
                }

                // if overflow
                if (arrResult[intCurrChar] > 'z')
                {
                    //make it 'a' again,
                    arrResult[intCurrChar] = 'a';

                    // and reset all chars to the end to 'a'
                    //because you eventually skip all the passwords that start with XXi..., since 'i' is not allowed.
                    ResetCharsToEnd(intCurrChar + 1, arrResult);

                    // if we are not in first char
                    if (intCurrChar > 0)
                    {
                        // increase previous char
                        IncreasePreviousChar(intCurrChar - 1, arrResult);

                        blnIsValid = Validate(arrResult);
                    }
                    // if we are in first char
                    else
                    {
                        // we couldn't find valid pw
                        return string.Empty;
                    }
                }
                else
                {
                    blnIsValid = Validate(arrResult);
                }
            }

            if (blnIsValid)
            {
                return string.Join(string.Empty, arrResult);
            }
            return string.Empty;
        }

        private static void IncreasePreviousChar(int p_intCharToStartWith, char[] p_arrResult)
        {
            for (int intCurrChar = p_intCharToStartWith; intCurrChar > 0; intCurrChar--)
            {
                // increase char
                p_arrResult[intCurrChar]++;

                // if char is bad
                while (m_lstBadChars.Contains(p_arrResult[intCurrChar]))
                {
                    // go to next char
                    p_arrResult[intCurrChar]++;
                }

                if (p_arrResult[intCurrChar] > 'z')
                {
                    p_arrResult[intCurrChar] = 'a';
                    IncreasePreviousChar(intCurrChar - 1, p_arrResult);
                }
               
                break;
                
            }
        }

        private static void ResetCharsToEnd(int p_intCharIndexToStartWith, char[] p_arrResult)
        {
            // reset all chars to the end
            for (int intCurrCharToReset = p_intCharIndexToStartWith;
                intCurrCharToReset < p_arrResult.Length;
                intCurrCharToReset++)
            {
                p_arrResult[intCurrCharToReset] = 'a';
            }
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
            List<int> lstIndexOfPairSequance = new List<int>();

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
            }

            for (int intCurrChar = 0; intCurrChar < p_arrResult.Length - 1; intCurrChar++)
            {
                // if this pair NOT already exists in our list, 
                // and this pair does NOT overlaps the previous pair
                if (!lstIndexOfPairSequance.Contains(intCurrChar) && !lstIndexOfPairSequance.Contains(intCurrChar-1))
                {
                    // pair seq but not triple seq
                    if (p_arrResult[intCurrChar] == p_arrResult[intCurrChar + 1])
                    {
                        lstIndexOfPairSequance.Add(intCurrChar);
                    }
                }
            }



            return (lstIndexOfPairSequance.Count >= 2 && blnHasStraightSequance);
        }
    }
}