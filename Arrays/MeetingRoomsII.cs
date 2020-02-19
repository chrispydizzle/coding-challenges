namespace CodeChallenges.Arrays
{
    public class MeetingRoomsII
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            int min = int.MaxValue, max = int.MinValue;

            // loop through my intervals, finding the min and max
            foreach (var intr in intervals)
            {
                if (intr[0] < min)
                {
                    min = intr[0];
                }

                if (intr[1] > max)
                {
                    max = intr[1];
                }
            }

            int[] timeline = new int[max - min + 1];

            foreach (var intr in intervals)
            {
                timeline[intr[0] - min] += 1;
                timeline[intr[1] - min] -= 1;
            }

            int activeMeetings = 0;
            int mostAsync = 0;
            foreach (int time in timeline)
            {
                activeMeetings += time;
                if (activeMeetings > mostAsync)
                {
                    mostAsync = activeMeetings;
                }
            }

            return mostAsync;
        }
    }
}