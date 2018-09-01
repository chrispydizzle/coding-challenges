namespace Pdrome2.Solves
{
    internal class TasksTypes
    {
        public int[] tasksTypes(int[] deadlines, int day)
        {
            int today = 0;
            int upcoming = 0;
            int later = 0;

            foreach (int deadline in deadlines)
            {
                if (deadline <= day)
                {
                    today++;
                    continue;
                }

                if (deadline > day && deadline <= day + 7)
                {
                    upcoming++;
                    continue;
                }

                later++;
            }

            return new[] {today, upcoming, later};
        }

    }
}