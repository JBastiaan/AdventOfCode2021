using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public class PointParser
    {
        public List<(Point A, Point B)> GetPointPairs(string[] input)
        {
            List<(Point A, Point B)> result = new();
            foreach (var line in input)
            {
                var points = line
                    .Split("->")
                    .Select(s => s.Trim())
                    .ToArray();

                int[] GetPoint(string point) =>
                    point.Split(',')
                        .Select(int.Parse)
                        .ToArray();

                var pointA = GetPoint(points[0]);
                var pointB = GetPoint(points[1]);

                result.Add(
                    new (
                        new Point(pointA[0], pointA[1]), 
                        new Point(pointB[0], pointB[1])));
            }

            return result;
        }
    }
}