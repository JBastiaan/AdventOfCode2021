// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using Day5;

string[] lines = System.IO.File.ReadAllLines("input.txt");
var pointPairs = new PointParser().GetPointPairs(lines);

var plotterPart1 = new PointPlotter();
plotterPart1.PlotPoints(pointPairs);
var resultPart1 = plotterPart1.GetOverLapCount();

Console.WriteLine($"Number of overlapping lines part 1: {resultPart1}");

var plotterPart2 = new PointPlotter();
plotterPart2.PlotPoints(pointPairs, true);
var resultPart2 = plotterPart2.GetOverLapCount();

Console.WriteLine($"Number of overlapping lines part 2: {resultPart2}");