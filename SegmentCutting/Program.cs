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
            var t = CohenSutherland.Cut( new Point { X = 2, Y = 0 }, new Point { X = 2, Y = 3 }, true, 1, 3, 1, 3);

            Console.WriteLine(t.Item1);
            Console.WriteLine(t.Item2);
        }
    }
}
