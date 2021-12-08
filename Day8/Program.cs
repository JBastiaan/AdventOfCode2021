// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using Day8;

// ReSharper disable PossibleMultipleEnumeration

var lines = System.IO.File.ReadLines("input.txt");

int[] uniqueSegmentCounts =
{
    SegmentCount.D1,
    SegmentCount.D4,
    SegmentCount.D7,
    SegmentCount.D8
};

//part 1
var resultPart1 = lines
    .Select(s => s.Split('|').Skip(1).First())
    .SelectMany(s => s.Split())
    .Count(s => uniqueSegmentCounts.Contains(s.Length));

//part2
var resultPart2 = 0;
foreach (var line in lines)
{
    var segments = line.Split(' ', '|');

    var segmentValues = new Dictionary<int, string>();
    segmentValues[1] = segments.First(s => s.Length == SegmentCount.D1);
    segmentValues[4] = segments.First(s => s.Length == SegmentCount.D4);
    segmentValues[7] = segments.First(s => s.Length == SegmentCount.D7);
    segmentValues[8] = segments.First(s => s.Length == SegmentCount.D8);

    segmentValues[2] = segments.First(
        s =>
            s.Length == 5 &&
            s.ToCharArray().Intersect(segmentValues[4].ToCharArray()).Count() == 2);

    segmentValues[3] = segments.First(
        s =>
            s.Length == 5 &&
            s.ToCharArray().Intersect(segmentValues[1].ToCharArray()).Count() == 2);

    segmentValues[5] = segments.First(
        s =>
            s.Length == 5 &&
            !s.ToCharArray().All(c => segmentValues[2].ToCharArray().Contains(c)) &&
            !s.ToCharArray().All(c => segmentValues[3].ToCharArray().Contains(c)));

    segmentValues[6] = segments.First(
        s =>
            s.Length == 6 &&
            s.ToCharArray().Intersect(segmentValues[1].ToCharArray()).Count() == 1);

    segmentValues[9] = segments.First(
        s =>
            s.Length == 6 &&
            s.ToCharArray().Intersect(segmentValues[4].ToCharArray()).Count() == 4);

    segmentValues[0] = segments.First(
        s =>
            s.Length == 6 &&
            !s.ToCharArray().All(c => segmentValues[6].ToCharArray().Contains(c)) &&
            !s.ToCharArray().All(c => segmentValues[9].ToCharArray().Contains(c)));
   
    resultPart2 += int.Parse(
        string.Concat(
            line
                .Split('|').Skip(1).First()
                .Split(' ')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s =>
                    segmentValues
                        .First(kvp => 
                            kvp.Value.Length == s.Length &&
                            !kvp.Value.ToCharArray().Except(s.ToCharArray()).Any())
                        .Key
                        .ToString())));
}

Console.WriteLine("Result for part 1: " + resultPart1);
Console.WriteLine("Result for part 2: " + resultPart2);