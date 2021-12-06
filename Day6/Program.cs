// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

var input = System.IO.File.ReadAllText("input.txt");

var fishGroups = Enumerable.Range(0, 9)
    .Select(i => new KeyValuePair<long, long>(i, 0))
    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

var inputNumbersGrouped = input
    .Split(',')
    .Select(long.Parse)
    .GroupBy(i => i)
    .ToList();

foreach (var inputNumberGroup in inputNumbersGrouped)
{
    fishGroups[inputNumberGroup.Key] = inputNumberGroup.Count();
}

var days = 256;
for (var i = 0; i < days; i++)
{

    var previousCount = 0L;
    for (var j = fishGroups.Count - 1; j >= 0; j--)
    {
        if (j == fishGroups.Count)
        {
            previousCount = fishGroups[j];
            continue;
        }

        var temp = fishGroups[j];
        fishGroups[j] = previousCount;
        previousCount = temp;

        if (j == 0)
        {
            fishGroups[6] += previousCount;
            fishGroups[fishGroups.Count - 1] = previousCount;
        }
    }
}

Console.WriteLine($"After {days} days there are {fishGroups.Sum(kvp => kvp.Value)} fish.");