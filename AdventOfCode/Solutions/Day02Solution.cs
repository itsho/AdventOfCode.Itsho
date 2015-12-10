using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Itsho.Solutions
{
    public static class Day02Solution
    {
        #region public methods

        public static int GetWrappingTotal(string[] p_arrRiddleSource)
        {

            int intTotal = 0;

            foreach (var strBox in p_arrRiddleSource)
            {
                var box = GetSizeDimensions(strBox);

                intTotal += GetWrappingSingleBox(box);
            }

            return intTotal;
        }

        public static int GetRibbon(string[] p_arrRiddleSource)
        {
            int intTotal = 0;

            foreach (var strBox in p_arrRiddleSource)
            {
                var box = GetSizeDimensions(strBox);
                var smallestSide = GetSmallestSide(box.Length, box.Width, box.Height);

                // get ribbon + bow ribbon
                intTotal += 2 * smallestSide.Item1 + 2 * smallestSide.Item2 +
                            box.Length * box.Height * box.Width;
            }

            return intTotal;
        }

        #endregion public methods

        #region private methods

        private static Tuple<int, int> GetSmallestSide(params int[] p_ints)
        {
            List<int> lstInts = p_ints.ToList();
            lstInts.Sort();
            return new Tuple<int, int>(lstInts[0], lstInts[1]);
        }

        private static Day02Box GetSizeDimensions(string p_strSingleBox)
        {
            if (string.IsNullOrEmpty(p_strSingleBox))
            {
                throw new ArgumentNullException("p_strSingleBox");
            }

            var arrBoxDetail = p_strSingleBox.Split('x');

            return new Day02Box()
            {
                Length = Convert.ToInt32(arrBoxDetail[0]),
                Width = Convert.ToInt32(arrBoxDetail[1]),
                Height = Convert.ToInt32(arrBoxDetail[2])
            };
        }

        private static int GetWrappingSingleBox(Day02Box p_box)
        {
            //AreaOfBox = 2*l*w + 2*w*h + 2*h*l
            var intSurfaceArea = 2 * p_box.Length * p_box.Width + 2 * p_box.Width * p_box.Height + 2 * p_box.Height * p_box.Length;

            // extra is the size of the smallest side (x*y)
            var smallestSide = GetSmallestSide(p_box.Length, p_box.Width, p_box.Height);
            var intExtra = smallestSide.Item1 * smallestSide.Item2;

            return intSurfaceArea + intExtra;
        }

        #endregion private methods
    }
}