using System;

namespace AdventOfCode.Itsho.Solutions
{
    public static class Day06Solution
    {
        internal static int GetTurnedLights1(string[] p_arrInput)
        {
            bool[,] arrLights = new bool[1000, 1000];
            arrLights.Initialize();

            foreach (var strSingleInstructionsRow in p_arrInput)
            {
                ParseRowPart1(strSingleInstructionsRow, ref arrLights);
            }

            int intLightCounter = 0;
            for (int intCurrX = 0; intCurrX < arrLights.GetLength(0); intCurrX++)
            {
                for (int intCurrY = 0; intCurrY < arrLights.GetLength(1); intCurrY++)
                {
                    if (arrLights[intCurrX, intCurrY])
                    {
                        intLightCounter++;
                    }
                }
            }

            return intLightCounter;
        }

        private static void ParseRowPart1(string p_strSingleInstructionsRow, ref bool[,] p_arrLights)
        {
            var arrInstructions = p_strSingleInstructionsRow.Split(' ');
            var strCommand = arrInstructions[0];
            var strStart = arrInstructions[1];
            var strEnd = arrInstructions[3];

            if (strCommand == "turn")
            {
                strCommand += " " + arrInstructions[1];
                strStart = arrInstructions[2];
                strEnd = arrInstructions[4];
            }

            bool? blnNewValue = null;
            if (strCommand == "turn on")
            {
                blnNewValue = true;
            }
            else if (strCommand == "turn off")
            {
                blnNewValue = false;
            }
            else if (strCommand == "toggle")
            {
                blnNewValue = null;
            }

            var arrStartLocation = strStart.Split(',');
            var arrEndLocation = strEnd.Split(',');

            for (int intCurrX = Convert.ToInt32(arrStartLocation[0]); intCurrX <= Convert.ToInt32(arrEndLocation[0]); intCurrX++)
            {
                for (int intCurrY = Convert.ToInt32(arrStartLocation[1]); intCurrY <= Convert.ToInt32(arrEndLocation[1]); intCurrY++)
                {
                    if (blnNewValue.HasValue)
                    {
                        p_arrLights[intCurrX, intCurrY] = blnNewValue.Value;
                    }
                    else
                    {
                        p_arrLights[intCurrX, intCurrY] = !p_arrLights[intCurrX, intCurrY];
                    }
                }
            }
        }

        internal static long GetTurnedLights2(string[] p_arrInput)
        {
            int[,] arrLights = new int[1000, 1000];
            arrLights.Initialize();

            foreach (var strSingleInstructionsRow in p_arrInput)
            {
                ParseRowPart2(strSingleInstructionsRow, ref arrLights);
            }

            long lngLightCounter = 0;
            for (int intCurrX = 0; intCurrX < arrLights.GetLength(0); intCurrX++)
            {
                for (int intCurrY = 0; intCurrY < arrLights.GetLength(1); intCurrY++)
                {
                    lngLightCounter += (arrLights[intCurrX, intCurrY]);
                }
            }

            return lngLightCounter;
        }

        private static void ParseRowPart2(string p_strSingleInstructionsRow, ref int[,] p_arrLights)
        {
            var arrInstructions = p_strSingleInstructionsRow.Split(' ');
            var strCommand = arrInstructions[0];
            var strStart = arrInstructions[1];
            var strEnd = arrInstructions[3];

            if (strCommand == "turn")
            {
                strCommand += " " + arrInstructions[1];
                strStart = arrInstructions[2];
                strEnd = arrInstructions[4];
            }

            int intNewValue = 0;
            if (strCommand == "turn on")
            {
                intNewValue++;
            }
            else if (strCommand == "turn off")
            {
                intNewValue--;
            }
            else if (strCommand == "toggle")
            {
                intNewValue += 2;
            }
            
            var arrStartLocation = strStart.Split(',');
            var arrEndLocation = strEnd.Split(',');

            for (int intCurrX = Convert.ToInt32(arrStartLocation[0]); intCurrX <= Convert.ToInt32(arrEndLocation[0]); intCurrX++)
            {
                for (int intCurrY = Convert.ToInt32(arrStartLocation[1]); intCurrY <= Convert.ToInt32(arrEndLocation[1]); intCurrY++)
                {
                    // if we will get below minimum
                    if (p_arrLights[intCurrX, intCurrY] + intNewValue < 0)
                    {
                        // reset brightness to zero
                        p_arrLights[intCurrX, intCurrY] = 0;
                    }
                    else
                    {
                        p_arrLights[intCurrX, intCurrY] += intNewValue;
                    }
                }
            }
        }
    }
}