using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Itsho.Solutions
{
    public class Day09SingleDestination
    {
        public bool IsUsed { get; set; }

        public string Name { get; private set; }

        /// <summary>
        /// sort by shortest distance
        /// </summary>
        public Dictionary<int, Day09SingleDestination> Routes { get; private set; }

        public Day09SingleDestination(string p_strName)
        {
            Name = p_strName;
            Routes = new Dictionary<int, Day09SingleDestination>();
        }

        public int GetDistanceByExistingRoutes(bool p_blnSortByShortest)
        {
            IsUsed = true;
            int intTotalDistance;

            if (!Routes.Any(r => !r.Value.IsUsed))
            {
                intTotalDistance = 0;
            }
            else
            {
                // get first destination not being used
                var lstRoutesSorted = Routes.OrderBy(r => r.Key);

                // sort by longest
                if (!p_blnSortByShortest)
                {
                    lstRoutesSorted = Routes.OrderByDescending(r => r.Key);
                }
                var firstDest = lstRoutesSorted.FirstOrDefault(r => !r.Value.IsUsed);

                // get distance from first dest and distance from dest and on
                intTotalDistance = firstDest.Key + firstDest.Value.GetDistanceByExistingRoutes(p_blnSortByShortest);
            }
            return intTotalDistance;
        }
    }
}