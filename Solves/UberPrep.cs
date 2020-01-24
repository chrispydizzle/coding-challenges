namespace CodeChallenges.Interviews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UberPrep
    {
        public string cosestLocation(string address, int[][] objects, string[] names)
        {
            int largestCalc = address.Length + 1;
            address = address.ToLower();

            List<int> candidates = new List<int>();
            int[][] dpTable = new int[largestCalc][];

            for (int str = 0; str < names.Length; str++)
            {
                string name = names[str].ToLower().Substring(0, Math.Min(address.Length, names[str].Length)).Trim();
                if (name.Length < address.Length && address.Length - name.Length > 1)
                    continue;
                for (int i = 0; i < address.Length + 1; i++)
                {
                    dpTable[i] = new int[name.Length + 1];
                }

                for (int i = 0; i < address.Length + 1; i++)
                {
                    for (int j = 0; j < name.Length + 1; j++)
                    {
                        if (i == 0)
                        {
                            dpTable[i][j] = j;
                            continue;
                        }

                        if (j == 0)
                        {
                            dpTable[i][j] = i;
                            continue;
                        }

                        int prevC = dpTable[i][j - 1];
                        int prevR = dpTable[i - 1][j];
                        int prevRC = dpTable[i - 1][j - 1];

                        if (address[i - 1] == name[j - 1])
                        {
                            dpTable[i][j] = 1 + new[] {prevC, prevR, prevRC - 1}.Min();
                        }
                        else
                        {
                            dpTable[i][j] = 1 + new[] {prevC, prevR, prevRC}.Min();
                        }
                    }
                }

                if (dpTable.Last().Last() >= name.Length) continue;

                candidates.Add(str);
            }

            // got valid strings, now find closest.

            int[] distance = new int [candidates.Count];
            int minDistance = int.MaxValue;
            for (int i = 0; i < objects.Length; i++)
            {
                var objectDetail = objects[i];
                if (objectDetail.Length == 2)
                {
                    minDistance = (int) Math.Min(minDistance, Math.Sqrt(objectDetail[0] * (objectDetail[0]) + (objectDetail[1] * objectDetail[1])));
                }
                else
                {
                    int xTarget = objectDetail[0] == objectDetail[2] ? objectDetail[2] : Enumerable.Range(objectDetail[0], objectDetail[2]).Select(Math.Abs).Min();
                    int yTarget = objectDetail[1] == objectDetail[3] ? objectDetail[1] : Enumerable.Range(objectDetail[1], objectDetail[3]).Select(Math.Abs).Min();

                    minDistance = (int) Math.Min(minDistance, Math.Sqrt((xTarget) * (xTarget) + (yTarget * yTarget)));
                }

                distance[i] = minDistance;
            }

            int min = distance.Min();

            for (int i = 0; i < distance.Length; i++)
            {
                if (distance[i] == min)
                {
                    return names[i];
                }
            }

            return string.Empty;
        }

        public int nightRoute(int[][] city)
        {
            int targetCity = city.Length - 1;
            // naive approach is to bf this.

            HashSet<int> visitedCities = new HashSet<int>();
            return Move(0, 0, int.MaxValue, city);
        }

        int Move(int currentCity, int currentDistance, int minDistance, int[][] city)
        {
            if (currentCity == city.Length - 1) return currentDistance;

            for (int i = city.Length - 1; i > 0; i--)
            {
                if (city[currentCity][i] == -1 || // don't go to cities we can't go to
                    city[currentCity][i] + currentDistance > minDistance) // don't go to cities that would be longer than our current min distance
                    continue;

                int[][] visitedCityMatrix = new int[city.Length][];
                // Array.Copy(city, visitedCityMatrix, city.Length);

                for (int j = 0; j < city.Length - 1; j++)
                {
                    visitedCityMatrix[j] = new int[city.Length];
                    city[j].CopyTo(visitedCityMatrix[j], 0);
                    visitedCityMatrix[j][i] = -1; // for the current i, set next city to 01
                }

                minDistance = Math.Min(minDistance, Move(i, currentDistance + city[currentCity][i], minDistance, visitedCityMatrix));
            }

            return minDistance;
        }

        public bool parkingSpot(int[] carDimensions, int[][] parkingLot, int[] luckySpot)
        {
            // check lucky spot
            for (int x = luckySpot[0]; x <= luckySpot[2]; x++)
            {
                for (int y = luckySpot[1]; y <= luckySpot[3]; y++)
                {
                    if (parkingLot[x][y] == 1)
                    {
                        return false;
                    }
                }
            }

            int longSide = carDimensions[0] > carDimensions[1] ? carDimensions[0] : carDimensions[1];
            //int carY = carDimensions[1];
            int spotRows = Math.Abs(luckySpot[0] - luckySpot[2]) + 1;
            int spotCols = Math.Abs(luckySpot[1] - luckySpot[3]) + 1;

            bool goHoriz = false;
            bool goVert = false;


            if (spotRows == longSide) goVert = true;
            if (spotCols == longSide) goHoriz = true;

            bool validPath = true;
            if (goVert)
            {
                for (int x = 0; x < luckySpot[0]; x++)
                {
                    for (int y = luckySpot[1]; y > luckySpot[3]; y++)
                    {
                        if (parkingLot[x][y] == 1)
                        {
                            validPath = false;
                            break;
                        }
                    }

                    if (!validPath) break;
                }

                if (validPath) return true;

                validPath = true;
                for (int x = parkingLot.Length - 1; x > luckySpot[2]; x--)
                {
                    for (int y = luckySpot[1]; y > luckySpot[3]; y++)
                    {
                        if (parkingLot[x][y] == 1)
                        {
                            validPath = false;
                            break;
                        }
                    }

                    if (!validPath) break;
                }

                if (validPath) return true;
            }

            if (goHoriz)
            {
                validPath = true;
                for (int x = luckySpot[0]; x < luckySpot[2]; x++)
                {
                    for (int y = 0; y < luckySpot[1]; y++)
                    {
                        if (parkingLot[x][y] == 1)
                        {
                            validPath = false;
                            break;
                        }
                    }

                    if (!validPath) break;
                }

                if (validPath) return true;

                validPath = true;
                for (int x = luckySpot[0]; x < luckySpot[2]; x++)
                {
                    for (int y = parkingLot[0].Length - 1; y > luckySpot[3]; y--)
                    {
                        if (parkingLot[x][y] == 1)
                        {
                            validPath = false;
                            break;
                        }
                    }

                    if (!validPath) break;
                }
            }

            return validPath;
        }

        bool PathHelper(int xStart, int yStart, int xEnd, int yEnd, int[][] parkingLot)
        {
            Func<int, int> xAction;
            Func<int, int> yAction;
            Func<int, bool> xFunc;
            Func<int, bool> yFunc;
            if (xStart < xEnd)
            {
                xAction = x => x - 1;
                xFunc = x => x < xEnd;
            }
            else
            {
                xAction = x => x + 1;
                xFunc = x => x > xEnd;
            }

            if (yStart < yEnd)
            {
                yAction = y => y - 1;
                yFunc = y => y < yEnd;
            }
            else
            {
                yAction = y => y + 1;
                yFunc = y => y > yEnd;
            }

            bool validPath = true;
            for (int x = xStart; xFunc(x); xAction(x))
            {
                for (int y = yStart; yFunc(y); yAction(y))
                {
                    if (parkingLot[x][y] == 1)
                    {
                        validPath = false;
                        break;
                    }
                }

                if (!validPath) break;
            }

            return validPath;
        }
    }
}