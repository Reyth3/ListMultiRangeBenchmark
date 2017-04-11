using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListMultiRangeBenchmark
{
    public static class Extensions
    {
        public static void AddRangesA<T>(this List<T> list, IEnumerable<IEnumerable<T>> ranges)
        {
            foreach (var r in ranges)
                list.AddRange(r);
        }

        public static void AddRangesB<T>(this List<T> list, IEnumerable<IEnumerable<T>> ranges)
        {
            var all = ranges.SelectMany(o => o);
            list.AddRange(all);
        }
    }
}
