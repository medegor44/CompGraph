using System;
using ConvexHullAlgo;
using LinearAlgebra;
using System.Collections.Generic;

namespace ConvexHullText
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Vector2> v = new List<Vector2>();
            for (int i = 0; i < n; i++)
            {
                var s = Console.ReadLine().Split();
                v.Add(new Vector2(int.Parse(s[0]), int.Parse(s[1])));
            }

            var ans = ConvexHullAlgo.Algorithm.Solve(v);

            foreach (var t in ans)
                Console.WriteLine(t);
        }
    }
}
