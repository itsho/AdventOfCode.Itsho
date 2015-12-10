using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Itsho.Solutions
{
    [DebuggerDisplay("X:{LocationX} Y:{LocationY}")]
    public class Day03House
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public Day03House(int p_intLocationX, int p_intLocationY)
        {
            LocationX = p_intLocationX;
            LocationY = p_intLocationY;
        }

    }
}
