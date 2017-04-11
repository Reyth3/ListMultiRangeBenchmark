using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListMultiRangeBenchmark
{
    class Program
    {
        static Random rand;
        static string abc;
        static string[] GenerateStrings(int count)
        {
            var strings = new List<string>();
            for(int i = 0; i < count; i++)
            {
                var length = rand.Next(6, 13);
                var s = "";
                for (int j = 0; j < length; j++)
                    s += abc[rand.Next(0, abc.Length)];
                strings.Add(s);
            }
            return strings.ToArray();
        }

        static TimeSpan CallWithTimer(Action a)
        {
            var start = DateTime.Now;
            a();
            return DateTime.Now - start;
        }

        static void Main(string[] args)
        {
            rand = new Random();
            abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            var ranges = new List<string[]>();
            for (int i = 0; i < 50; i++)
                ranges.Add(GenerateStrings(25000));

            // Test A
            var resA = CallWithTimer(() =>
            {
                var list = new List<string>();
                list.AddRangesA(ranges);
            });
            Console.WriteLine(@"Test A: {0:s\.fff}", resA);
            // Test B
            var resB = CallWithTimer(() =>
            {
                var list = new List<string>();
                list.AddRangesB(ranges);
            });
            Console.WriteLine(@"Test B: {0:s\.fff}", resB);

            Console.ReadLine();
        }
    }
}
