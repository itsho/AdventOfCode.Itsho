namespace AdventOfCode.Itsho.Solutions
{
    public static class Day1Solution
    {
        public static int FindBasement(string p_strRiddleSource)
        {
            int intFloor = 0;

            for (int intIndex = 0; intIndex < p_strRiddleSource.Length; intIndex++)
            {
                if (p_strRiddleSource[intIndex] == '(')
                {
                    intFloor++;
                }
                else if (p_strRiddleSource[intIndex] == ')')
                {
                    intFloor--;
                }

                if (intFloor == -1)
                {
                    return intIndex + 1;
                }
            }

            return -1;
        }
    }
}