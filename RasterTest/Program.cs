using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using LinearOperations;
using SegmentRasterization;
using CircleRasterization;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var ans = CircleRaster.Rasterize(new Vector(0, 0), 5);

            foreach (var p in ans)
                Console.WriteLine(p.ToString());
        }
    }
}
