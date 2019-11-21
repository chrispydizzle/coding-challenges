namespace CodeChallenges.Solves
{
    using System.Collections.Generic;

    internal class ChessBoardCellColor
    {
        public bool chessBoardCellColor(string cell1, string cell2)
        {
            Dictionary<string, int> letterCell = new Dictionary<string, int>();
            letterCell.Add("A", 1);
            letterCell.Add("B", 2);
            letterCell.Add("C", 3);
            letterCell.Add("D", 4);
            letterCell.Add("E", 5);
            letterCell.Add("F", 6);
            letterCell.Add("G", 7);
            letterCell.Add("H", 8);

            int oneX = letterCell[cell1.Substring(0, 1)] - 1;
            int oneY = int.Parse(cell1.Substring(1, 1));

            bool oneWhiteColor = oneY % 2 == 0;

            while (oneX >= 0)
            {
                oneWhiteColor = !oneWhiteColor;
                oneX--;
            }

            int twoX = letterCell[cell2.Substring(0, 1)] - 1;
            int twoY = int.Parse(cell2.Substring(1, 1));

            bool twoWhiteColor = twoY % 2 == 0;

            while (twoX >= 0)
            {
                twoWhiteColor = !twoWhiteColor;
                twoX--;
            }

            return oneWhiteColor == twoWhiteColor;
        }
    }
}