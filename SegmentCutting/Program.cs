using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SegmentCutting
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = CohenSutherland.Cut(new Point(-1, 2), new Point(1, -1), true, 0, 10, 0, 10);

            Console.WriteLine($"Count of iterations: {CohenSutherland.count}");
            Console.WriteLine( t.Item1);
            Console.WriteLine(t.Item2);
        }
    }
}
