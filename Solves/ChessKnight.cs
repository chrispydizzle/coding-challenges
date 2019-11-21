namespace CodeChallenges.Solves
{
    using System;

    internal class ChessKnight
    {
        public int chessKnight(string cell)
        {
            int validMoves = 0;
            char bColumn = cell[0];
            int bRow = int.Parse(cell[1].ToString());
            Tuple<int, int>[] knightMoves =
            {
                new Tuple<int, int>(-1, -2),
                new Tuple<int, int>(-2, -1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(-1, 2),
                new Tuple<int, int>(-2, 1),
                new Tuple<int, int>(1, -2),
                new Tuple<int, int>(2, -1)
            };

            for (int i = 0; i < knightMoves.Length; i++)
            {
                int column = knightMoves[i].Item1;
                int row = knightMoves[i].Item2;

                char newColumn = (char) (bColumn + column);
                int newRow = bRow + row;
                if (newColumn >= 'a' && newColumn <= 'h' && newRow > 0 && newRow < 9)
                {
                    validMoves++;
                }
            }

            return validMoves;
        }
    }
}