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
            var t = CohenSutherland.Cut( new Point { X = 100, Y = 100 }, new Point { X = 0, Y = 100 }, 1, 3, 1, 3);

            Console.WriteLine(t.Item1);
            Console.WriteLine(t.Item2);
        }
    }
}
