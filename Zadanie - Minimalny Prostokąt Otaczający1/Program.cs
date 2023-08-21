
using System;
using System.Collections.Generic;

namespace MinimumBoundingRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                var points = new List<(int X, int Y)>();
                for (int j = 0; j < n; j++)
                {
                    var input = Console.ReadLine().Split(' ');
                    var type = input[0][0];
                    if (type == 'p')
                    {
                        var (x, y) = (int.Parse(input[1]), int.Parse(input[2]));
                        points.Add((x, y));
                    }
                    else if (type == 'c')
                    {
                        var (x, y, r) = (int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3]));
                        points.Add((x - r, y - r));
                        points.Add((x + r, y + r));
                    }
                    else if (type == 'l')
                    {
                        var (x1, y1, x2, y2) = (int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3]), int.Parse(input[4]));
                        points.Add((Math.Min(x1, x2), Math.Min(y1, y2)));
                        points.Add((Math.Max(x1, x2), Math.Max(y1, y2)));
                    }
                }
                var (minX, minY) = (int.MaxValue, int.MaxValue);
                var (maxX, maxY) = (int.MinValue, int.MinValue);
                foreach (var point in points)
                {
                    minX = Math.Min(minX, point.X);
                    minY = Math.Min(minY, point.Y);
                    maxX = Math.Max(maxX, point.X);
                    maxY = Math.Max(maxY, point.Y);
                }
                Console.WriteLine($"{minX} {minY} {maxX} {maxY}");
                if (i < t - 1)
                {
                    Console.ReadLine(); 
                }
            }
        }
    }
}





