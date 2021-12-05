// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using Day5;

string[] lines = System.IO.File.ReadAllLines("input.txt");
var pointPairs = new PointParser().GetPointPairs(lines);

var plotter = new PointPlotter();
plotter.PlotPoints(pointPairs);
var resultPart1 = plotter.GetOverLapCount();

Console.WriteLine($"Number of overlapping lines part 1: {resultPart1}");