// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using Day8;

var lines = System.IO.File.ReadLines("input.txt");

int[] uniqueSegmentCounts = new[]
{
    SegmentCount.D1,
    SegmentCount.D4,
    SegmentCount.D7,
    SegmentCount.D8
};
 
var result = lines
    .Select(s => s.Split('|').Skip(1).First())
    .SelectMany(s => s.Split())
    .Where(s => uniqueSegmentCounts.Contains(s.Length))
    .Count();

Console.WriteLine(result);