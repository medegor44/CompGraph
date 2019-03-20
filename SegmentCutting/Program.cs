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
            var t = CyrusBeck.Cut(new Point(0, 0), new Point(5, 4), new Point[] { new Point(1, 1), new Point(3, 1), new Point(1, 3) });

            Console.WriteLine(t.Item1);
            Console.WriteLine(t.Item2);
        }
    }
}
