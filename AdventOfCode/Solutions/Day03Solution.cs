using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Itsho.Solutions
{
    public static class Day03Solution
    {
        public static int GetHousesWithOnePresent(string p_strHouses, bool p_blnIsRoboSantaWorking=false)
        {
            Dictionary<Day03House, int> dicHousesVisitedCounter = new Dictionary<Day03House, int>();

            // first location - one house is always being delivered
            Day03House lastSantaHouse = new Day03House(0, 0);
            Day03House lastRoboSantaHouse = lastSantaHouse;

            dicHousesVisitedCounter.Add(lastSantaHouse, 1);

            // if robosanta working
            if (p_blnIsRoboSantaWorking)
            {
                // first house gets two presents.
                dicHousesVisitedCounter[lastRoboSantaHouse]++;
            }

            for (int intHouseIndex = 0; intHouseIndex < p_strHouses.Length; intHouseIndex++)
            {
                char chrDirection = p_strHouses[intHouseIndex];

                Day03House lastHouse = lastSantaHouse;

                // if this is a robo-santa step
                if (p_blnIsRoboSantaWorking && intHouseIndex%2 == 0)
                {
                    lastHouse = lastRoboSantaHouse;
                }

                #region Walk

                // north
                if (chrDirection == '^')
                {
                    lastHouse = new Day03House(lastHouse.LocationX, lastHouse.LocationY + 1);
                }
                //south
                else if (chrDirection == 'v' || chrDirection == 'V')
                {
                    lastHouse = new Day03House(lastHouse.LocationX, lastHouse.LocationY - 1);
                }
                //east
                else if (chrDirection == '>')
                {
                    lastHouse = new Day03House(lastHouse.LocationX + 1, lastHouse.LocationY);
                }
                //west
                else if (chrDirection == '<')
                {
                    lastHouse = new Day03House(lastHouse.LocationX - 1, lastHouse.LocationY);
                }
                
                #endregion


                // if this is a robo-santa step
                if (p_blnIsRoboSantaWorking && intHouseIndex % 2 == 0)
                {
                    // update reference
                    lastRoboSantaHouse = lastHouse;
                }
                // if that's santa
                else
                {
                    // update reference
                    lastSantaHouse = lastHouse;
                }

                #region update counter

                // check if house was already visited
                var foundHouse = (from house in dicHousesVisitedCounter.Keys
                                  where house.LocationX == lastHouse.LocationX &&
                                        house.LocationY == lastHouse.LocationY
                                  select house).FirstOrDefault();

                if (foundHouse != null)
                {
                    dicHousesVisitedCounter[foundHouse]++;
                }
                else
                {
                    dicHousesVisitedCounter.Add(lastHouse, 1);
                } 

                #endregion
            }

            return dicHousesVisitedCounter.Count;
        }
    }
}