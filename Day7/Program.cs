// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

var input = System.IO.File.ReadAllText("input.txt");

var inputNumbersGrouped = input
    .Split(',')
    .Select(int.Parse)
    .GroupBy(i => i)
    .Select(grp => new KeyValuePair<int, int>(grp.Key, grp.Count()))
    .OrderBy(kvp => kvp.Key)
    .ToList();

var possiblePositions = inputNumbersGrouped.Max(kvp => kvp.Key);

var fuelUsage = 0;
var position = 0;
for (var i = 0; i <= possiblePositions; i++)
{
    var tempEff = inputNumbersGrouped
        .Select(kvp =>
        {
            var horizontalDiff = Math.Abs(kvp.Key - i);
            var fuelCost = CalculateSum(horizontalDiff);
            return fuelCost * kvp.Value;
        })
        .Sum();

    if (tempEff < fuelUsage || i == 0)
    {
        position = i;
        fuelUsage = tempEff;
    }
}

int CalculateSum(int n)
{
    return n * (n + 1) / 2;
}

Console.WriteLine($"Most fuel efficient position is {position}. Fuel usage: {fuelUsage}");