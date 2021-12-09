// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using Day9;

var input = System.IO.File.ReadLines("input.txt");

var lines = input
    .Select(l => l.ToCharArray().Select(c => int.Parse(c.ToString())).ToList())
    .ToList();

var lowestPoints = new List<KeyValuePair<int, Point>>();
for (int i = 0; i < lines.Count; i++)
{
    var line = lines[i];

    for (int j = 0; j < line.Count; j++)
    {
        var value = line[j];
        var adjacentPoints = new List<KeyValuePair<int, Point>>();

        if (j + 1 < line.Count)
            adjacentPoints.Add(new KeyValuePair<int, Point>(line[j + 1], new Point(i, j + 1)));

        if (j - 1 >= 0)
            adjacentPoints.Add(new KeyValuePair<int, Point>(line[j - 1], new Point(i, j - 1)));

        if (i - 1 >= 0)
            adjacentPoints.Add(new KeyValuePair<int, Point>(lines[i - 1][j], new Point(i - 1, j)));

        if (i + 1 < lines.Count)
            adjacentPoints.Add(new KeyValuePair<int, Point>(lines[i + 1][j], new Point(i + 1, j)));

        if (adjacentPoints.All(v => v.Key > value))
            lowestPoints.Add(new KeyValuePair<int, Point>(value, new Point(i, j)));
    }
}

var basins = new List<List<KeyValuePair<int, Point>>>();
foreach (var point in lowestPoints)
{
    bool added;
    var basinPoints = new List<KeyValuePair<int, Point>>() { point };
    do
    {
        added = false;

        var additionalBasinPoints = new List<KeyValuePair<int, Point>>();
        foreach (var basinPoint in basinPoints)
        {
            var i = basinPoint.Value.I1;
            var j = basinPoint.Value.I2;
            
            if (j + 1 < lines[i].Count && lines[i][j + 1] < 9)
            {
                if (!basinPoints.Any(kvp => kvp.Value.I1 == i && kvp.Value.I2 == j + 1) &&
                    !additionalBasinPoints.Any(kvp => kvp.Value.I1 == i && kvp.Value.I2 == j + 1))
                {
                    additionalBasinPoints.Add(new KeyValuePair<int, Point>(lines[i][j + 1], new Point(i, j + 1)));
                    added = true;
                }
            }


            if (j - 1 >= 0 && lines[i][j - 1] < 9)
            {
                if (!basinPoints.Any(kvp => kvp.Value.I1 == i && kvp.Value.I2 == j - 1) &&
                    !additionalBasinPoints.Any(kvp => kvp.Value.I1 == i && kvp.Value.I2 == j - 1))
                {
                    additionalBasinPoints.Add(new KeyValuePair<int, Point>(lines[i][j - 1], new Point(i, j - 1)));
                    added = true;
                }
            }


            if (i - 1 >= 0 && lines[i - 1][j] < 9)
            {
                if (!basinPoints.Any(kvp => kvp.Value.I1 == i - 1 && kvp.Value.I2 == j) &&
                    !additionalBasinPoints.Any(kvp => kvp.Value.I1 == i - 1 && kvp.Value.I2 == j))
                {
                    additionalBasinPoints.Add(new KeyValuePair<int, Point>(lines[i - 1][j], new Point(i - 1, j)));
                    added = true;
                }
            }


            if (i + 1 < lines.Count && lines[i + 1][j] < 9)
            {
                if (!basinPoints.Any(kvp => kvp.Value.I1 == i + 1 && kvp.Value.I2 == j) &&
                    !additionalBasinPoints.Any(kvp => kvp.Value.I1 == i + 1 && kvp.Value.I2 == j))
                {
                    additionalBasinPoints.Add(new KeyValuePair<int, Point>(lines[i + 1][j], new Point(i + 1, j)));
                    added = true;
                }
            }
        }

        basinPoints.AddRange(additionalBasinPoints);

    } while (added);
    
    basins.Add(basinPoints);
}

var resultPart2 = basins.OrderByDescending(b => b.Count)
    .Take(3)
    .Select(l => l.Count)
    .Aggregate((a, b) => a * b);

Console.WriteLine($"Result part 1: {lowestPoints.Sum(p => p.Key + 1)}");
Console.WriteLine($"Result part 2: {resultPart2}");