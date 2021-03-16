using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace training.Exemples
{
    public class SyntaxePerf
    {
        public static int[] numbers = { 5, 10, 8, 3, 6, 12 };


        public static void Run()
        {
            var watchQuery = System.Diagnostics.Stopwatch.StartNew();

            IEnumerable<int> numQuery1 =
            from num in numbers
            where num % 2 == 0
            orderby num
            select num;

            foreach (int i in numQuery1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(System.Environment.NewLine);

            watchQuery.Stop();
            var elapsedMs = watchQuery.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            var watchFunction = System.Diagnostics.Stopwatch.StartNew();

            //Method syntax:
            IEnumerable<int> numQuery2 =
                numbers.Where(num => {
                    Console.WriteLine("test");
                    return num % 2 == 0; }
                ).OrderBy(n => n);

            foreach (int i in numQuery2)
            {
                Console.Write(i + " ");
            }

            watchFunction.Stop();
            var elapsewatchunction = watchQuery.ElapsedMilliseconds;
            Console.WriteLine(elapsewatchunction);


            var result = numbers.Where(delegate (int num)
            {
                Console.WriteLine(num);
                return num % 2 == 0;
            }).OrderBy(delegate (int num)
            {
               return num;
            });

            foreach (int i in result)
            {
                Console.Write(i + " ");
            }

        }
    }
}
