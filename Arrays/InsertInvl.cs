namespace CodeChallenges.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InsertInvl
    {
        // TODO: this is awful, need to redo.
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int nS = newInterval[0];
            int nE = newInterval[1];

            List<int[]> l = intervals.ToList();

//        Console.WriteLine($"Begin {newInterval}");
            // check if our newIntvl is the smallest in the set.
            if (l.Count == 0 || nE < l[0][0])
            {
                l.Insert(0, newInterval);
                return l.ToArray();
            }

            // or starts before the first in the set
            int oMatch = -1;
            int startAt = 0;
            if (nS <= l[0][0])
            {
                oMatch = 0;
                l[0][0] = nS;
                startAt = 1;
            }


            for (int i = startAt; i < l.Count; i++)
            {
                var o = l[i];
                // iterate through intvls,

                //Console.WriteLine($"at {i}, match:{oMatch}");

                if (o[0] >= nS && o[1] <= nE)
                {
                    o[0] = nS;
                    o[1] = nE;
                    Console.WriteLine($"0:{o[0]} 1:{o[1]}");
                    // oMatch = i;
                }

                if (oMatch >= 0)
                {
                    // if we hvae already found a match for nS, we start looking for nE
                    Console.WriteLine($"have omatch for S:{nS} E:{nE} 0:{l[oMatch][0]} 1:{l[oMatch][1]} - o is 0:{o[0]} 1:{o[1]}");
                    // if next 0 is > nE
                    if (o[0] > nE)
                    {
                        // Console.WriteLine($"found that o0:{o[0]} >  ")
                        //modify our oMatch to = nE and return the set;
                        l[oMatch][1] = Math.Max(nE, l[oMatch][1]);
                        return l.ToArray();
                    }
                    else if (o[0] <= nE)
                    {
                        Console.WriteLine($"found a guy at {i}");
                        // if o's 0 is < nE, we're going to merge with this set.
                        // if o's 1 is also < nE
                        if (o[1] <= nE)
                        {
                            //Console.WriteLine($"o 1:{o[1]} is lt= e{nE}");
                            // we take the whole set, removing it from the list;
                            l.RemoveAt(i);
                            i--;
                            // and continue
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"o 1:{o[1]} is lt= e{nE}");
                            // finally, o[1] must be 1   >= nE, so we merge into this one
                            // grab oMatch[0]
                            int newStart = l[oMatch][0];

                            // set [0] == oMatch[0]
                            o[0] = newStart;
                            // remove oMatch[0] from set
                            l.RemoveAt(oMatch);
                            return l.ToArray();
                        }
                    }
                }
                else if (o[0] <= nS && o[1] >= nS)
                {
                    // else if we find an o iv that has 0<= nS && 1>= nS
                    // we need to merge this one with ours
                    // first check if o[1] <= nE - if it is, we can just return the current set
                    Console.WriteLine($"Got omatch at {i} {nE} {o[1]}");

                    if (o[1] >= nE)
                    {
                        Console.WriteLine($"returning intervals: {intervals.Length}");
                        int point = i;
                        while (point < l.Count - 1)
                        {
                            if (o[1] >= l[point + 1][0] && o[1] >= l[point + 1][1])
                            {
                                l.RemoveAt(point + 1);
                                intervals = l.ToArray();
                            }
                            else if (o[1] >= l[point + 1][0] && l[point + 1][1] > o[1])
                            {
                                o[1] = l[point + 1][1];
                                l.RemoveAt(point + 1);
                                intervals = l.ToArray();
                            }
                            else
                            {
                                point++;
                            }
                        }

                        return intervals;
                    }

                    // else continue after flagging the match
                    //Console.WriteLine($"Cant fit inside, continuing");
                    oMatch = i;

                    continue;
                }
                else if (i < l.Count - 1 && o[1] < nS && l[i + 1][0] > nE)
                {
                    // Console.WriteLine($"found an inbetween at {i}");
                    // else if we find one that has 1 < nS and o+1[0] > nS we need to inject a new one between these two and we can break;
                    l.Insert(i + 1, new[] {nS, nE});
                    // return resulting intvl
                    return l.ToArray();
                }
                else if (nS < o[0] && nE > o[0] && nE < o[1])
                {
                    Console.WriteLine("EdgeCase");
                    o[0] = nS;
                    return l.ToArray();
                }
            }

            // there can be two states where we've finished iterating and not finished
            // we found an oMatch but it was the last item in the list
            if (l.Count - 1 > oMatch && oMatch >= 0) Console.WriteLine($"No match yet, omatch: {oMatch} {l[oMatch][0]}, {l[oMatch][1]}");

            if (oMatch >= 0)
            {
                // need to merge last intvl with ours
                if (nE >= l[oMatch][1])
                {
                    l[oMatch][1] = nE;
                }
            }
            else
            {
                Console.WriteLine($"added buddy to end.");
                // we never found an omatch, so we add intvl to end.
                l.Add(new[] {nS, nE});
            }


            return l.ToArray();
        }
    }
}