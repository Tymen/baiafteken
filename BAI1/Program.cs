using System;
using System.Collections.Generic;
using System.Linq;

namespace BAI
{
    public class BAI_Afteken1
    {
        /// ------------------------------------------------------------
        /// <summary>
        /// Filtert een lijst. Hierbij worden alle elementen die maar
        /// 1x voorkomen verwijderd
        /// </summary>
        /// <param name="lijst">De lijst die wordt doorlopen
        /// (wordt in functie veranderd)</param>
        /// ------------------------------------------------------------
        public static void Opdr1FilterList(List<int> lijst)
        {
            Dictionary<string, int> uniqueInts = new Dictionary<string, int>();

            for (int x = 0; x < lijst.Count; x++)
            {
                string index = lijst[x].ToString();
                if (uniqueInts.ContainsKey(index))
                {
                    uniqueInts[index] += 1;
                }
                else
                {
                    uniqueInts.Add(index, 1);
                }
            }

            for (int i = 0; i < lijst.Count; i++)
            {
                string key = lijst[i].ToString();
                if (uniqueInts[key] < 2)
                {
                    lijst.RemoveAt(i);
                    i -= 1;
                }
            }
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Maakt een queue van de getallen 1 t/m 50 (in die volgorde
        /// toegevoegd)
        /// </summary>
        /// <returns>Een queue met hierin 1, 2, 3, .., 50</returns>
        /// ------------------------------------------------------------
        public static Queue<int> Opdr2aQueue50()
        {
            Queue<int> q = new Queue<int>();
            int i = 1;
            
            while (q.Count < 50)
            {
                q.Enqueue(i);
                i++;
            }

            return q;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Haalt alle elementen uit een queue. Voegt elk element dat
        /// deelbaar is door 4 toe aan een stack
        /// </summary>
        /// <param name="queue">De queue die uitgelezen wordt</param>
        /// <returns>De stack met hierin de elementen die deelbaar zijn
        /// door 4</returns>
        /// ------------------------------------------------------------
        public static Stack<int> Opdr2bStackFromQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            
            while (queue.Count > 0)
            {
                int number = queue.Dequeue();
                if ((number % 4) == 0)
                {
                    stack.Push(number);
                }
            }
            
            return stack;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Maakt een stack met hierin unieke random getallen</summary>
        /// <param name="lower">De ondergrens voor elk getal (inclusief)</param>
        /// <param name="upper">De bovengrens voor elk getal (inclusief)</param>
        /// <param name="count">Het aantal getallen</param>
        /// <returns>De stack met unieke random getallen</returns>
        /// ------------------------------------------------------------
        public static Stack<int> Opdr3RandomNumbers(int lower, int upper, int count)
        {
            Dictionary<int, int> integersDictionary = new Dictionary<int, int>();
            Random random = new Random();
            Stack<int> stack = new Stack<int>();
            while (integersDictionary.Count < count)
            {
                int randomInt = random.Next(lower, upper + 1);
                if (!integersDictionary.ContainsKey(randomInt))
                {
                    integersDictionary.Add(randomInt, randomInt);
                    stack.Push(randomInt);
                }
            }

            return stack;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Drukt een IEnumerable (List, Stack, Queue, ..) van getallen
        /// af naar de Console
        /// <param name="enu">De IEnumerable om af te drukken</param>
        /// ------------------------------------------------------------
        static void PrintEnumerable(IEnumerable<int> enu)
        {
            foreach (int i in enu)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            List<int> list;
            Queue<int> queue;
            Stack<int> stack;

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1 : FilterList ===");
            list = new List<int>() { 1, 3, 5, 7, 3, 8, 9, 5 };
            PrintEnumerable(list);
            Opdr1FilterList(list);
            PrintEnumerable(list);

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 2 : Stack / Queue ===");
            queue = Opdr2aQueue50();
            PrintEnumerable(queue);
            stack = Opdr2bStackFromQueue(queue);
            PrintEnumerable(stack);

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 3 : Random number ===");
            stack = Opdr3RandomNumbers(100, 150, 10);
            PrintEnumerable(stack);
            stack = Opdr3RandomNumbers(10, 15, 6);
            PrintEnumerable(stack);
            stack = Opdr3RandomNumbers(10_000, 50_000, 40_001);
        }
    }
}
