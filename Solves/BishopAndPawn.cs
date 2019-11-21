namespace CodeChallenges.Solves
{
    internal class BishopAndPawn
    {
        public bool bishopAndPawn(string bishop, string pawn)
        {
            char bColumn = bishop[0];
            int bRow = int.Parse(bishop[1].ToString());
            for (int i = 1; i < 9; i++)
            {
                string left = ((char) (bColumn - 1 * i)).ToString();
                string right = ((char) (bColumn + 1 * i)).ToString();
                string up = (bRow + 1 * i).ToString();
                string down = (bRow - 1 * i).ToString();

                if (pawn == $"{left}{up}") return true;
                if (pawn == $"{right}{up}") return true;
                if (pawn == $"{left}{down}") return true;
                if (pawn == $"{right}{down}") return true;
            }

            return false;
        }
    }
}