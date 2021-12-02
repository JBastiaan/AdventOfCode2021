// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

string[] lines = System.IO.File.ReadAllLines(@"C:\tempdata\AdventOfCode\Day1\input.txt");
var measurements = lines.ToList().Select(int.Parse).ToList();

//Part 1
// var increaseCounter = 0;
// var previousMeasurement = 0;
// foreach (var measurement in measurements)
// {
//     if (previousMeasurement == 0)
//     {
//         previousMeasurement = measurement;
//         continue;
//     }
//
//     if (measurement > previousMeasurement)
//         increaseCounter++;
//
//     previousMeasurement = measurement;
// }
//
// Console.WriteLine(increaseCounter);

//Part 2

var groupedMeasurements = new List<int>();
for (var i = 0; i < measurements.Count; i++)
{
    var groupedMeasurement = measurements.Skip(i).Take(3).Sum();
    groupedMeasurements.Add(groupedMeasurement);
}

var increaseCounter = 0;
var previousMeasurement = 0;
foreach (var measurement in groupedMeasurements)
{
    if (previousMeasurement == 0)
    {
        previousMeasurement = measurement;
        continue;
    }

    if (measurement > previousMeasurement)
        increaseCounter++;

    previousMeasurement = measurement;
}

Console.WriteLine(increaseCounter);