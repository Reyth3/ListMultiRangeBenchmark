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

        static void Main(string[] args)
        {
            rand = new Random();
            abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            var ranges = new List<string[]>();
            for (int i = 0; i < 500; i++)
                ranges.Add(GenerateStrings(50000));

            // Test A

            // Test B

        }
    }
}
