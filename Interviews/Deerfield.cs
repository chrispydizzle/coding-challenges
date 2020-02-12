namespace CodeChallenges.Interviews
{
    using System;
    using System.Linq;

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Work2
    {
        public static string[] Data = new[] {"3", "5", "6", "8", "5", "3", "2", "4", "1", "0", "1"};

        public static Person[] People = new[]
        {
            new Person("Bob", 31),
            new Person("Tom", 40),
            new Person("Dan", 45),
            new Person("Jon", 26)
        };

        static void NotMain(string[] args)
        {
            // For questions 1 - 4, use the "Data" above. Do not mutate the data.
            var w = new Work();
            w.One();
            w.Two();
            w.Three();
            w.Four();
            w.Five();
            w.Six();

            // Console.WriteLine("Show Result In Console");
        }
    }

    class Work
    {
        private string[] d;
        private Person[] p;

        public Work(Person[] p, string[] d)
        {
            this.p = p;
            this.d = d;
        }

        public Work()
        {
            //this.p = Program.People;
            //this.d = Program.Data;
        }

        public void One()
        {
            //1) print each number to the console
            Console.WriteLine("One");
        }

        public void Two()
        {
            //2) print only the odd numbers to the console
            Console.WriteLine("Two");
            Console.WriteLine("2) print only the odd numbers to the console");
            foreach (int i in Array.ConvertAll(d, Convert.ToInt32))
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public void Three()
        {
            //3) print distinct numbers to the console
            Console.WriteLine("Three");
        }

        public void Four()
        {
            //4) print sorted numbers to the console
        }

        // Using the People array, answer the following questions:
        public void Five()
        {
            // 5) print the name and age of the oldest person
            Person target = p.FirstOrDefault(t => t.Age == p.Max(a => a.Age));
        }

        public void Six()
        {
            // 6) print the average age
        }
    }
}