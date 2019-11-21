namespace CodeChallenges.Solves
{
    using System;
    using System.Collections.Generic;

    internal class Sudoku2
    {
        public bool sudoku2(char[][] grid)
        {
            List<char>[] colUniq = new List<char>[grid.Length];
            List<char>[][] boxUniq = new List<char>[3][];
            for (int i = 0; i < grid.Length; i++)
            {
                if (i % 3 == 0)
                {
                    boxUniq[i / 3] = new List<char>[3];
                }

                List<char> rowUniq = new List<char>();

                for (int j = 0; j < grid[i].Length; j++)
                {
                    char c = grid[i][j];

                    if (j % 3 == 0 && i % 3 == 0)
                    {
                        boxUniq[i / 3][j / 3] = new List<char>();
                    }

                    if (i == 0)
                    {
                        colUniq[j] = new List<char>();
                    }

                    if (c == '.')
                    {
                        continue;
                    }

                    if (rowUniq.Contains(c))
                    {
                        return false;
                    }

                    if (colUniq[j].Contains(c))
                    {
                        return false;
                    }

                    if (boxUniq[i / 3][j / 3].Contains(c))
                    {
                        return false;
                    }

                    rowUniq.Add(c);
                    colUniq[j].Add(c);
                    boxUniq[i / 3][j / 3].Add(c);
                }
            }

            return true;
        }

        public void SudokuMain(string[] args)
        {
            Sudoku2 a = new Sudoku2();
            Console.WriteLine(a.sudoku2(new[]
                {
                    new[] {'.', '.', '.', '.', '2', '.', '.', '9', '.'},
                    new[] {'.', '.', '.', '.', '6', '.', '.', '.', '.'},
                    new[] {'7', '1', '.', '.', '7', '5', '.', '.', '.'},
                    new[] {'.', '7', '.', '.', '.', '.', '.', '.', '.'},
                    new[] {'.', '.', '.', '.', '8', '3', '.', '.', '.'},
                    new[] {'.', '.', '8', '.', '.', '7', '.', '6', '.'},
                    new[] {'.', '.', '.', '.', '.', '2', '.', '.', '.'},
                    new[] {'.', '1', '.', '2', '.', '.', '.', '.', '.'},
                    new[] {'.', '2', '.', '.', '3', '.', '.', '.', '.'}
                }
            ));

            Console.WriteLine(a.sudoku2(new[]
            {
                new[]
                {
                    '7', '.', '.', '.', '4', '.', '.', '.', '.'
                },
                new[]
                {
                    '.', '.', '.', '8', '6', '5', '.', '.', '.'
                },
                new[]
                {
                    '.', '1', '.', '2', '.', '.', '.', '.', '.'
                },
                new[]
                {
                    '.', '.', '.', '.', '.', '9', '.', '.', '.'
                },
                new[]
                {
                    '.', '.', '.', '.', '5', '.', '5', '.', '.'
                },
                new[]
                {
                    '.', '.', '.', '.', '.', '.', '.', '.', '.'
                },
                new[]
                {
                    '.', '.', '.', '.', '.', '.', '2', '.', '.'
                },
                new[]
                {
                    '.', '.', '.', '.', '.', '.', '.', '.', '.'
                },
                new[]
                {
                    '.', '.', '.', '.', '.', '.', '.', '.', '.'
                }
            }));

            Console.WriteLine(a.sudoku2(new[]
                {
                    new[] {'.', '4', '.', '.', '.', '.', '.', '.', '.'},
                    new[] {'.', '.', '4', '.', '.', '.', '.', '.', '.'},
                    new[] {'.', '.', '.', '1', '.', '.', '7', '.', '.'},
                    new[] {'.', '.', '.', '.', '.', '.', '.', '.', '.'},
                    new[] {'.', '.', '.', '3', '.', '.', '.', '6', '.'},
                    new[] {'.', '.', '.', '.', '.', '6', '.', '9', '.'},
                    new[] {'.', '.', '.', '.', '1', '.', '.', '.', '.'},
                    new[] {'.', '.', '.', '.', '.', '.', '2', '.', '.'},
                    new[] {'.', '.', '.', '8', '.', '.', '.', '.', '.'}
                }
            ));

            Console.ReadLine();
        }
    }
}