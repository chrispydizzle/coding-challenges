namespace CodeChallenges.Interviews
{
    /*public class BridgeWaterPractice
    {
        public void Precurse()
        {
            DeadlockDetector d = new DeadlockDetector();
            string currentIn = Console.ReadLine();
            if (string.IsNullOrEmpty(currentIn)) return;

            do
            {
                d.Consume(currentIn);
                currentIn = Console.ReadLine();
            } while (!string.IsNullOrEmpty(currentIn));


            Console.Write(d.FindLocks());
        }

        /// <summary>
        /// now need to re-think
        ///    what we actually need to do is set some kind of flag for each lock we see. in each path. For step one, every flag is willwaitfor {noone}
        /// then a step two, we see
        /// </summary>
        public class DeadlockDetector
        {
            private readonly Dictionary<string, HashSet<ValueTuple<string, string>>> paths = new Dictionary<string, HashSet<ValueTuple<string, string>>>();
            private readonly Dictionary<ValueTuple<string, string>, List<string>> transitions = new Dictionary<ValueTuple<string, string>, List<string>>();
            private readonly HashSet<string> collisions = new HashSet<string>();
            private readonly List<ValueTuple<string, string>> allTransitions = new List<(string, string)>();
            private readonly HashSet<string> locks = new HashSet<string>();

            /// <summary>
            ///  store next value the dictionary of queues.
            /// </summary>
            public void Consume(string currentIn)
            {
                string[] pathParts = currentIn.Split(' ');
                string pathName = pathParts[0];
                currentIn = currentIn.Substring(pathName.Length).Replace(" ", string.Empty);
                string[] locks = currentIn.Split(',');
                paths.Add(pathName, new HashSet<ValueTuple<string, string>>());
                for (int i = 1; i < locks.Length; i++)
                {
                    this.locks.Add(locks[i]);
                    this.locks.Add(locks[i - 1]);
                    var requestLock = (locks[i - 1], locks[i]);
                    paths[pathName].Add(requestLock);
                    allTransitions.Add(requestLock);
                    var reverseLock = (locks[i], locks[i - 1]);
                    if (!transitions.ContainsKey(reverseLock))
                    {
                        transitions.Add(reverseLock, new List<string>());
                    }

                    transitions[reverseLock].Add(pathName);
                }
            }

            public void Consume(List<string> batchIn)
            {
                foreach (string s in batchIn)
                {
                    this.Consume(s);
                }
            }

            public string FindLocksBefore()
            {
                foreach (KeyValuePair<string, HashSet<ValueTuple<string, string>>> entry in this.paths)
                {
                    var mainThread = entry.Key;
                    foreach (KeyValuePair<string, HashSet<(string, string)>> compare in this.paths)
                    {
                    }
                }

                return string.Empty;
            }

            /// <summary>
            /// Try a recursive DFS
            /// </summary>
            /// <returns></returns>
            public string FindLocks()
            {
                Dictionary<string, bool> locked = new Dictionary<string, bool>();
                Queue<(string, HashSet<(string, string)>)> threadQueue = new Queue<(string, HashSet<(string, string)>)>();

                // generate our lock set and threadq
                foreach (string item in locks)
                {
                    locked.Add(item, false);
                    threadQueue.Enqueue((item, this.paths[item]));
                }

                List<string> results = this.FindLocks(locked, threadQueue);
                return String.Join("\n", results);
            }

            private List<string> FindLocks(Dictionary<string, bool> locked, Queue<(string, HashSet<(string, string)>)> paths)
            {
                if (!paths.Any()) return null; // this means we have gone through all threads for this batch. Good news, maybe?
                (string, HashSet<(string, string)>) valueTuple = paths.Dequeue();

                while (paths.Any())
                {
                    paths.Dequeue();

                }

                paths.Dequeue();
                paths.Dequeue()
                string key = ;

                HashSet<(string, string)> tempStore = paths[key];
                Stack<ValueTuple<string, string>> thread = new Stack<(string, string)>();
                paths.Remove(key);

                while (thread.Any())
                {
                    var currentState = thread.Pop();
                    locked[currentState.Item1] = true;
                    var deadlock = this.FindLocks(locked, paths);
                    if (deadlock != null)
                    {
                        if (deadlock.Contains(currentState.Item1) && !locked[currentState.Item2])
                        {
                            locked[currentState.Item1] = false;
                        }
                        else
                        {
                            deadlock.Add(key);
                            return deadlock;
                        }
                    }
                }

                return null;
            }

            /// <summary>
            /// Queue not gonna work either. I think if I work in pairs, and just track each state change in a hashset, I should be able
            /// to find what they're looking for.
            /// </summary>
            public string FindLocksNo()
            {
                foreach (KeyValuePair<string, HashSet<ValueTuple<string, string>>> entry in this.paths)
                {
                    // dfs?
                    List<ValueTuple<string, string>> pathCollisions = entry.Value.Intersect(this.transitions.Keys).ToList();

                    if (!pathCollisions.Any()) continue;


                    foreach (var collision in pathCollisions.Where(i => i.Item1 != null))
                    {
                        List<string> transition = this.transitions[collision].Where(t => t != entry.Key).ToList();
                        foreach (string s in transition)
                        {
                            int ordering = string.Compare(s, entry.Key, StringComparison.InvariantCultureIgnoreCase);
                            if (ordering == -1)
                            {
                                this.collisions.Add($"{s},{entry.Key}");
                            }
                            else if (ordering == 1)
                            {
                                this.collisions.Add($"{entry.Key},{s}");
                            }
                        }
                    }
                }

                if (collisions.Count == 0) return string.Empty;

                return String.Join("\n", this.collisions.OrderBy(c => c));
            }

            public void Clear()
            {
                this.collisions.Clear();
                this.paths.Clear();
                this.transitions.Clear();
            }
        }
    }*/
}