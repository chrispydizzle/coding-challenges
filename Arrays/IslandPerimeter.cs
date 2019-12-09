namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IslandPerimeterFinder
    {
        public int IslandPerimeter(int[][] grid)
        {
            int landSquareX = -1;
            int landSquareY = -1;

            // loop through entire array until we hit a 1.
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        landSquareX = j;
                        landSquareY = i;
                        break;
                    }
                }

                if (landSquareX > -1) break;
            }

            int perimeter = 0;
            //DFS from the landsquare
            Tuple<int, int> landSquare = new Tuple<int, int>(landSquareY, landSquareX);
            Stack<Tuple<int, int>> squareStacks = new Stack<Tuple<int, int>>();
            HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
            squareStacks.Push(landSquare);
            visited.Add(landSquare);
            while (squareStacks.Any())
            {
                Tuple<int, int> square = squareStacks.Pop();
                // check up
                int y = square.Item1;
                int x = square.Item2;
                if (y > 0)
                {
                    int result = grid[y - 1][x];
                    if (result == 1)
                    {
                        Tuple<int, int> landsQuare = new Tuple<int, int>(y - 1, x);
                        if (!visited.Contains(landsQuare))
                        {
                            visited.Add(landsQuare);
                            squareStacks.Push(landsQuare);
                        }
                    }
                    else
                    {
                        perimeter++;
                    }
                }
                else
                {
                    perimeter++;
                }

                // check down
                if (y < grid.Length - 1)
                {
                    int result = grid[y + 1][x];
                    if (result == 1)
                    {
                        Tuple<int, int> landsQuare = new Tuple<int, int>(y + 1, x);
                        if (!visited.Contains(landsQuare))
                        {
                            visited.Add(landsQuare);
                            squareStacks.Push(landsQuare);
                        }
                    }
                    else
                    {
                        perimeter++;
                    }
                }
                else
                {
                    perimeter++;
                }

                // check left    
                if (x > 0)
                {
                    int result = grid[y][x - 1];
                    if (result == 1)
                    {
                        Tuple<int, int> landsQuare = new Tuple<int, int>(y, x - 1);
                        if (!visited.Contains(landsQuare))
                        {
                            visited.Add(landsQuare);
                            squareStacks.Push(landsQuare);
                        }
                    }
                    else
                    {
                        perimeter++;
                    }
                }
                else
                {
                    perimeter++;
                }

                // check right
                if (x < grid[y].Length - 1)
                {
                    int result = grid[y][x + 1];
                    if (result == 1)
                    {
                        Tuple<int, int> landsQuare = new Tuple<int, int>(y, x + 1);
                        if (!visited.Contains(landsQuare))
                        {
                            visited.Add(landsQuare);
                            squareStacks.Push(landsQuare);
                        }
                    }
                    else
                    {
                        perimeter++;
                    }
                }
                else
                {
                    perimeter++;
                }
            }

            return perimeter;
        }
    }
}