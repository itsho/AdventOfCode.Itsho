using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Itsho.Solutions
{
    public static class Day7Solution
    {
        internal static int GetWireSignalResult(string p_strWireName, string p_strInput, bool p_blnPart2 = false)
        {
            Dictionary<string, ushort> dicWires = new Dictionary<string, ushort>();

            var arrRows = p_strInput.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // key = TargetWire
            // Value = Command
            SortedDictionary<string, string> dicInstructions = new SortedDictionary<string, string>();

            InitInstructions(arrRows, dicInstructions);
            
            SolvePart1(dicInstructions, ref dicWires);
            
            // part2
            if (p_blnPart2)
            {
                // fill instructions list again (since it was emptied by SolvePart1) 
                InitInstructions(arrRows, dicInstructions);

                // take the signal you got on wire a, override wire b to that signal
                dicInstructions["b"] = dicWires[p_strWireName].ToString();// + " -> b";

                dicWires.Clear();

                SolvePart1(dicInstructions, ref dicWires);
            }
            return dicWires[p_strWireName];
        }

        private static void InitInstructions(string[] arrRows, SortedDictionary<string, string> dicInstructions)
        {
            foreach (var strSingleLine in arrRows)
            {
                var arrInstructions = strSingleLine.Split(new string[] {" -> "}, StringSplitOptions.None);
                var strCommand = arrInstructions[0];
                var chrWireTarget = arrInstructions[1];
                dicInstructions.Add(chrWireTarget, strCommand);
            }
        }

        private static void SolvePart1(SortedDictionary<string, string> dicInstructions, ref Dictionary<string, ushort> dicWires)
        {
            // run all of the instructions.
            while (dicInstructions.Any())
            {
                var lstKeysToRemove = new List<string>();

                foreach (var kvpItem in dicInstructions)
                {
                    if (ParseInputPart1(kvpItem, ref dicWires))
                    {
                        lstKeysToRemove.Add(kvpItem.Key);
                    }
                }

                // remove all solved items
                foreach (var strKeyToRemove in lstKeysToRemove)
                {
                    dicInstructions.Remove(strKeyToRemove);
                }
            }
        }

        private static bool ParseInputPart1(KeyValuePair<string, string> p_commandAndTarget, ref Dictionary<string, ushort> p_dicWires)
        {
            var strWireTarget = p_commandAndTarget.Key;
            var strCommand = p_commandAndTarget.Value;

            ushort newValue = UInt16.MinValue;

            // no command, signal value provided
            if (!strCommand.Contains(" "))
            {
                // if value provided is actually wire name
                if (IsString(strCommand))
                {
                    // if source not exists
                    if (!RunIfInList(strCommand, null, ref p_dicWires, (dicWires) =>
                    {
                        newValue = dicWires[strCommand];
                    }))
                    {
                        // unable to resolve
                        return false;
                    }
                }
                // value is a number (probably :-(  )
                else
                {
                    // parse number
                    ushort.TryParse(strCommand, out newValue);
                }
            }
            else if (strCommand.Contains(" AND "))
            {
                var arrSourceAndTarget = strCommand.Split(new string[] { " AND " }, StringSplitOptions.None);

                // if source & target are wires
                if (IsString(arrSourceAndTarget[0]) && IsString(arrSourceAndTarget[1]))
                {
                    // if source not exists
                    if (!RunIfInList(arrSourceAndTarget[0], arrSourceAndTarget[1], ref p_dicWires, (dicWires) =>
                    {
                        // use source
                        newValue = (ushort)(dicWires[arrSourceAndTarget[0]] & dicWires[arrSourceAndTarget[1]]);
                    }))
                    {
                        // unable to resolve
                        return false;
                    }
                }
                // source is number, target is wire
                else if (!IsString(arrSourceAndTarget[0]) && IsString(arrSourceAndTarget[1]))
                {
                    // if target not exists
                    if (!RunIfInList(arrSourceAndTarget[1], null, ref p_dicWires, (dicWires) =>
                    {
                        newValue = (ushort)(Convert.ToInt16(arrSourceAndTarget[0]) & dicWires[arrSourceAndTarget[1]]);
                    }))
                    {
                        // unable to resolve
                        return false;
                    }
                }

                // source is wire, target is number
                else if (IsString(arrSourceAndTarget[0]) && !IsString(arrSourceAndTarget[1]))
                {
                    // if source not exists
                    if (!RunIfInList(arrSourceAndTarget[0], null, ref p_dicWires, (dicWires) =>
                    {
                        newValue = (ushort)(dicWires[arrSourceAndTarget[0]] & Convert.ToInt16(arrSourceAndTarget[1]));
                    }))
                    {
                        // unable to resolve
                        return false;
                    }
                }
                else
                {
                }
            }
            else if (strCommand.Contains(" OR "))
            {
                var arrSourceLshiftTarget = strCommand.Split(new string[] { " OR " }, StringSplitOptions.None);

                // if source not exists
                if (!RunIfInList(arrSourceLshiftTarget[0], arrSourceLshiftTarget[1], ref p_dicWires, (dicWires) =>
                {
                    // use source
                    newValue = (ushort)(dicWires[arrSourceLshiftTarget[0]] | dicWires[arrSourceLshiftTarget[1]]);
                }))
                {
                    // unable to resolve
                    return false;
                }
            }
            else if (strCommand.Contains(" LSHIFT "))
            {
                var arrSourceLshiftTarget = strCommand.Split(new string[] { " LSHIFT " }, StringSplitOptions.None);

                int intTargetNumber = Convert.ToInt32(arrSourceLshiftTarget[1]);

                // if target is a number
                if (!IsString(arrSourceLshiftTarget[1]))
                {
                    // if source exists
                    if (!RunIfInList(arrSourceLshiftTarget[0], null, ref p_dicWires, (dicWires) =>
                    {
                        // use source
                        newValue = (ushort)(dicWires[arrSourceLshiftTarget[0]] << intTargetNumber);
                    }))
                    {
                        // unable to resolve
                        return false;
                    }
                }
                // target is wire
                // if source exists
                else if (!RunIfInList(arrSourceLshiftTarget[0], arrSourceLshiftTarget[1], ref p_dicWires, (dicWires) =>
               {
                   // use wire
                   newValue = (ushort)(dicWires[arrSourceLshiftTarget[0]] << dicWires[arrSourceLshiftTarget[1]]);
               }))
                {
                    // if source/target not exists - unable to solve
                    return false;
                }
            }
            else if (strCommand.Contains(" RSHIFT "))
            {
                var arrSourceLshiftTarget = strCommand.Split(new string[] { " RSHIFT " }, StringSplitOptions.None);

                // if target is a number
                if (!IsString(arrSourceLshiftTarget[1]))
                {
                    // if source exists
                    if (!RunIfInList(arrSourceLshiftTarget[0], null, ref p_dicWires, (dicWires) =>
                    {
                        int intTargetNumber = Convert.ToInt32(arrSourceLshiftTarget[1]);

                        // use source
                        newValue = (ushort)(dicWires[arrSourceLshiftTarget[0]] >> intTargetNumber);
                    }))
                    {
                        // if source not exists - unable to solve
                        return false;
                    }
                }
                // target is wire, so check if source and target exists
                else if (!RunIfInList(arrSourceLshiftTarget[0], arrSourceLshiftTarget[1], ref p_dicWires, (dicWires) =>
                {
                    // use wire
                    newValue = (ushort)(dicWires[arrSourceLshiftTarget[0]] >> dicWires[arrSourceLshiftTarget[1]]);
                }))
                {
                    // if source or target not exists - unable to solve
                    return false;
                }
            }
            else if (strCommand.Contains("NOT "))
            {
                var arrSourceLshiftTarget = strCommand.Split(new string[] { "NOT " }, StringSplitOptions.None);

                if (!RunIfInList(arrSourceLshiftTarget[1], null, ref p_dicWires, (dicWires) =>
                      {
                          newValue = (ushort)~(dicWires[arrSourceLshiftTarget[1]]);
                      }))
                {
                    // if source or target not exists - unable to solve
                    return false;
                }
            }
            else
            {
                newValue = 0;
            }

            if (newValue == UInt16.MinValue)
            {
                //Debugger.Break();
            }

            if (p_dicWires.ContainsKey(strWireTarget))
            {
                p_dicWires[strWireTarget] = newValue;
            }
            else
            {
                p_dicWires.Add(strWireTarget, newValue);
            }

            return true;
        }

        private static bool RunIfInList(string p_strWireName, string p_strSecondWireName, ref Dictionary<string, ushort> p_dicWires, Action<Dictionary<string, ushort>> p_actionToRun)
        {
            if (p_dicWires.ContainsKey(p_strWireName) &&
                (p_strSecondWireName == null ||
                !string.IsNullOrEmpty(p_strSecondWireName) && p_dicWires.ContainsKey(p_strSecondWireName)))
            {
                p_actionToRun(p_dicWires);
                return true;
            }
            return false;
        }

        private static bool IsString(string p_strData)
        {
            if (Regex.Matches(p_strData, @"[a-zA-Z]").Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}