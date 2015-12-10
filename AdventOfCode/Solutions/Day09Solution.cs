using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Itsho.Solutions
{
    public static class Day09Solution
    {
        public static int GetRouteDistance(string[] p_arrInput, bool p_blnFindShortestRoute)
        {
            // Key= Destination City name
            // Value = class of that city
            Dictionary<string, Day09SingleDestination> lstAllDestinations = new Dictionary<string, Day09SingleDestination>();

            #region Parse input

            foreach (var strSingleRoute in p_arrInput)
            {
                // example line
                // "Tristram to AlphaCentauri = 34"
                var arrRoute = strSingleRoute.Split(' ');

                #region single inputline is actually 4 lines:

                // #1  add Tristram as destination
                if (!lstAllDestinations.ContainsKey(arrRoute[0]))
                {
                    lstAllDestinations.Add(arrRoute[0], new Day09SingleDestination(arrRoute[0]));
                }
                // #2  add AlphaCentauri as destination  
                if (!lstAllDestinations.ContainsKey(arrRoute[2]))
                {
                    lstAllDestinations.Add(arrRoute[2], new Day09SingleDestination(arrRoute[2]));
                }

                // #3   Tristram to AlphaCentauri = 34
                lstAllDestinations[arrRoute[0]].Routes.Add(int.Parse(arrRoute[4]), lstAllDestinations[arrRoute[2]]);

                // #4   AlphaCentauri to Tristram = 34
                lstAllDestinations[arrRoute[2]].Routes.Add(int.Parse(arrRoute[4]), lstAllDestinations[arrRoute[0]]);

                #endregion single inputline is actually 4 lines:
            }

            #endregion Parse input

            // shortest route
            if (p_blnFindShortestRoute)
            {

                // init Shortest Distance
                int intShortestDistance = int.MaxValue;

                foreach (var ds in lstAllDestinations.Values)
                {
                    int intDistance = ds.GetDistanceByExistingRoutes(true);
                    if (intDistance < intShortestDistance)
                    {
                        intShortestDistance = intDistance;
                    }

                    // for next run
                    foreach (var ds2 in lstAllDestinations.Values)
                    {
                        ds2.IsUsed = false;
                    }
                }

                return intShortestDistance;
            }


            // longest route
            // init Longest Distance
            int intLongestDistance = 0;

            foreach (var ds in lstAllDestinations.Values)
            {
                int intDistance = ds.GetDistanceByExistingRoutes(false);
                if (intDistance > intLongestDistance)
                {
                    intLongestDistance = intDistance;
                }

                // reset visited status for next run.
                foreach (var ds2 in lstAllDestinations.Values)
                {
                    ds2.IsUsed = false;
                }
            }

            return intLongestDistance;
        }
     
    }
}