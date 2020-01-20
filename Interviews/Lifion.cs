namespace CodeChallenges.Interviews
{
    using System;
    using System.Collections.Generic;

    public class Lifion
    {
        public static Dictionary<int, List<Tuple<int, int>>> peopleInoffice;

        public bool canSchedule(int[] peopleIds, int start, int end)
        {
            // go through peopleIds
            for (int i = 0; i < peopleIds.Length; i++)
            {
                int empId = peopleIds[i];
                if (!peopleInoffice.ContainsKey(empId)) return false;


                // full list of times
                var times = peopleInoffice[empId];
                bool isAvail = false;
                foreach (var timeSet in times)
                {
                    int startTime = timeSet.Item1;
                    int endTime = timeSet.Item2;
                    if ((startTime <= start && endTime >= end))
                    {
                        isAvail = true;
                        break;
                    }
                }

                if (!isAvail) return false;
            }
            // check dict for peopleid
            // check the list for an entry that falls within start and end
            // if any are not return false

            return true;
        }
    }
}